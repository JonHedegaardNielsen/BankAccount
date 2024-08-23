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
		new Loan(reader["name"].ToString(), decimal.Parse(reader["Interest"].ToString()), decimal.Parse(reader["CostForEachPayment"].ToString()),(PaymentTypes)reader["paymentTime"], decimal.Parse(reader["debt"].ToString()), 
			new BankAccount(int.Parse(reader["bankAccountId"].ToString()), reader["name"].ToString(), decimal.Parse(reader["balance"].ToString())));

	public List<Loan> SelectLoan(int userId)
	{
		return RunQuery($"select * from loan l LEFT join BankAccount b ON l.bankAccountId = b.bankAccountId WHERE l.userId = {userId}", GetData);
	}

	public void Insert(Loan loan ,int userId, int bankAccountId)
	{
		ExecuteNonQuery($"INSERT INTO loan(paymentTime, debt, userId, bankAccountId, CostForEachPayment, Interest, [name]) VALUES({(int)loan.PaymentType}, {loan.InitialValue}, {userId}, {bankAccountId}, {loan.CostForEachPayment}, { FormatDecimal(loan.Interest)}, '{loan.Name}')");
		loan.BankAccount = BankAccountDatabase.Instance.GetSingleBankAccount(bankAccountId);
	}
}
