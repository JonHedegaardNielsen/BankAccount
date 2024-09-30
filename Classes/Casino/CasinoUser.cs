using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class CasinoUser
{
	public static CasinoUser? CurrentUser;

	public int Id { get; set; }
	private string UserName = string.Empty;
	private string Password = string.Empty;

	BankAccount BankAccount;

    public CasinoUser(int id, string username, string password, BankAccount bankAccount)
    {
        Id = id;
		UserName = username;
		Password = password;
		BankAccount = bankAccount;
    }

	public bool Login(string username, string password)
	{
		CurrentUser = CasinoUserDatabase.Instance.FindUser(username, password);
		return CurrentUser != null;
	}
}
