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
	}

	private void CreateAccount(object? sender, RoutedEventArgs e)
	{
		if (comboBoxChosenBankAccount.SelectedItem != null && textBoxReInsertPassword.Text == textBoxPassword.Text && Login.CheckLength(textBoxUserName.Text) && Login.CheckLength(textBoxPassword.Text))
		{
			ShopUserDatabase.Instance.CreateUser(textBoxUserName.Text, textBoxPassword.Text, ((BankAccount)comboBoxChosenBankAccount.SelectedItem).Id);

		}
	}

	private void GoToLogin(object? sender, RoutedEventArgs e)
	{
		MainContent.Content = new LoginPage();
	}
}