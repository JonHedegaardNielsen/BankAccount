using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Azure;
using System;

namespace BankAccount;

public partial class CreateBankAccountPage : UserControl
{
    User CurrentUser;
    public CreateBankAccountPage()
    {
        InitializeComponent();
    }

    public CreateBankAccountPage(User user)
    {
        CurrentUser = user;
		InitializeComponent();
	}

    private void CreateBankAccount(object sender, RoutedEventArgs e)
    {
        BankAccountDatabase.Instance.Insert(CurrentUser.Id, textBoxName.Text, 0);
        CurrentUser.BankAccounts = BankAccountDatabase.Instance.GetBankAccounts(CurrentUser.Id);
    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new MainPage(CurrentUser);
	}
}