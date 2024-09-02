using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class UserDatabase : Database<User>
{
	private UserDatabase() { }
	public static UserDatabase Instance = new UserDatabase();

	public void CreateUser(string username, string password)
	{
		ExecuteNonQuery($"INSERT INTO [user](userName, password) VALUES('{username}', '{password}')");
	}

	private User GetData(SqlDataReader reader)
	{
		int userId = reader.GetInt32(0);
		return new User(userId ,reader.GetString(1), reader.GetString(2), BankAccountDatabase.Instance.GetBankAccounts(userId), LoanDatabase.Instance.SelectLoan(userId));
	}

	public bool FindUser(string username, string password, out User? user)
	{
		try
		{
			user = RunSingleQuery($"SELECT TOP(1) * FROM [user] WHERE username COLLATE Latin1_General_BIN = '{username}' AND [password] COLLATE Latin1_General_BIN = '{password}'", GetData);
			return true;
		}
		catch (InvalidOperationException)
		{
			user = null;
			return false;
		}
	}

	public User GetUserFromId(int userId) =>
		RunSingleQuery($"SELECT * FROM [user] WHERE userId = {userId}", GetData);
}
