using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class CasinoUserDatabase : Database<CasinoUser>
{
	public static CasinoUserDatabase Instance = new CasinoUserDatabase();

	private CasinoUser? GetData(SqlDataReader reader)
	{
		try
		{
			return new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new(reader.GetInt32(4), reader.GetString(5), reader.GetDecimal(6)), reader.GetDecimal(7));
		}
		catch 
		{ 
			return null; 
		}
	}

	public decimal GetTotalProfit(CasinoUser casinoUser)
	{
		int userId = BankUserDatabase.Instance.GetUserIdFromBankAccountId(casinoUser.BankAccount.Id);
		return CasinoWinsDatabase.Instance.GetTotalRewards(userId) - TransactionDatabase.Instance.GetUserExpensesOfCategory(SpendingCategory.Gambling, userId);
	}

	public CasinoUser? FindUser(string username, string password) =>
		RunSingleQuery($"SELECT TOP(1) * FROM casinoUser u JOIN bankAccount b ON u.bankAccountId = b.bankAccountId WHERE u.username COLLATE Latin1_General_BIN = '{username}' AND u.[password] COLLATE Latin1_General_BIN = '{password}'", GetData);

	public void UpdateAmountToWinBack(decimal amount, int userId) =>
		ExecuteNonQuery($"UPDATE casinoUser SET amountToWinBack={FormatDecimal(amount)} WHERE userId = {userId}");

	public bool CreateUser(string username, string password, int bankAccountId)
	{
		try
		{
			ExecuteNonQuery($"INSERT INTO casinoUser(username, [password], bankAccountId) VALUES('{username}', '{password}', {bankAccountId})");
			return true;
		}
		catch(InvalidOperationException)
		{
			return false;
		}
	}
}
