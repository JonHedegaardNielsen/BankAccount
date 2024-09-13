using BankAccount.Database;
using System;
using System.ComponentModel;
namespace BankAccount;

public class ShopItemCategoryViewModel : ViewModel
{
	private ShopItemCategory _category;
	public ShopItemCategory Category
	{
		get => _category;
		set
		{
			if (value != _category)
			{
				_category = value;
				OnPropertyChanged(nameof(Category));
			}
		}
	}

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
		get => _amountSpent;
		set
		{
			if (_amountSpent != value)
			{
				_amountSpent = value;
				OnPropertyChanged(nameof(AmountSpent));
			}
		}
	}

    public ShopItemCategoryViewModel(ShopItemCategory category)
    {
        Category = category;
    }

	public void UpdateData(int bankAccountId)
	{
		AmountBought = ShopItemDatabase.Instance.SelectCountItemCategory(bankAccountId, Category);
		AmountSpent = ShopItemDatabase.Instance.GetTotalExpensesofCategory(bankAccountId, Category);
	}

}
