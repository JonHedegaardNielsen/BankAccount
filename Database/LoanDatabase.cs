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
		new Loan(reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), (PaymentTypes)reader.GetValue(4), reader.GetDecimal(5), reader.GetDateTime(7), new(reader.GetInt32(9), reader.GetString(10), reader.GetDecimal(11)));

	public List<Loan> SelectLoan(int userId)
	{
		return RunQuery($"select * from loan l LEFT join BankAccount b ON l.bankAccountId = b.bankAccountId WHERE l.userId = {userId}", GetData);
	}

	public void Insert(Loan loan ,int userId, int bankAccountId)
	{
		ExecuteNonQuery($"INSERT INTO loan(paymentTime, debt, userId, bankAccountId, CostForEachPayment, Interest, [name], payDate) VALUES({(int)loan.PaymentType}, {loan.InitialValue}, {userId}, {bankAccountId}, {loan.CostForEachPayment}, { FormatDecimal(loan.Interest)}, '{loan.Name}', '{loan.PayDate.ToString("MM-dd-YY")}')");
		loan.BankAccount = BankAccountDatabase.Instance.GetSingleBankAccount(bankAccountId);
	}
}
