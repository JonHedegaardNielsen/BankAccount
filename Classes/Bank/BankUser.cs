﻿using System.Collections.Generic;

namespace BankAccount;

public class BankUser : User
{
	private static BankUser? _currentuser;
	public static BankUser CurrentUser 
	{
		get => (BankUser)ValidateGetUser(_currentuser);
	}

	public static bool IsLoggedIn => _currentuser != null;

	public List<Loan> Loans { get; private set; } = new List<Loan>();
	public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

	
	public BankUser(int id, string username, string password, List<BankAccount> bankAccounts, List<Loan> loans) : base(id, username, password)
	{
		BankAccounts = bankAccounts;
		Loans = loans;
	}

	public static void LogOut()
	{
		_currentuser = null;
	}

	public static bool Login(string userName, string password)
	{
		BankUserDatabase.Instance.FindUser(userName, password, out User? bankUser);
			_currentuser = (BankUser?)bankUser;
		return IsLoggedIn;
	}

	public static void UpdateCurrentUser()
	{
		_currentuser = BankUserDatabase.Instance.GetUserFromId(CurrentUser.Id);
	}
}
