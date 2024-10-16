using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankUser : User
{
	public static BankUser? CurrentUser { get; private set; }

	public List<Loan> Loans { get; private set; } = new List<Loan>();
	public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

	
	public BankUser(int id, string username, string password, List<BankAccount> bankAccounts, List<Loan> loans) : base(id, username, password)
	{
		BankAccounts = bankAccounts;
		Loans = loans;
	}

	public static void LogOut()
	{
		CurrentUser = null;
	}

	public static bool Login(string userName, string password)
	{
		BankUserDatabase.Instance.FindUser(userName, password, out User? bankUser);
		CurrentUser = (BankUser)bankUser;
		return CurrentUser != null;
	}

	public static void UpdateCurrentUser()
	{
		CurrentUser = BankUserDatabase.Instance.GetUserFromId(CurrentUser.Id);
	}
}
