using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BankAccount;

class TransactionDatabase : Database<decimal>
{
	public static TransactionDatabase Instance = new();

	private TransactionDatabase() { }

	public void Insert(ShopItem shopItem, int userId) =>
		ExecuteNonQuery($"INSERT INTO transactions(category, price, userId) VALUES({(int)shopItem.Category}, {shopItem.Price}, {userId})");

	public decimal GetTotalExpensesOfCategory(SpendingCategory category)
	{
		try
		{
			return RunSingleQuery($"SELECT SUM(price) FROM transactions WHERE category = {category}", r => r.GetDecimal(0));
		}
		catch (SqlNullValueException)
		{
			return 0m;
		}
	}


}
