using System;
using System.Collections.Generic;
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

	public Loan(string name, decimal initialValue, PaymentTypes paymentType, decimal interest, decimal costForEachPayment)
	{
		Name = name;
		PaymentType = paymentType;
		InitialValue = initialValue;
		Interest = interest;
		CostForEachPayment = costForEachPayment;
		Debt = initialValue;
	}

	public Loan(string name, decimal interest, decimal costForEachPayment, PaymentTypes paymentType, decimal debt, BankAccount bankAccount)
	{
		PaymentType = paymentType;
		BankAccount = bankAccount;
		Debt = debt;
		Name = name;
		Interest = interest;
		CostForEachPayment = costForEachPayment;

	}
}
