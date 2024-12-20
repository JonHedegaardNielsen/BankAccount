﻿namespace BankAccount;

public class BankAccount 
{
	public int Id { get; private set; }
	public string Name { get; private set; }
	public decimal Balance { get; set; }

	public BankAccount(int id, string name, decimal balance)
	{
		Name = name;
		Balance = balance;
		Id = id;
	}

	public bool Transfer(decimal balanceToTransfer, BankAccount bankAccountTranferFrom)
	{
		if (bankAccountTranferFrom.Balance >= balanceToTransfer)
		{
			Balance += balanceToTransfer;
			bankAccountTranferFrom.Balance -= balanceToTransfer;

			BankAccountDatabase.Instance.UpdateBalance(Id, Balance);
			BankAccountDatabase.Instance.UpdateBalance(bankAccountTranferFrom.Id, bankAccountTranferFrom.Balance);

			return true;
		}

		return false;
	}
}
