using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
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
        BankAccountDatabase.Instance.Insert(BankUser.CurrentUser.Id, textBoxName.Text, 0);
    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new MainPage();
	}
}