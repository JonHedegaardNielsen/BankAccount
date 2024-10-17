using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace BankAccount;

public partial class BankSignupPage : UserControl
{
	public BankSignupPage()
	{
		InitializeComponent();
		DataContext = new BankSignupPageViewModel(MainContent.Content);
	}
}