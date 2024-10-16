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
	public ReactiveCommand<Unit, Unit> CasinoLoginCommand { get; set; }
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

	private string _bankPassword;
	public string BankPassword
	{
		get => _bankPassword;
		set => this.RaiseAndSetIfChanged(ref _bankPassword, value);
	}

	private string _bankUsername;
	public string BankUsername
	{
		get => _bankUsername;
		set => this.RaiseAndSetIfChanged(ref _bankUsername, value);
	}
	private string _shopPassword;
	public string ShopPassword
	{
		get => _shopPassword;
		set => this.RaiseAndSetIfChanged(ref _shopPassword, value);
	}

	private string _shopUsername;
	public string ShopUsername
	{
		get => _shopUsername;
		set => this.RaiseAndSetIfChanged(ref _shopUsername, value);
	}
	private string _casinoPassword;
	public string CasinoPassword
	{
		get => _casinoPassword;
		set => this.RaiseAndSetIfChanged(ref _casinoPassword, value);
	}

	private string _casinoUsername;
	public string CasinoUsername
	{
		get => _casinoUsername;
		set => this.RaiseAndSetIfChanged(ref _casinoUsername, value);
	}

	public LoginPageViewmodel(object? currentPage)
	{
		CurrentPage = currentPage;
		CasinoLoginCommand = ReactiveCommand.Create(CasinoLogin);
	}

	private void CasinoLogin()
	{
		if(Login(CasinoPassword, CasinoUsername, CasinoUserDatabase.Instance, out User? user))
		{
			CasinoUser.CurrentUser = (CasinoUser?)user;
			CurrentPage = new CasinoMainPage();
			return;
		}

		CasinoFailTextIsVisible = true;
	}

	public bool Login(string password, string username, ILoginDatabase database, out User? user)
	{
		return database.FindUser(username, password, out user);
	}
}
