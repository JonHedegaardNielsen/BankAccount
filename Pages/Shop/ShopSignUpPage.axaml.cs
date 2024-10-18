using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;


namespace BankAccount;

public partial class ShopSignUpPage : UserControl
{
    public ShopSignUpPage()
    {
        InitializeComponent();
		comboBoxChosenBankAccount.ItemsSource = BankUser.CurrentUser.BankAccounts;
		DataContext = new ShopSignUpViewModel(MainContent.Content);
	}
}