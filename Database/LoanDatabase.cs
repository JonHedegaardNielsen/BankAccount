using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;
 class LoanDatabase : Database<Loan>
{
	private LoanDatabase() { }

	public static LoanDatabase Instance { get; private set; } = new();

	private Loan GetData(SqlDataReader reader) =>
		new Loan((PaymentTypes)reader["paymentTime"], decimal.Parse(reader["debt"].ToString()), 
			new BankAccount(int.Parse(reader["bankAccountId"].ToString()), reader["name"].ToString(), decimal.Parse(reader["balance"].ToString())));

	public List<Loan> SelectLoan(int userId)
	{
		return RunQuery($"select * from loan l LEFT join BankAccount b ON l.bankAccountId = b.bankAccountId WHERE l.userId = {userId}", GetData);
	}

	public void Insert(Loan loan ,int userId, int bankAccountId)
	{

	}

}
