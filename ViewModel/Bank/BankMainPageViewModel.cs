using BankAccount.Database;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Reactive;
using System.Windows.Input;

namespace BankAccount;

public class BankMainPageViewModel : ReactiveObject
{

	public ObservableCollection<BankAccount> bankAccounts { get; }
	public ReactiveCommand<Unit, Unit> DeleteUserCommand { get; }
	public ReactiveCommand<Unit, Unit> LogOutCommand { get; }

	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}
	private BankAccount? _selecteditem;
	public BankAccount? SelectItem
	{
		get => _selecteditem;
		set => this.RaiseAndSetIfChanged(ref _selecteditem, value);
	}

	public BankMainPageViewModel(object? currentPage)
	{
		bankAccounts = new(BankUser.CurrentUser.BankAccounts);
		DeleteUserCommand = ReactiveCommand.Create(DeleteUser);
		LogOutCommand = ReactiveCommand.Create(Logout);
		CurrentPage = currentPage;
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
