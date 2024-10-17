using BankAccount.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class ShopUser : User
{
	public static ShopUser? CurrentShopUser { get; set; }
	public BankAccount UserBankAccount { get; private set; }
	public List<ShopItem> ShopItems = new();

	public ShopUser(int id, string userName, string password, BankAccount bankAccount) : base(id, userName, password)
	{
		UserBankAccount = bankAccount;
	}

	public static bool Login(string? userName, string? password)
	{
		//if (ShopUserDatabase.Instance.FindUser(userName, password, out ShopUser? shopuser))
		//	CurrentShopUser = shopuser;
		
		return CurrentShopUser != null;
	}

	public void BuyItem(ShopItemType itemType)
	{
		ShopItem item = ShopItem.ShopItemTypes[itemType];
		if (item.Price <= UserBankAccount.Balance)
		{
			UserBankAccount.Balance -= item.Price;
			ShopItemDatabase.Instance.Insert(new(item.Name, item.Price), Id);
			BankAccountDatabase.Instance.UpdateBalance(CurrentShopUser.UserBankAccount.Id, CurrentShopUser.UserBankAccount.Balance);
		}
	}

	public void LogOut()
	{
		CurrentShopUser = null;
	}
}
