using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
	public class Login
	{
		public static bool CheckLength(string text)
		{
			try
			{
				return text.Length >= 8 && text.Length <= 32;
			}
			catch (NullReferenceException)
			{
				return false;
			}
		}
	}
}
