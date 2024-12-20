﻿using System;
using System.Data.SqlClient;

namespace BankAccount;

class CasinoUserDatabase : Database<CasinoUser>, ILoginDatabase
{
	public static CasinoUserDatabase Instance = new CasinoUserDatabase();

	private CasinoUser? GetData(SqlDataReader reader)
	{
		try
		{
			return new CasinoUser(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new BankAccount(reader.GetInt32(5), reader.GetString(6), reader.GetDecimal(7)), reader.GetDecimal(4));
		}
		catch
		{
			return null;
		}
	}

	public decimal GetAmountToWinBack(CasinoUser casinoUser)
	{
		int userId = BankUserDatabase.Instance.GetUserIdFromBankAccountId(casinoUser.BankAccount.Id);
		return CasinoWinsDatabase.Instance.GetTotalRewards(userId) - TransactionDatabase.Instance.GetUserExpensesOfCategory(SpendingCategory.Gambling, userId);
	}

	private int GetUserIdFromBankAccountId(int bankAccountId)
	{
		try
		{
			return RunSingleQuery($"SELECT TOP(1) userId FROM casinoUser WHERE bankAccountId = {bankAccountId}", r => r.GetInt32(0));
		}
		catch (InvalidOperationException)
		{
			return 0;
		}
	}

	public void DeleteUserFromBankAccountId(int bankAccountId)
	{
		int userId = GetUserIdFromBankAccountId(bankAccountId);

		if (userId == 0)
			CasinoWinsDatabase.Instance.DeleteFromUserId(userId);

		ExecuteNonQuery($"DELETE casinoUser WHERE bankAccountId = {bankAccountId}");
	}


	public bool FindUser(string username, string password, out User? user)
	{
		try
		{
			user = RunSingleQuery($"SELECT TOP(1) * FROM casinoUser u JOIN bankAccount b ON u.bankAccountId = b.bankAccountId WHERE u.username COLLATE Latin1_General_BIN = '{username}' AND u.[password] COLLATE Latin1_General_BIN = '{password}'", GetData);
		}
		catch (InvalidOperationException)
		{
			user = null;
		}

		return user != null;
	}

	public void UpdateAmountToWinBack(decimal amount, int userId) =>
		ExecuteNonQuery($"UPDATE casinoUser SET amountToWinBack={FormatDecimal(amount)} WHERE userId = {userId}");

	public void DeleteUser(int userId)
	{
		CasinoWinsDatabase.Instance.DeleteFromUserId(userId);
		ExecuteNonQuery($"DELETE casinoUser WHERE userId = {userId}");
	}

	public bool CreateUser(string username, string password, int bankAccountId)
	{
		try
		{
			ExecuteNonQuery($"INSERT INTO casinoUser(username, [password], bankAccountId) VALUES('{username}', '{password}', {bankAccountId})");
			return true;
		}
		catch (InvalidOperationException)
		{
			return false;
		}
	}
}
