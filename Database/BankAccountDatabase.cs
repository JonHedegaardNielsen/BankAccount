using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class BankAccountDatabase : Database<BankAccount>
{
	public static BankAccountDatabase Instance = new();
	private BankAccountDatabase() { }


	private BankAccount GetData(SqlDataReader sqlDataReader) =>
		new BankAccount(int.Parse(sqlDataReader["bankAccountId"].ToString()), sqlDataReader["name"].ToString(), decimal.Parse(sqlDataReader["balance"].ToString()));

	public List<BankAccount> GetBankAccounts(int userId)
	{
		return RunQuery($"SELECT * FROM bankAccount WHERE userId = {userId}", GetData);
	}

	public void Insert(int userId, string name, decimal balance)
	{
		ExecuteNonQuery($"INSERT INTO bankAccount(userId, [name], balance) VALUES({userId}, '{name}', {0})");
	}


}
