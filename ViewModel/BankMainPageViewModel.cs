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
	private SpendingCategory Category;
	public ReactiveCommand<Unit, Unit> DeleteUserCommand { get; }
	
	public SpendingCategory CarCategory => SpendingCategory.Cars;
	public BankMainPageViewModel()
	{
		bankAccounts = new(BankUser.CurrentUser.BankAccounts);
	}

	public BankMainPageViewModel(SpendingCategory category)
	{
		Category = category;
		bankAccounts = new(BankUser.CurrentUser.BankAccounts);
	}

	public void DeleteUser()
	{
		BankUserDatabase.Instance.DeleteCurrentUser();
		BankUser.LogOut();
	}

	private BankAccount? _selecteditem;
	public BankAccount? SelectItem
	{
		get => _selecteditem;
		set => this.RaiseAndSetIfChanged(ref _selecteditem, value);
	}
}
