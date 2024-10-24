using ReactiveUI;
using System.Reactive;

namespace BankAccount;

public class BankLoanViewModel : ReactiveObject
{
	public ReactiveCommand<Unit,Unit> PayOffLoanCommand { get; }
	
	private Loan Loan;
	public bool IsPayTime => Loan.IsPayTime();
	public decimal Interest => Loan.Interest;
	public string PayDate => Loan.PayDate.ToString("dd-MM-yyyy");
	public PaymentType PaymentType => Loan.PaymentType;
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
		PayOffLoanCommand = ReactiveCommand.Create(PayOffLoan);
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
