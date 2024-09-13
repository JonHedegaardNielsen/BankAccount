using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class BankUserDatabase : Database<BankUser>
{
	private BankUserDatabase() { }
	public static BankUserDatabase Instance = new BankUserDatabase();

	public void CreateUser(string username, string password)
	{
		ExecuteNonQuery($"INSERT INTO bankUser(userName, password) VALUES('{username}', '{password}')");
	}

	private BankUser GetData(SqlDataReader reader)
	{
		int userId = reader.GetInt32(0);
		return new BankUser(userId ,reader.GetString(1), reader.GetString(2), BankAccountDatabase.Instance.GetBankAccounts(userId), LoanDatabase.Instance.SelectLoan(userId));
	}

	public void DeleteCurrentUser()
	{
		LoanDatabase.Instance.DeleteLoanFromUserId(BankUser.CurrentUser.Id);
		
		foreach (var bankAccount in BankUser.CurrentUser.BankAccounts)
			BankAccountDatabase.Instance.DeleteBankAccount(bankAccount.Id);

		ExecuteNonQuery($"DELETE FROM bankUser WHERE userId = {BankUser.CurrentUser.Id}");
	}

	public bool FindUser(string username, string password, out BankUser? user)
	{
		try
		{
			user = RunSingleQuery($"SELECT TOP(1) * FROM bankUser WHERE username COLLATE Latin1_General_BIN = '{username}' AND [password] COLLATE Latin1_General_BIN = '{password}'", GetData);
			return true;
		}
		catch (InvalidOperationException)
		{
			user = null;
			return false;
		}
	}

	public BankUser GetUserFromId(int userId) =>
		RunSingleQuery($"SELECT * FROM bankUser WHERE userId = {userId}", GetData);
}
