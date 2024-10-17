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

public class CasinoSignUpViewModel : ReactiveObject
{
	
	public ReactiveCommand<Unit, Unit> CreateUserCommand { get; }

	private object _currentPage;
	public object CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	private BankAccount _selectedBankAccount;
	public BankAccount SelectedBankAccount
	{
		get => _selectedBankAccount;
		set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
	}

	private bool _failTextMatchingIsVisible = false;
	public bool FailTextMatchingIsVisible
	{
		get => _failTextMatchingIsVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextMatchingIsVisible, value);
	}

	private bool _failTextLengthIsVisible = false;
	public bool FailtextLengthIsVisible
	{
		get => _failTextLengthIsVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextLengthIsVisible, value);
	}

	private string _username = string.Empty;
	public string Username
	{
		get => _username;
		set => this.RaiseAndSetIfChanged(ref _username, value);
	}

	private string _password = string.Empty;
	public string Password
	{
		get => _password;
		set => this.RaiseAndSetIfChanged(ref _password, value);
	}

	private string _reInsertPassword = string.Empty;
	public string ReInsertPassword
	{
		get => _password;
		set => this.RaiseAndSetIfChanged(ref _reInsertPassword, value);
	}

	public CasinoSignUpViewModel(object? currentPage)
	{
		CurrentPage = currentPage;
		
		CreateUserCommand = ReactiveCommand.Create(CreateUser);
	}

	private void CreateUser()
	{
		FailtextLengthIsVisible = !Login.CheckLength(Password) && !Login.CheckLength(Username);
		FailTextMatchingIsVisible = Password != ReInsertPassword;

		if (!FailTextMatchingIsVisible || !FailtextLengthIsVisible && SelectedBankAccount != null)
		{
			CasinoUserDatabase.Instance.CreateUser(Username, Password, SelectedBankAccount.Id);
			CurrentPage = new LoginPage();
		}
	}
}
