using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class CasinoWinsDatabase : Database<decimal?>
{
	public static readonly CasinoWinsDatabase Instance = new();

	private CasinoWinsDatabase() { }

	private decimal GetReward(SqlDataReader reader)
	{
		try
		{
			return reader.GetDecimal(0);
		}
		catch
		{
			return 0m;
		}
	}

	public decimal GetTotalRewards(int userId) =>
		RunSingleQuery($"SELECT SUM(reward) FROM casinoWins WHERE userId = {userId}", GetReward);

	public void Insert(decimal reward, int casinoUserId) =>
		ExecuteNonQuery($"INSERT INTO casinoWins(reward, userId) VALUES({reward}, {casinoUserId})");

	public void DeleteFromUserId(int userId) =>
		ExecuteNonQuery($"DELETE casinoWins WHERE userId = {userId}");
}
