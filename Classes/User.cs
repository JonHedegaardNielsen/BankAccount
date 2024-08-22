using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class User
{
	public int Id { get; private set; }
	public string Username { get; private set; } = string.Empty;
	public string Password { get; private set; } = string.Empty;

	public List<Loan> Loans { get; private set; } = new List<Loan>();
	public List<BankAccount> BankAccounts { get; private set; } = new List<BankAccount>();

	
	public User(int id, string username, string password, List<BankAccount> bankAccounts, List<Loan> loans)
	{
		BankAccounts = bankAccounts;
		Id = id;
		Username = username;
		Password = password;
		Loans = loans;
	}
}
