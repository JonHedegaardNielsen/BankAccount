using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class CreateLoanPageViewModel : ReactiveObject
{
	public ReactiveCommand<Unit, Unit> CreateLoanCommand { get; }
	public ReactiveCommand<Unit, Unit> GoBackCommand { get; }
	public ObservableCollection<Loan> Loans { get; } = new ObservableCollection<Loan>()
	{
		new("House Loan", PaymentTypes.Monthly , 10000000 , 1.5m, 5000),
		new("Car Loan", PaymentTypes.Quarterly, 100000, 3, 2000),
		new("Quick Loan", PaymentTypes.Monthly , 5000, 20, 1000)
	};

	public ObservableCollection<BankAccount> BankAccounts { get; } = new(BankUser.CurrentUser.BankAccounts);

	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	private Loan? _selectedLoan;
	public Loan? SelectedLoan
	{
		get => _selectedLoan;
		set
		{
			this.RaiseAndSetIfChanged(ref _selectedLoan, value);
			
			if (value != null)
			{
				InitialValue = value.InitialValue;
				PaymentType = value.PaymentType;
				Interest = value.Interest;
				CostForEachPayment = value.CostForEachPayment;
			}
			else
			{
				InitialValue = 0m;
				PaymentType = 0;
				Interest = 0m;
				CostForEachPayment = 0m;
			}
		}
	}

	private BankAccount? _selectedBankAccount;
	public BankAccount? SelectedBankAccount
	{
		get => _selectedBankAccount;
		set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
	}

	private bool _failTextIsVisible = false;
	public bool FailTextIsVisible
	{
		get => _failTextIsVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextIsVisible, value);
	}

	private decimal _initialValue;
	public decimal InitialValue
	{
		get => _initialValue;
		set => this.RaiseAndSetIfChanged(ref _initialValue, value);
	}

	private PaymentTypes _paymentType;
	public PaymentTypes PaymentType
	{
		get => _paymentType;
		set => this.RaiseAndSetIfChanged(ref _paymentType, value);
	}

	private decimal _interest;
	public decimal Interest
	{
		get => _interest;
		set => this.RaiseAndSetIfChanged(ref _interest, value);
	}

	private decimal _costForEachPayment;
	public decimal CostForEachPayment
	{
		get => _costForEachPayment;
		set => this.RaiseAndSetIfChanged(ref _costForEachPayment, value);
	}

	public CreateLoanPageViewModel(object? currentPage)
	{
		CurrentPage = currentPage;
		GoBackCommand = ReactiveCommand.Create(GoBack);
		CreateLoanCommand = ReactiveCommand.Create(CreateLoan);
	}

	private void GoBack() =>
		CurrentPage = new BankMainPage();

	private void CreateLoan()
	{
		if (SelectedBankAccount != null && SelectedLoan != null)
		{
			SelectedLoan.ChangePayDate();
			LoanDatabase.Instance.Insert(SelectedLoan, BankUser.CurrentUser.Id, SelectedBankAccount.Id);
			SelectedBankAccount.Balance += SelectedLoan.InitialValue;
			BankAccountDatabase.Instance.UpdateBalance(SelectedBankAccount.Id, SelectedBankAccount.Balance);

			SelectedLoan = null;
			SelectedBankAccount = null;

			FailTextIsVisible = false;
		}
		else
			FailTextIsVisible = true;
	}
}
