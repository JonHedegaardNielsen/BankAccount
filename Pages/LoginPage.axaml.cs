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
        if(UserDatabase.Instance.FindUser(textBoxUsername.Text, Login.PasswordToString(Password), out User? user))
        {
            User.CurrentUser = user;
            this.FindControl<ContentControl>("MainContent").Content = new MainPage();
		}
	}

	private void Signup(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new SignupPage();
    }

    private void PasswordTextChanged(object sender, TextChangedEventArgs e)
    {
		Login.HideLogin(textBoxPassword, Password);
	}
}