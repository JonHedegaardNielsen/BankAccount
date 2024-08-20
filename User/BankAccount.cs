using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class BankAccount
{
	public int Id;
	public string Name { get; private set; }
	public string Balance { get; private set; }
}
