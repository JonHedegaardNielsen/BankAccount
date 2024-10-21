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
    public LoginPage()
    {
        InitializeComponent();
		DataContext = new LoginPageViewmodel(MainContent.Content, bankLogin.MainContent.Content);
		bankLogin.MainContent = MainContent;
	}
}