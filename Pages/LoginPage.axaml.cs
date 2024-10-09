using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.ComponentModel;
namespace BankAccount;
using System;
using System.Security.Cryptography.X509Certificates;
using Tmds.DBus.Protocol;

public partial class LoginPage : UserControl
{
	private UserControl NextPage;
    
    public LoginPage()
    {
        InitializeComponent();
		bankLogin.CurrentPage = MainContent;
		casinoLogin.MainContent = MainContent;
	}

	public LoginPage(UserControl nextPage)
    {
        InitializeComponent();
        NextPage = nextPage;
		bankLogin.CurrentPage = MainContent;
    }

	private void LoginShop(object? sender, RoutedEventArgs e)
	{
		if (ShopUser.Login(textBoxShopUsername.Text, textBoxShopPassword.Text))
			MainContent.Content = new ShopMainPage();
	}

	private void ShopSignUp(object? sender, RoutedEventArgs e)
	{
        MainContent.Content = new BankLoginPage(() => new ShopSignUpPage(), MainContent);
	}

	private void PageLoaded(object? sender, RoutedEventArgs e)
	{
		void SignUp()
		{
			MainContent.Content = new BankLoginPage(() => new CasinoSignUpPage(), MainContent);
		}

		casinoLogin.OnSignUp = SignUp;
	}
}