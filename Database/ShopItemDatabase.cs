﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BankAccount.Database;

class ShopItemDatabase : Database<ShopItem>
{
	public static ShopItemDatabase Instance = new ShopItemDatabase();

	private ShopItemDatabase() { }

	public ShopItem GetData(SqlDataReader sqlDataReader) =>
		new(sqlDataReader.GetInt32(0), (ShopItemType)sqlDataReader.GetValue(1), sqlDataReader.GetDecimal(2), (ShopItemCategory)sqlDataReader.GetValue(4));

	public List<ShopItem> GetShopItems(int userId) =>
		RunQuery($"SELECT * FROM shopItem WHERE userId = {userId}", GetData);

	public void Insert(ShopItem shopItem, int userId)
	{
		ExecuteNonQuery($"INSERT INTO shopItem([name], price, userId, category) VALUES('{shopItem.Name}', {FormatDecimal(shopItem.Price)}, {userId}, {(int)shopItem.Category})");
	}

	public int SelectCountItemType(int userId, ShopItemType shopItemType) =>
		RunSingleQuery($"SELECT COUNT(*) FROM shopItem WHERE userId = {userId} AND [name] = '{shopItemType}'", GetCount);

	public void DeleteItemsFromUserId(int userId)
	{
		ExecuteNonQuery($"DELETE FROM shopItem WHERE userId = {userId}");
	}

	public int GetUserId(int bankAccountId)
	{
		try
		{
			return RunSingleQuery($"SELECT userId FROM shopUser WHERE bankAccountId = {bankAccountId}", r => r.GetInt32(0));
		}
		catch (InvalidOperationException)
		{
			return 0;
		}

	}

	public int SelectCountItemCategory(int bankAccountId, ShopItemCategory category) =>
		RunSingleQuery($"SELECT COUNT(*) FROM shopItem WHERE category = {(int)category} AND userId = {GetUserId(bankAccountId)}", GetCount);

	public decimal GetTotalExpensesofCategory(int bankAccountId, ShopItemCategory category)
	{
		try
		{
			return RunSingleQuery<decimal>($"SELECT SUM(price) FROM shopitem WHERE userId = {GetUserId(bankAccountId)} AND category = {(int)category}", r => r.GetDecimal(0));
		}
		catch (SqlNullValueException)
		{
			return 0;
		}
	}

}
