using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Loan
{
	public string Name { get; set; }
	public PaymentTypes PaymentType { get; set; }
	public decimal Debt { get; private set; }
	public decimal CostForEachPayment { get; private set; } 
	public decimal Interest { get; private set; }
	public decimal InitialValue { get; private set; }
	public BankAccount? BankAccount { get; set; }
	public DateTime PayDate { get; private set; }
	public string PayDateString => $"Next Pay Date: {PayDate.ToString("dd-MM-yyyy")}";

	private decimal NextPaymentAmount;

	public Loan(string name, PaymentTypes paymentType , decimal initialValue, decimal interest, decimal costForEachPayment)
	{
		Name = name;
		PaymentType = paymentType;
		InitialValue = initialValue;
		Interest = interest;
		CostForEachPayment = costForEachPayment;
		Debt = initialValue;
	}

	public Loan(string name, decimal costForEachPayment, decimal interest, PaymentTypes paymentType, decimal debt, DateTime payDate, BankAccount bankAccount)
	{
		PaymentType = paymentType;
		BankAccount = bankAccount;
		Debt = debt;
		Name = name;
		Interest = interest;
		CostForEachPayment = costForEachPayment;
		PayDate = payDate;
		

	}

	private void AddInterest()
	{
		Debt *= (Interest / 100) + 1;
	}

	public bool PayLoan(BankAccount bankAccount)
	{
		if (BankAccount.Balance >= NextPaymentAmount)
		{
			BankAccount.Balance -= NextPaymentAmount;
			Debt -= NextPaymentAmount;
			return true;
		}

		return false;
	}
}
