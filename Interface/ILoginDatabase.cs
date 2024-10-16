using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public interface ILoginDatabase
{
	public bool FindUser(string username, string password, out User? user); 
}
