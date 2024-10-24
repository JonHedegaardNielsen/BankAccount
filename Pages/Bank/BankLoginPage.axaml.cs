using Avalonia.Controls;
using System;

namespace BankAccount;

public partial class BankLoginPage : UserControl
{
	
	public BankLoginPage()
	{
		InitializeComponent();
	}

	// For when you need to refernce a bank account on another login
	public BankLoginPage(Func<UserControl> getNextPage, object? currentPage)
	{
		InitializeComponent();
		DataContext = new LoginPageViewmodel(currentPage, MainContent.Content, false, getNextPage);
		btnSignUp.IsVisible = false;
	}
}