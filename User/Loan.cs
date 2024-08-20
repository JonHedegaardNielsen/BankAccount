using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Loan
{
	public PaymentTypes PaymentType { get; set; }
	public decimal Debt { get; private set; }
}
