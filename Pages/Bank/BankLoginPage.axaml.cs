using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class BankLoginPage : UserControl
{
	private Func<UserControl>? GetNextPage;
	public object CurrentPage { private get; set; }
	
	public BankLoginPage()
	{
		InitializeComponent();
	}

	// For when you need to refernce a bank account on another login
	public BankLoginPage(Func<UserControl> getNextPage, object? currentPage)
	{
		InitializeComponent();
		DataContext = new LoginPageViewmodel(getNextPage, MainContent.Content);
		btnSignUp.IsVisible = false;
	}
}