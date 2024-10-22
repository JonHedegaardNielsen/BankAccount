using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankLoanViewModel : ReactiveObject
{
	public ReactiveCommand<Unit,Unit> PayOffLoanCommand { get; }
	private object? _currentpage;
	
	private Loan Loan;
	public bool IsPayTime => Loan.IsPayTime();
	public decimal Interest => Loan.Interest;
	public string PayDate => Loan.PayDate.ToString("dd-MM-yyyy");
	public PaymentTypes PaymentType => Loan.PaymentType;
	public decimal CostForEachPayment => Loan.CostForEachPayment;

	private decimal _debt;
	public decimal Debt
	{
		get => _debt;
		set => this.RaiseAndSetIfChanged(ref _debt, value);
	}

	private bool _isVisible = true;
	public bool IsVisible
	{
		get => _isVisible;
		set => this.RaiseAndSetIfChanged(ref _isVisible, value);
	}

	private bool _isEnabled = true;
	public bool IsEnabled
	{
		get => _isEnabled;
		set => this.RaiseAndSetIfChanged(ref _isEnabled, value);
	}

	public BankLoanViewModel(Loan loan)
	{
		Loan = loan;
		Debt = Loan.Debt;
	}

	private void PayOffLoan()
	{
		Loan.PayLoan();

		if (Loan.LoanFinished)
		{
			IsEnabled = false;
			IsVisible = false;
		}
	}
}
