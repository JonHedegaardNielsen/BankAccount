using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public static class Login
{
	public static void HideLogin(TextBox textBoxPassword, List<char> password)
	{
		string text = "";

		foreach (char c in textBoxPassword.Text)
			text += "*";

		int counter = 0;

		foreach (char c in textBoxPassword.Text)
		{
			if (c != '*')
			{
				try
				{
					
					password[counter] = c;
				}
				catch (ArgumentOutOfRangeException)
				{
					password.Add(c);
				}
			}
			counter++;
		}

		textBoxPassword.Text = text;
	}

	public static string PasswordToString(List<char> password)
	{
		string passwordString = "";
		foreach (char c in password)
			passwordString += c;

		return passwordString;
	}
}
