using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class LoginPageViewmodel : ReactiveObject
{
	public ReactiveCommand<Unit, Unit> CasinoLoginCommand { get; private set; }
	public ReactiveCommand<Unit, Unit> ShopLoginCommand { get; private set; }
	public ReactiveCommand<Unit, Unit> BankLoginCommand { get; private set; }
	public ReactiveCommand<Unit, Unit> ShopSignUpCommand { get; private set; }
	public ReactiveCommand<Unit, Unit> CasinoSignUpCommand { get; private set; }
	public ReactiveCommand<Unit, Unit> BankSignUpCommand { get; private set; }
	private Func<UserControl>? GetNextPageForBank;

	private bool _signUpBankIsVisible = true;
	public bool SignUpBankIsVisible => _signUpBankIsVisible;

	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	private bool _casinoFailTextIsVisible = false;
	public bool CasinoFailTextIsVisible
	{
		get => _casinoFailTextIsVisible;
		set => this.RaiseAndSetIfChanged(ref _casinoFailTextIsVisible, value);
	}

	private bool _shopFailTextIsVisible = false;
	public bool ShopFailTextIsVisible
	{
		get => _shopFailTextIsVisible;
		set => this.RaiseAndSetIfChanged(ref _shopFailTextIsVisible, value);
	}

	private bool _bankFailTextIsVisible = false;
	public bool BankFailTextIsVisible
	{
		get => _bankFailTextIsVisible;
		set => this.RaiseAndSetIfChanged(ref _bankFailTextIsVisible, value);
	}

	private string _bankPassword = string.Empty;
	public string BankPassword
	{
		get => _bankPassword;
		set => this.RaiseAndSetIfChanged(ref _bankPassword, value);
	}

	private string _bankUsername = string.Empty;
	public string BankUsername
	{
		get => _bankUsername;
		set => this.RaiseAndSetIfChanged(ref _bankUsername, value);
	}
	private string _shopPassword = string.Empty;
	public string ShopPassword
	{
		get => _shopPassword;
		set => this.RaiseAndSetIfChanged(ref _shopPassword, value);
	}

	private string _shopUsername = string.Empty;
	public string ShopUsername
	{
		get => _shopUsername;
		set => this.RaiseAndSetIfChanged(ref _shopUsername, value);
	}
	private string _casinoPassword = string.Empty;
	public string CasinoPassword
	{
		get => _casinoPassword;
		set => this.RaiseAndSetIfChanged(ref _casinoPassword, value);
	}

	private string _casinoUsername = string.Empty;
	public string CasinoUsername
	{
		get => _casinoUsername;
		set => this.RaiseAndSetIfChanged(ref _casinoUsername, value);
	}
	private object? _currentbankLoginPage;
	public object? CurrentbankLoginPage
	{
		get => _currentbankLoginPage;
		set => this.RaiseAndSetIfChanged(ref _currentbankLoginPage, value);
	}

    public LoginPageViewmodel(object? currentPage, object? currentbankLoginPage, bool signUpViewModel = true, Func<UserControl>? getNextPageForBank = null)
    {
		CurrentPage = currentPage;
		_signUpBankIsVisible = signUpViewModel;
		CurrentbankLoginPage = currentbankLoginPage;
		GetNextPageForBank = getNextPageForBank;

		CasinoLoginCommand = ReactiveCommand.Create(CasinoLogin);
		ShopLoginCommand = ReactiveCommand.Create(ShopLogin);
		BankLoginCommand = ReactiveCommand.Create(BankLogin);
		ShopSignUpCommand = ReactiveCommand.Create(ShopSignup);
		CasinoSignUpCommand = ReactiveCommand.Create(CasinoSignUp);
		BankSignUpCommand = ReactiveCommand.Create(BankSignup);
	}

    private void CasinoLogin()
	{
		if(CasinoUser.Login(CasinoUsername, CasinoPassword))
		{
			CurrentPage = new CasinoMainPage();
			return;
		}

		CasinoFailTextIsVisible = true;
	}

	private void ShopLogin()
	{
		if (ShopUser.Login(ShopUsername, ShopPassword))
		{
			CurrentPage = new ShopMainPage();
			return;
		}

		ShopFailTextIsVisible = true;
	}

	private void BankLogin()
	{
		if (BankUser.Login(BankUsername, BankPassword))
		{
			if (GetNextPageForBank == null)
				CurrentPage = new BankMainPage();
			else 
				CurrentbankLoginPage = GetNextPageForBank();

			return;
		}

		BankFailTextIsVisible = true;
	}

	private  bool Login(string username, string password, ILoginDatabase database, out User? user) =>
		database.FindUser(username, password, out user);

	private void BankSignup() =>
		CurrentPage = new BankSignupPage();

	private void ShopSignup() =>
		CurrentPage = new BankLoginPage(()=> new ShopSignUpPage(), CurrentPage);

	private void CasinoSignUp() =>
		CurrentPage = new BankLoginPage(() => new CasinoSignUpPage(), CurrentPage);
}
