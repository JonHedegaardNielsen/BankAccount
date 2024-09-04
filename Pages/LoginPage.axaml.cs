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
        if(UserDatabase.Instance.FindUser(textBoxUsername.Text, textBoxPassword.Text, out User? user))
        {
            User.CurrentUser = user;
			LabelFailText.IsVisible = false;

			this.FindControl<ContentControl>("MainContent").Content = new MainPage();
		}
		else
            LabelFailText.IsVisible = true;
	}

	private void Signup(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new SignupPage();
    }
}