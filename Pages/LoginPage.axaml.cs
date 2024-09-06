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
    private List<char> Password = new();
    
    
    public LoginPage()
    {
        InitializeComponent();
    }

    private void LoginToBankAccount(object sender, RoutedEventArgs e)
    {
        if (BankUserDatabase.Instance.FindUser(textBoxUsername.Text, textBoxPassword.Text, out BankUser? user))
        {
            BankUser.CurrentUser = user;
			LabelFailText.IsVisible = false;

			MainContent.Content = new MainPage();
		}
		else
            LabelFailText.IsVisible = true;
	}

	private void Signup(object sender, RoutedEventArgs e)
    {
		MainContent.Content = new SignupPage();
    }

	private void LoginShop(object? sender, RoutedEventArgs e)
	{
        if (ShopUser.Login(textBoxUsername.Text, textBoxPassword.Text))
			MainContent.Content = new ShopMainPage();
	}

	private void ShopSignUp(object? sender, RoutedEventArgs e)
	{

	}
}