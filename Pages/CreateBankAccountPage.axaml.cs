using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Azure;
using System;

namespace BankAccount;

public partial class CreateBankAccountPage : UserControl
{
    public CreateBankAccountPage()
    {
        InitializeComponent();
    }

    private void CreateBankAccount(object sender, RoutedEventArgs e)
    {
        BankAccountDatabase.Instance.Insert(User.CurrentUser.Id, textBoxName.Text, 0);
        User.CurrentUser.BankAccounts = BankAccountDatabase.Instance.GetBankAccounts(User.CurrentUser.Id);
    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new MainPage();
	}
}