using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankAccount
{
	public int Id { get; private set; }
	public string Name { get; private set; }
	public decimal Balance { get; set; }
	public string BalanceString => $"{Balance.ToString()} kr.";
	public BankAccount(int id, string name, decimal balance)
	{
		Name = name;
		Balance = balance;
		Id = id;
	}

	public void Transfer(decimal balanceToTransfer, BankAccount bankAccountTranferFrom)
	{
		Balance += balanceToTransfer;
		bankAccountTranferFrom.Balance -= balanceToTransfer;
		BankAccountDatabase.Instance.UpdateBalance(Id, Balance);
		BankAccountDatabase.Instance.UpdateBalance(bankAccountTranferFrom.Id, bankAccountTranferFrom.Balance);
	}
}
