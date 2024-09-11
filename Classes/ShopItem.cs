using BankAccount.Database;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class ShopItem
{
	public int Id { get; private set; }
	public ShopItemType Name { get; private set; }
	public decimal Price { get; private set; }
	public int Amountbought => ShopItemDatabase.Instance.SelectCount(ShopUser.CurrentShopUser.Id, Name);
	public decimal TotalAmountSpent => Amountbought * Price;
	public ShopItemCategory Category { get; private set; }

	public static Dictionary<ShopItemType, ShopItem> ShopItemTypes = new()
	{
		{ShopItemType.Milk, new(ShopItemType.Milk, 11.95m) },
		{ShopItemType.Sugar, new(ShopItemType.Sugar, 9.95m) },
		{ShopItemType.Charger, new(ShopItemType.Charger, 40m) },
		{ShopItemType.Battery, new(ShopItemType.Sugar, 30m) },
		{ShopItemType.Chair, new(ShopItemType.Chair, 100m) },
		{ShopItemType.Car, new(ShopItemType.Car, 100000m) }
	};

	public ShopItem(int id, ShopItemType name, decimal price)
	{
		Id = id;
		Name = name;
		SetCategory();
		Price = price;
	}

	public ShopItem(ShopItemType name, decimal price)
	{
		Price = price;
		Name = name;
		SetCategory();
	}

	private void SetCategory()
	{
		switch (Name)
		{
			case ShopItemType.Milk or ShopItemType.Sugar:
				Category = ShopItemCategory.Food;
				break;
			case ShopItemType.Battery or ShopItemType.Charger:
				Category = ShopItemCategory.Electricity;
				break;
			case ShopItemType.Chair:
				Category = ShopItemCategory.Interior;
				break;
			case ShopItemType.Car:
				Category = ShopItemCategory.Cars;
				break;
		}
	}
}
