using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public abstract class SignUpViewModel : ReactiveObject
{
	public ReactiveCommand<Unit, Unit> CreateUserCommand { get; }
	public ReactiveCommand<Unit, Unit> GoToLoginCommand { get; }
	protected Action OnGoToLogin { private get; set; }

	protected object _currentPage;
	public object CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	protected bool _failTextMatchingIsVisible = false;
	public bool FailTextMatchingIsVisible
	{
		get => _failTextMatchingIsVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextMatchingIsVisible, value);
	}

	protected bool _failTextLengthIsVisible = false;
	public bool FailtextLengthIsVisible
	{
		get => _failTextLengthIsVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextLengthIsVisible, value);
	}

	protected string _username = string.Empty;
	public string Username
	{
		get => _username;
		set => this.RaiseAndSetIfChanged(ref _username, value);
	}

	protected string _password = string.Empty;
	public string Password
	{
		get => _password;
		set => this.RaiseAndSetIfChanged(ref _password, value);
	}

	protected string _reInsertPassword = string.Empty;
	public string ReInsertPassword
	{
		get => _reInsertPassword;
		set => this.RaiseAndSetIfChanged(ref _reInsertPassword, value);
	}

	public SignUpViewModel(object? currentPage)
	{
		CurrentPage = currentPage;
		CreateUserCommand = ReactiveCommand.Create(SignUp);
		GoToLoginCommand = ReactiveCommand.Create(GoToLogin);
	}

	protected void SignUp()
	{
		FailtextLengthIsVisible = !Login.CheckLength(Password) || !Login.CheckLength(Username);
		FailTextMatchingIsVisible = Password != ReInsertPassword;
		
		if (FailTextMatchingIsVisible || FailtextLengthIsVisible)
			return;

		CreateUser();
		Password = string.Empty;
		Username = string.Empty;
		ReInsertPassword = string.Empty;
	}

	protected virtual void CreateUser()
	{
	}

	protected void GoToLogin()
	{
		if (OnGoToLogin != null)
			OnGoToLogin();

		CurrentPage = new LoginPage();
	}
}
