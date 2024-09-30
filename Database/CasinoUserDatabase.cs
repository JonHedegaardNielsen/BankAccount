using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class CasinoUserDatabase : Database<CasinoUser?>
{
	public static CasinoUserDatabase Instance = new CasinoUserDatabase();

	private CasinoUser? GetData(SqlDataReader reader) =>
		new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new(reader.GetInt32(4), reader.GetString(5), reader.GetDecimal(6)));

	public CasinoUser? FindUser(string username, string password) =>
		RunSingleQuery($"SELECT TOP(1) * FROM casinoUser u JOIN bankAccount b ON u.bankAccountId = b.bankAccountId WHERE u.username COLLATE Latin1_General_BIN = {username} AND u.[password] COLLATE Latin1_General_BIN = {password}", GetData);

	public bool CreateUser(string username, string password)
	{
		try
		{
			ExecuteNonQuery("INSERT INTO casinoUser(username, [password], bankAccountId) VALUES()")
		}
		catch(InvalidOperationException ex)
		{
			return false;
		}
	}
}
