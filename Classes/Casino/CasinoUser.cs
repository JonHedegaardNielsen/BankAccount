using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class CasinoUser : User
{
	public static CasinoUser? CurrentUser;

	public decimal AmountToWinBack { get; set; }

	public BankAccount BankAccount { get; }

    public CasinoUser(int id, string username, string password, BankAccount bankAccount, decimal amountToWinBack) : base(id, username, password)
    {
		BankAccount = bankAccount;
		AmountToWinBack = amountToWinBack;
    }
}
