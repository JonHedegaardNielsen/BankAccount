using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class User
{
	public int Id { get; private set; }
	public string Usename { get; private set; } = string.Empty;
	public string Password { get; private set; } = string.Empty;
}
