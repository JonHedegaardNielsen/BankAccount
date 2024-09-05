using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace BankAccount;

public partial class BankAccountControl : UserControl
{
    BankAccount BankAccount { get; set; }

    public BankAccountControl() 
    {
        InitializeComponent();
    }

    public BankAccountControl(BankAccount bankAccount)
    {
        InitializeComponent();
        DataContext = bankAccount;
        BankAccount = bankAccount;
	}

	private void GoToInfoPage(object? sender, RoutedEventArgs e)
	{
		this.FindControl<ContentControl>("MainContent").Content = new BankAccountInfoPage();
	}

	private void AddMoney(object? sender, RoutedEventArgs e)
	{
        BankAccount.Balance += 10;
        textBlockBankAccountBalance.Text = BankAccount.Balance.ToString();
        BankAccountDatabase.Instance.UpdateBalance(BankAccount.Id, BankAccount.Balance);
	}
}