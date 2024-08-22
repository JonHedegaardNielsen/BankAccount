using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankAccount
{
	public int Id;
	public string Name { get; private set; }
	public decimal Balance { get; private set; }

	public BankAccount(int id, string name, decimal balance)
	{
		Name = name;
		Balance = balance;
		Id = id;
	}
}
