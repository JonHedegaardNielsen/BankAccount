﻿using System;
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
	public List<BankAccount> bankAccounts { get; private set; } = new List<BankAccount>();

	public User(int id, string username, string password)
	{
		Id = id;
		Username = username;
		Password = password;
	}
}
