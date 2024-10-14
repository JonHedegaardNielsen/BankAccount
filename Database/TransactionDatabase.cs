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

	public void Insert(decimal price, SpendingCategory category, int userId) =>
		ExecuteNonQuery($"INSERT INTO transactions(category, price, userId) VALUES({(int)category}, {FormatDecimal(price)}, {userId})");

	public decimal GetUserExpensesOfCategory(SpendingCategory category, int userId)
	{
		try
		{
			return RunSingleQuery($"SELECT TOP(1) SUM(price) FROM transactions WHERE category = {(int)category} AND userId = {userId}", r => r.GetDecimal(0));
		}
		catch (SqlNullValueException)
		{
			return 0m;
		}
	}

	

	public void DeleteFromUserId(int userId) =>
		ExecuteNonQuery($"DELETE transactions WHERE userId = {userId}");

	public int GetCategoryCount(SpendingCategory category, int userId)
	{
		try
		{
			return RunSingleQuery($"SELECT TOP(1) COUNT(*) FROM transactions WHERE category = {(int)category} AND userId = {userId}", r => r.GetInt32(0));
		}
		catch (SqlNullValueException)
		{
			return 0;
		}
	}
}
