using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankAccountContolViewModel : ReactiveObject
{
	public ReactiveCommand<Unit, Unit> CreateBankAccountCommand { get; }
	public ReactiveCommand<Unit, Unit> GoBackCommand { get; }
	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	private string _bankAccountName = String.Empty;
	public string BankAccountName
	{
		get => _bankAccountName;
		set => this.RaiseAndSetIfChanged(ref _bankAccountName, value);
	}

	private bool _failTextIsVisible = false;
	public bool FailTextIsVisible
	{
		get => _failTextIsVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextIsVisible, value);
	}
    public BankAccountContolViewModel(object? currentpage)
    {
		CurrentPage = currentpage;
		CreateBankAccountCommand = ReactiveCommand.Create(CreateBankAccout);
		GoBackCommand = ReactiveCommand.Create(GoBack);
    }

	private void CreateBankAccout()
	{
		if (!String.IsNullOrWhiteSpace(BankAccountName))
		{
			BankAccountDatabase.Instance.Insert(BankUser.CurrentUser.Id, BankAccountName, 0);
			BankAccountName = String.Empty;
			FailTextIsVisible = false;
		}
		else
			FailTextIsVisible = true;
	}

	private void GoBack() =>
		CurrentPage = new BankMainPage();

}
