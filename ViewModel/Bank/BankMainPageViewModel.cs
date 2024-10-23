using Avalonia;
using Avalonia.Controls;
using BankAccount.Database;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BankAccount;

public class BankMainPageViewModel : ReactiveObject
{
	public ObservableCollection<LoanControl> LoanControls { get; } = new();
	public ObservableCollection<BankAccountControl> BankAccountControls { get; } = new();
	public ObservableCollection<BankAccount> BankAccounts { get; }
	public ReactiveCommand<Unit, Unit> DeleteUserCommand { get; }
	public ReactiveCommand<Unit, Unit> LogOutCommand { get; }
	public ReactiveCommand<Unit, Unit> TransferMoneyCommand { get; }
	public ReactiveCommand<Unit, Unit> CreateLoanCommand { get; }
	public ReactiveCommand<Unit, Unit> CreateBankAccountCommand { get; }

	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	

	private BankAccount? _bankAccountToTransferFrom;
	public BankAccount? BankAccountToTransferFrom
	{
		get => _bankAccountToTransferFrom;
		set => this.RaiseAndSetIfChanged(ref _bankAccountToTransferFrom, value);
	}

	private BankAccount? _bankAccountToTransferTo;
	public BankAccount? BankAccountToTransferTo
	{
		get => _bankAccountToTransferTo;
		set => this.RaiseAndSetIfChanged(ref _bankAccountToTransferTo, value);
	}

	private bool _transferToOtherUser;
	public bool TransferToOtherUser
	{
		get => _transferToOtherUser;
		set => _transferToOtherUser = value;
	}

	private bool _transferFailTextIsVisible = false;
	public bool TransferFailTextIsVisible
	{
		get => _transferFailTextIsVisible;
		set => this.RaiseAndSetIfChanged(ref _transferFailTextIsVisible, value);
	}

	private bool _transferAmountFailText = false;
	public bool TransferAmountFailText
	{
		get => _transferAmountFailText;
		set => this.RaiseAndSetIfChanged(ref _transferAmountFailText, value);
	}

	private decimal AmountToTransferDecimal
	{
		get => !String.IsNullOrWhiteSpace(_amountToTransferString) ? decimal.Parse(_amountToTransferString) : 0;
		set => AmountToTransfer = value.ToString();
	}

	private string _amountToTransferString = string.Empty;
	public string AmountToTransfer
	{
		get => _amountToTransferString != null ? _amountToTransferString.ToString() : String.Empty;
		set => this.RaiseAndSetIfChanged(ref _amountToTransferString, value);
	}

	private int AccountIdToTransferToInt
	{
		get => !String.IsNullOrEmpty(_accountIdToTransferTo) ? int.Parse(_accountIdToTransferTo) : 0;
		set => AccountIdToTransferTo = value.ToString();
	}

	private string _accountIdToTransferTo = string.Empty;
	public string AccountIdToTransferTo
	{
		get => _accountIdToTransferTo != null ? _accountIdToTransferTo.ToString() : String.Empty;
		set => this.RaiseAndSetIfChanged(ref _accountIdToTransferTo, value);
	}

	public BankMainPageViewModel(object? currentPage)
	{
		BankAccounts = new(BankUser.CurrentUser.BankAccounts);

		foreach (BankAccount bankAccount in BankAccounts)
			BankAccountControls.Add(new BankAccountControl(bankAccount));

		foreach (Loan loan in BankUser.CurrentUser.Loans)
			LoanControls.Add(new(loan));

		DeleteUserCommand = ReactiveCommand.Create(DeleteUser);
		LogOutCommand = ReactiveCommand.Create(Logout);
		TransferMoneyCommand = ReactiveCommand.Create(TransferMoney);
		CreateLoanCommand = ReactiveCommand.Create(CrateLoan);
		CreateBankAccountCommand = ReactiveCommand.Create(CreateBankAccount);

		CurrentPage = currentPage;
	}

	private void TransferMoney()
	{
		if (BankAccountToTransferFrom != null && BankAccountToTransferTo != null || AccountIdToTransferToInt != 0)
		{
			TransferFailTextIsVisible = false;

			BankAccount bankAccountToTransferTo;
			if (TransferToOtherUser)
				bankAccountToTransferTo = BankAccountDatabase.Instance.GetSingleBankAccount(AccountIdToTransferToInt);
			else
				bankAccountToTransferTo = BankAccountToTransferTo;

			if (bankAccountToTransferTo.Transfer(AmountToTransferDecimal, BankAccountToTransferFrom))
			{
				if (!TransferToOtherUser)
				{
					int bankAccountToTransferToIndex = BankAccounts.IndexOf(BankAccountToTransferTo);
					BankAccountControls[bankAccountToTransferToIndex] = new(BankAccountToTransferTo);
				}

				int bankAccountToTransferFromIndex = BankAccounts.IndexOf(BankAccountToTransferFrom);
				BankAccountControls[bankAccountToTransferFromIndex] = new(BankAccountToTransferFrom);

				TransferAmountFailText = false;
			}
			else
				TransferAmountFailText = true;
		}
		else 
			TransferFailTextIsVisible = true;
	}

	private void DeleteUser()
	{
		BankUserDatabase.Instance.DeleteCurrentUser();
		BankUser.LogOut();
		CurrentPage = new LoginPage();
	}

	private void Logout()
	{
		BankUser.LogOut();
		CurrentPage = new LoginPage();
	}

 	private void CrateLoan() =>
		CurrentPage = new CreateLoanPage();

	private void CreateBankAccount() =>
		CurrentPage = new CreateBankAccountPage();

}
