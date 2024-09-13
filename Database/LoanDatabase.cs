using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankAccount;
 class LoanDatabase : Database<Loan>
{
	private LoanDatabase() { }

	public static LoanDatabase Instance { get; private set; } = new();

	private Loan GetData(SqlDataReader reader) =>
		new Loan(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), (PaymentTypes)reader.GetValue(4), reader.GetDecimal(5), reader.GetDateTime(6), new(reader.GetInt32(9), reader.GetString(10), reader.GetDecimal(11)));

	public List<Loan> SelectLoan(int userId)
	{
		return RunQuery($"SELECT * FROM loan l LEFT JOIN BankAccount b ON l.bankAccountId = b.bankAccountId WHERE l.userId = {userId}", GetData);
	}

	public void UpdateLoan(Loan loan)
	{
		ExecuteNonQuery($"UPDATE loan SET debt={loan.Debt}, payDate='{loan.PayDate.ToString("yyyy-MM-dd")}' WHERE loanId = {loan.Id}");
	}

	public void Insert(Loan loan ,int userId, int bankAccountId)
	{
		ExecuteNonQuery($"INSERT INTO loan(paymentTime, debt, userId, bankAccountId, CostForEachPayment, Interest, [name], payDate) VALUES({(int)loan.PaymentType}, {loan.InitialValue}, {userId}, {bankAccountId}, {loan.CostForEachPayment}, {FormatDecimal(loan.Interest)}, '{loan.Name}', '{loan.PayDate.ToString("yyyy-MM-dd")}')");
		loan.BankAccount = BankAccountDatabase.Instance.GetSingleBankAccount(bankAccountId);
	}

	public void DeleteLoanFromUserId(int userId)
	{
		ExecuteNonQuery($"DELETE FROM loan WHERE userId = {userId}");
	}

	public void Delete(int loanId)
	{
		ExecuteNonQuery($"DELETE FROM loan WHERE loanId = {loanId}");
	}
}
