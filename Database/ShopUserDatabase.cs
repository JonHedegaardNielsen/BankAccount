﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class ShopUserDatabase : Database<ShopUser>
{
	public static ShopUserDatabase Instance = new ShopUserDatabase();

	public void CreateUser(string username, string password)
	{
		ExecuteNonQuery($"INSERT INTO shopUser(userName, password) VALUES('{username}', '{password}')");
	}

	private ShopUser GetData(SqlDataReader sqlDataReader) =>
		new(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), new(sqlDataReader.GetInt32(4), sqlDataReader.GetString(5), sqlDataReader.GetDecimal(6)));

	public bool FindUser(string userName, string password, out ShopUser? shopUser)
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