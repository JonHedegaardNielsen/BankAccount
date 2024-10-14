using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class BankLoginPage : UserControl
{
	private Func<UserControl>? GetNextPage;
	public ContentControl CurrentPage { private get; set; }
	
	public BankLoginPage()
	{
		InitializeComponent();

	}

	// For when you need to refernce a bank account on another login
	public BankLoginPage(Func<UserControl> getNextPage, ContentControl currentPage)
	{
		InitializeComponent();
		GetNextPage = getNextPage;
		CurrentPage = currentPage;
		btnSignUp.IsVisible = false;
	}

	private void LoginToBankAccount(object sender, RoutedEventArgs e)
	{
		if (BankUser.Login(textBoxUsername.Text, textBoxPassword.Text))
		{
			LabelFailText.IsVisible = false;

			if (GetNextPage != null)
				CurrentPage.Content = GetNextPage();
			else
				CurrentPage.Content = new BankMainPage();
		}
		else
			LabelFailText.IsVisible = true;
	}

	private void Signup(object? sender, RoutedEventArgs e)
	{
		CurrentPage.Content = new BankSignupPage();
	}

}