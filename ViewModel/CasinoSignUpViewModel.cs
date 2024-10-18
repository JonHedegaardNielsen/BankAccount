using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Reactive.Linq;
using System.Windows.Input;

namespace BankAccount;

public class CasinoSignUpViewModel : SignUpViewModel
{
	private BankAccount? _selectedBankAccount;
	public BankAccount? SelectedBankAccount
	{
		get => _selectedBankAccount;
		set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
	}

	public CasinoSignUpViewModel(object? currentPage) : base(currentPage)
	{
		OnGoToLogin = () => BankUser.CurrentUser = null;
	}

	protected override void CreateUser()
	{
		if (_selectedBankAccount != null)
		{
			CasinoUserDatabase.Instance.CreateUser(Username, Password, _selectedBankAccount.Id);
			BankUser.CurrentUser = null;
		}
	}
}
