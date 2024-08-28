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

	public bool CreateUser(string username, string password) =>
		ExecuteNonQuery($"INSERT INTO [user](userName, password) VALUES('{username}', '{password}')");

	private User GetData(SqlDataReader reader)
	{
		int userId = int.Parse(reader["userId"].ToString());
		return new User(userId ,reader["userName"].ToString(), reader["password"].ToString(), BankAccountDatabase.Instance.GetBankAccounts(userId), LoanDatabase.Instance.SelectLoan(userId));
	}

	public bool FindUser(string username, string password, out User? user)
	{
		try
		{
			user = RunSingleQuery($"SELECT TOP(1) * FROM [user] WHERE username COLLATE Latin1_General_BIN = '{username}' AND [password] COLLATE Latin1_General_BIN = '{password}'", GetData);
			return true;
		}
		catch(Exception)
		{
			user = null;
			return false;
		}
	}
}
