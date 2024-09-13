using BankAccount.Database;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Windows.Input;

namespace BankAccount;

public class BankMainPageViewModel : ViewModel
{
	public ObservableCollection<BankAccount> bankAccounts { get; }
	private ShopItemCategory Category;
	public ICommand DeleteUserCommand { get; }
	

	public BankMainPageViewModel()
	{
		bankAccounts = new(BankUser.CurrentUser.BankAccounts);
	}

	public BankMainPageViewModel(ShopItemCategory category)
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
		set
		{
			if (_selecteditem != value)
			{
				_selecteditem = value;

				OnPropertyChanged(nameof(SelectItem));
			}
		}
	}
}
