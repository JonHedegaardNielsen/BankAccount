using System;
using System.Collections.Generic;
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
		ExecuteNonQuery($"INSERT INTO [user](useName, password) VALUES('{username}', '[{password}]')");
	}
}
