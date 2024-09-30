using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankUser
{
	public static BankUser? CurrentUser { get; private set; }


	public int Id { get; private set; }
	private string Username = string.Empty;
	private string Password = string.Empty;

	public List<Loan> Loans { get; private set; } = new List<Loan>();
	public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

	
	public BankUser(int id, string username, string password, List<BankAccount> bankAccounts, List<Loan> loans)
	{
		BankAccounts = bankAccounts;
		Id = id;
		Username = username;
		Password = password;
		Loans = loans;
	}

	public static void LogOut()
	{
		CurrentUser = null;
	}

	public static bool Login(string userName, string password)
	{
		BankUserDatabase.Instance.FindUser(userName, password, out BankUser? bankUser);
		CurrentUser = bankUser;
		return CurrentUser != null;
	}

	public static void UpdateCurrentUser()
	{
		CurrentUser = BankUserDatabase.Instance.GetUserFromId(CurrentUser.Id);
	}
}
