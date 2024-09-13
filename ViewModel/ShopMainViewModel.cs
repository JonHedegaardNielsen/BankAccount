using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
namespace BankAccount;

public class ShopMainViewModel : ViewModel
{
	private ShopItemType _itemType;
	private decimal _itemPrice;
	public decimal ItemPrice => _itemPrice;
	public ShopItemType ItemType
	{
		private get => _itemType;
		set
		{
			if (_itemType != value)
			{
				_itemType = value;
				_itemPrice = ShopItem.ShopItemTypes[value].Price;
				OnPropertyChanged(nameof(ItemPrice));
				OnPropertyChanged(nameof(ItemType));
			}
		}
	}

	public decimal Balance => ShopUser.CurrentShopUser.UserBankAccount.Balance;

	public ICommand BuyItemCommand { get; }

    public ShopMainViewModel()
    {
		BuyItemCommand = new RelayCommand(BuyItem);
    }

	public void BuyItem(object Parameter)
	{
		if (Parameter is string type)
		{
			ShopUser.CurrentShopUser.BuyItem((ShopItemType)Enum.Parse(typeof(ShopItemType), type));
			OnPropertyChanged(nameof(Balance));
			((RelayCommand)BuyItemCommand).RaiseCanExecuteChanged();
		}
	}
}
