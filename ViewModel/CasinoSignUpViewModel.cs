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

namespace BankAccount;

public class CasinoSignUpViewModel : ReactiveObject
{
	public ReactiveCommand<BankAccount, Tuple<bool, bool>> CreateUserCommand { get; }

	private BankAccount _selectedBankAccount;

	public BankAccount SelectedBankAccount
	{
		get => _selectedBankAccount;
		set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
	}

	public CasinoSignUpViewModel(TextBox password, TextBox reInsertPassword)
	{
		CreateUserCommand = ReactiveCommand.Create((BankAccount bankAccount) =>
		{
			Tuple<bool, bool> fails = null;

			Dispatcher.UIThread.Post(() =>
			{
				fails = new Tuple<bool, bool>(password.Text == reInsertPassword.Text, Login.CheckLength(password.Text));

				if (fails.Item1 && fails.Item2)
					CasinoUserDatabase.Instance.CreateUser(password.Text, reInsertPassword.Text, SelectedBankAccount.Id);
			});
			return fails;

		});


	}
}
