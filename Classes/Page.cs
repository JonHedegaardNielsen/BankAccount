using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace BankAccount;

class Page
{
	public static void ChangePage(UserControl currentPage, UserControl nextPage, string mainContentName = "MainContent")
	{
		var control = currentPage.FindControl<ContentControl>("MainContent").Content;

		if (control != null)
			control = nextPage;
	}
}
