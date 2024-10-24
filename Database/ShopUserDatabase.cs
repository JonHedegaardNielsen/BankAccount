using System;
using System.Data.SqlClient;

namespace BankAccount;

class ShopUserDatabase : Database<ShopUser>, ILoginDatabase
{
	public static ShopUserDatabase Instance = new ShopUserDatabase();

	private ShopUserDatabase() { }

	public void CreateUser(string? username, string? password, int bankAccountId)
	{
		ExecuteNonQuery($"INSERT INTO shopUser(userName, password, bankAccountId) VALUES('{username}', '{password}', {bankAccountId})");
	}

	private ShopUser GetData(SqlDataReader sqlDataReader) =>
		new(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), new(sqlDataReader.GetInt32(4), sqlDataReader.GetString(5), sqlDataReader.GetDecimal(6)));

	public int SelectUserIdFromBankAccountId(int bankAccountId)
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

	public void DeleteUserFromUserId(int userId)
	{
		ShopItemDatabase.Instance.DeleteItemsFromUserId(userId);
		ExecuteNonQuery($"DELETE FROM shopUser WHERE userId = {userId}");
	}

	public void DeleteUserFromBankAccountId(int bankAccountId)
	{
		ShopItemDatabase.Instance.DeleteItemsFromUserId(SelectUserIdFromBankAccountId(bankAccountId));
		ExecuteNonQuery($"DELETE FROM shopUser WHERE bankAccountId = {bankAccountId}");
	}

	public bool FindUser(string? userName, string? password, out User? shopUser)
	{
		try
		{
			shopUser = RunSingleQuery($"SELECT TOP(1) * FROM shopUser u JOIN bankAccount b ON u.bankAccountId = b.bankAccountId WHERE u.userName COLLATE Latin1_General_BIN = '{userName}' AND u.password COLLATE Latin1_General_BIN = '{password}'", GetData);
			return true;
		}
		catch (InvalidOperationException)
		{
			shopUser = null;
			return false;
		}
	}
}
