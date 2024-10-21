using BankAccount.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class ShopUser : User
{
	private static ShopUser? _currentUser;
	public static ShopUser CurrentUser
	{
		get => (ShopUser)ValidateGetUser(_currentUser);
	}
	public BankAccount UserBankAccount { get; private set; }
	public List<ShopItem> ShopItems = new();

	public static bool IsLoggedIn => _currentUser != null;

	public ShopUser(int id, string userName, string password, BankAccount bankAccount) : base(id, userName, password)
	{
		UserBankAccount = bankAccount;
	}

	public static bool Login(string? userName, string? password)
	{
		if (ShopUserDatabase.Instance.FindUser(userName, password, out User? shopuser))
			_currentUser = (ShopUser?)shopuser;
		
		return _currentUser != null;
	}

	public void BuyItem(ShopItemType itemType)
	{
		ShopItem item = ShopItem.ShopItemTypes[itemType];

		if (item.Price <= UserBankAccount.Balance)
		{
			UserBankAccount.Balance -= item.Price;
			ShopItemDatabase.Instance.Insert(new(item.Name, item.Price), this);
			BankAccountDatabase.Instance.UpdateBalance(CurrentUser.UserBankAccount.Id, CurrentUser.UserBankAccount.Balance);
		}
	}

	public void LogOut()
	{
		_currentUser = null;
	}
}
