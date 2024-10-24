using BankAccount.Database;
using System.Collections.Generic;

namespace BankAccount;

public class ShopItem
{
	public int Id { get; private set; }
	public ShopItemType Name { get; private set; }
	public decimal Price { get; private set; }
	public int Amountbought => ShopItemDatabase.Instance.SelectCountItemType(ShopUser.CurrentUser.Id, Name);
	public decimal TotalAmountSpent => Amountbought * Price;
	public SpendingCategory Category { get; private set; }

	public static Dictionary<ShopItemType, ShopItem> ShopItemTypes = new()
	{
		{ShopItemType.Milk, new(ShopItemType.Milk, 11.95m) },
		{ShopItemType.Sugar, new(ShopItemType.Sugar, 9.95m) },
		{ShopItemType.Charger, new(ShopItemType.Charger, 40m) },
		{ShopItemType.Battery, new(ShopItemType.Battery, 30m) },
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

	public ShopItem(int id, ShopItemType name, decimal price, SpendingCategory category)
	{
		Id= id;
		Name = name;
		Price = price;
		Category = category;
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
				Category = SpendingCategory.Food;
				break;
			case ShopItemType.Battery or ShopItemType.Charger:
				Category = SpendingCategory.Electricity;
				break;
			case ShopItemType.Chair:
				Category = SpendingCategory.Interior;
				break;
			case ShopItemType.Car:
				Category = SpendingCategory.Cars;
				break;
		}
	}
}
