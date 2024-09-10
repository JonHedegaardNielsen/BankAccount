using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankAccount.Database;

class ShopItemDatabase : Database<ShopItem>
{
	public static ShopItemDatabase Instance = new ShopItemDatabase();

	private ShopItemDatabase() { }

	public ShopItem GetData(SqlDataReader sqlDataReader) =>
		new(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetDecimal(2));

	public List<ShopItem> GetShopItems(int userId) =>
		RunQuery($"SELECT * FROM shopItem WHERE userId = {userId}", GetData);

	public void Insert(ShopItem shopItem, int userId)
	{
		ExecuteNonQuery($"INSERT INTO shopItem([name], price, userId) VALUES('{shopItem.Name}', {shopItem.Price}, {userId})");
	}
}
