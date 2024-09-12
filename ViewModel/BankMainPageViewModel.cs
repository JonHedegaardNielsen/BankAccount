using BankAccount.Database;
using System.Collections.ObjectModel;

namespace BankAccount;

public class BankMainPageViewModel : ViewModel
{
	public ObservableCollection<BankAccount> bankAccounts { get; }
	private ShopItemCategory Category;

	private int _amountBought;
	public int AmountBought
	{
		get => _amountBought;
		set
		{
			if (_amountBought != value)
			{
				_amountBought = value;
				OnPropertyChanged(nameof(AmountBought));
			}
		}
	}

	private decimal _amountSpent;
	public decimal AmountSpent
	{
		get => _amountBought;
		set
		{
			if (-AmountSpent != value)
			{
				_amountSpent = value;
				OnPropertyChanged(nameof(AmountBought));
			}
		}
	}

	public BankMainPageViewModel()
	{
		bankAccounts = new(BankUser.CurrentUser.BankAccounts);
	}

	public BankMainPageViewModel(ShopItemCategory category)
	{
		Category = category;
		bankAccounts = new(BankUser.CurrentUser.BankAccounts);
		

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
				_amountBought = ShopItemDatabase.Instance.SelectCountItemCategory(SelectItem.Id, Category);
				_amountSpent = (decimal)ShopItemDatabase.Instance.GetTotalExpenses(SelectItem.Id);
				OnPropertyChanged(nameof(SelectItem));
			}
		}
	}
}
