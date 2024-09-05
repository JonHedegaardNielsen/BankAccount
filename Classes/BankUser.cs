using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankUser
{
	public static BankUser? CurrentUser { get; set; }


	public int Id { get; private set; }
	public string Username { get; private set; } = string.Empty;
	public string Password { get; private set; } = string.Empty;

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

	public static void UpdateCurrentUser()
	{
		CurrentUser = BankUserDatabase.Instance.GetUserFromId(CurrentUser.Id);
	}
}
