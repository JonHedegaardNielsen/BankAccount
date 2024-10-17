using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankSignupPageViewModel : ReactiveObject
{
    public ReactiveCommand<Unit,  Unit> SignUpCommand { get; }
    public ReactiveCommand<Unit, Unit> GoBackCommand { get; }

    private object? _currentPage;
    public object? CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

	private bool _failTextMatchingIsVisible;
    public bool FailTextMatchingIsVisible
    {
        get => _failTextMatchingIsVisible;
        set => this.RaiseAndSetIfChanged(ref _failTextMatchingIsVisible, value);
    }

    private bool _failTextLengthIsVisible;
    public bool FailTextLengthIsVisible
    {
        get => _failTextLengthIsVisible;
        set => this.RaiseAndSetIfChanged(ref _failTextLengthIsVisible, value);
    }

    private string _userName;
    public string UserName
    {
        get => _userName;
        set => this.RaiseAndSetIfChanged(ref _userName, value);
    }
    
    private string _password;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    private string _reInsertPassword;
    public string ReInsertPassword
    {
        get => _reInsertPassword;
        set => this.RaiseAndSetIfChanged(ref _reInsertPassword, value);
    }

    public BankSignupPageViewModel(object? currentPage)
    {
        CurrentPage = currentPage;
        GoBackCommand = ReactiveCommand.Create(GoBack);
        SignUpCommand = ReactiveCommand.Create(SignUp);
    }

    private void SignUp()
    {
        FailTextLengthIsVisible = !Login.CheckLength(Password) || !Login.CheckLength(UserName);
        FailTextMatchingIsVisible = Password != ReInsertPassword;

        if (!FailTextLengthIsVisible && !FailTextMatchingIsVisible)
        {
            BankUserDatabase.Instance.CreateUser(UserName, Password);
            Password = string.Empty;
            UserName = string.Empty;
            ReInsertPassword = string.Empty;
        }
    }

    private void GoBack()
    {
        CurrentPage = new LoginPage();
    }
}
