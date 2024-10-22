using BankAccount.Database;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
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



	public BankMainPageViewModel(object? currentPage)
	{
		BankAccounts = new(BankUser.CurrentUser.BankAccounts);

		foreach (BankAccount bankAccount in BankUser.CurrentUser.BankAccounts)
			BankAccountControls.Add(new BankAccountControl(bankAccount));

		foreach (Loan loan in BankUser.CurrentUser.Loans)
			LoanControls.Add(new(loan));

		DeleteUserCommand = ReactiveCommand.Create(DeleteUser);
		LogOutCommand = ReactiveCommand.Create(Logout);
		TransferMoneyCommand = ReactiveCommand.Create(TranferMoney);
		CurrentPage = currentPage;
	}

	private void TransferMoneyToOtherUser() 
	{ 
		if (BankAccountToTransferFrom != null && BankAccountToTransferTo != null)
			BankAccountToTransferTo.Transfer(AmountToTransferDecimal, BankAccountToTransferFrom);
	}

	private void TransferToCurrentUserBankAccount()
	{
		
	}

	private void TranferMoney()
	{
		
		if (TransferToOtherUser)
		{
			TransferMoneyToOtherUser();
		}
		else
		{
			TransferToCurrentUserBankAccount();
		}
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
}
