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

	private User GetData(SqlDataReader reader) =>
		new User(int.Parse( reader["userId"].ToString()), reader["userName"].ToString(), reader["password"].ToString());

	public bool FindUser(string username, string password, out User? user)
	{
		try
		{
			var v = RunQuery($"SELECT * FROM [user] WHERE username = '{username}' AND [password] = '{password}'", GetData);
			user = v[0];
			return true;
		}
		catch(ArgumentOutOfRangeException)
		{
			user = null;
			return false;
		}
	}
}
