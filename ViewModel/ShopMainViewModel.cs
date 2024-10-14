using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using ReactiveUI;
using System.Reactive;
using System.Reflection.Metadata;
namespace BankAccount;

public class ShopMainViewModel : ReactiveObject
{
	private ShopItemType _itemType;
	private decimal _itemPrice;
	public decimal ItemPrice
	{
		get => _itemPrice;
		set => this.RaiseAndSetIfChanged(ref _itemPrice, value);
	}

	public ShopItemType ItemType
	{
		get => _itemType;
		set
		{
			this.RaiseAndSetIfChanged(ref _itemType, value);
			ItemPrice = ShopItem.ShopItemTypes[value].Price;
		}
	}

	private decimal _balance = ShopUser.CurrentShopUser.UserBankAccount.Balance;
	public decimal Balance
	{
		get => ShopUser.CurrentShopUser.UserBankAccount.Balance;
		set => this.RaiseAndSetIfChanged(ref _balance, value);
	}
	public ReactiveCommand<string,Unit> BuyItemCommand { get; }

	public ShopMainViewModel()
	{
		BuyItemCommand = ReactiveCommand.Create<string>(parameter =>
		{
			ShopUser.CurrentShopUser.BuyItem((ShopItemType)Enum.Parse(typeof(ShopItemType), parameter));
		});
	}

	public void DeleteCurrentUser()
	{
		ShopUserDatabase.Instance.DeleteUserFromUserId(ShopUser.CurrentShopUser.Id);
		ShopUser.CurrentShopUser.LogOut();
	}
}
