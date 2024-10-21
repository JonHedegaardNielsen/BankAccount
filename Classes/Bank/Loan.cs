using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Loan
{
	public int Id { get; }
	public string Name { get; set; }
	public PaymentTypes PaymentType { get; set; }
	public decimal Debt { get; private set; }
	public string DebtString => $"Total Debt {Debt.ToString()} kr.";
	public decimal CostForEachPayment { get; private set; } 
	public decimal Interest { get; private set; }
	public decimal InitialValue { get; private set; }
	public BankAccount? BankAccount { get; set; }
	public DateTime PayDate { get; private set; } = DateTime.Now;
	public string PayDateString => $"Next Pay Date: {PayDate.ToString("dd-MM-yyyy")}";

	public bool LoanFinished =>
		Debt <= 0;

	public bool IsPayTime() =>
		PayDate <= GetCurrentDate();


	public Loan(string name, PaymentTypes paymentType , decimal initialValue, decimal interest, decimal costForEachPayment)
	{
		Name = name;
		PaymentType = paymentType;
		InitialValue = initialValue;
		Interest = interest;
		CostForEachPayment = costForEachPayment;
		Debt = initialValue;
	}

	public Loan(int id, string name, decimal costForEachPayment, decimal interest, PaymentTypes paymentType, decimal debt, DateTime payDate, BankAccount bankAccount)
	{
		Id = id;
		PaymentType = paymentType;
		BankAccount = bankAccount;
		Debt = debt;
		Name = name;
		Interest = interest;
		CostForEachPayment = costForEachPayment;
		PayDate = payDate;
	}

	private DateTime GetCurrentDate()
	{
		DateTime timeNow = DateTime.Now;
		return new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 0, 0, 0);
	}

	public bool CheckLoanDate() =>
		PayDate.Day >= DateTime.Now.Day;

	private void AddInterest()
	{
		Debt *= (Interest / 100) + 1;
	}

	public bool PayLoan()
	{
		decimal nextPaymentAmount = CostForEachPayment;

		if (Debt <= CostForEachPayment)
			nextPaymentAmount = Debt;

		if (BankAccount != null && BankAccount.Balance >= nextPaymentAmount)
		{
			BankAccount.Balance -= nextPaymentAmount;
			Debt -= nextPaymentAmount;
			ChangePayDate();
			LoanDatabase.Instance.UpdateLoan(this);
			return true;
		}

		if (LoanFinished)
			LoanDatabase.Instance.Delete(Id);

		AddInterest();
		return false;
	}

	public void ChangePayDate()
	{
		PayDate = GetNextPayDate();
	}

	private DateTime GetNextPayDate()
	{
		switch (PaymentType)
		{
			case PaymentTypes.Weekly:
				return PayDate.AddDays(7);

			case PaymentTypes.Monthly:
				return PayDate.AddMonths(1);

			case PaymentTypes.Yearly:
				return PayDate.AddYears(1);

			case PaymentTypes.Quarterly:
				return PayDate.AddMonths(3);

			default:
				throw new ArgumentException();
		}
	}
}
