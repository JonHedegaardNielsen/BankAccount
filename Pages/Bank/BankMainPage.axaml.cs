using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace BankAccount;

public partial class BankMainPage : UserControl
{
	BankMainPageViewModel BankViewModel;
	public BankMainPage()
	{
		InitializeComponent();
		comboBoxBankAccountTransferFrom.ItemsSource = BankUser.CurrentUser.BankAccounts;
		comboBoxBankAccountTransferTo.ItemsSource = BankUser.CurrentUser.BankAccounts;
		BankUser.UpdateCurrentUser();
		BankViewModel = new BankMainPageViewModel();
		DataContext = BankViewModel;
	}

	private void BankAccountLoaded(object sender, RoutedEventArgs e)
	{
		int rowCounter = 0;

		foreach (var bankAccount in BankUser.CurrentUser.BankAccounts)
		{
			var child = new BankAccountControl(bankAccount);
			child.SetValue(Grid.RowProperty, rowCounter);
			gridBankAccount.Children.Add(child);
			rowCounter++;
		}
	}

	private void LoadLoan(object sender, RoutedEventArgs e)
	{
		Grid grid = (Grid)sender;
		int rowCounter = 0;

		foreach (var loan in BankUser.CurrentUser.Loans)
		{
			var child = new LoanControl(loan);
			child.SetValue(Grid.RowProperty, rowCounter);
			child.SetValue(Grid.ColumnProperty, 0);
			grid.Children.Add(child);
			rowCounter++;
		}
	}


	private void CreateNewBankAccount(object sender, RoutedEventArgs e)
	{
		MainContent.Content = new CreateBankAccountPage();
	}

	private void CreateLoan(object sender, RoutedEventArgs e)
	{
		MainContent.Content = new CreateLoanPage();
	}

	private void ValidateNumber(object? sender, TextInputEventArgs e)
	{
		TextBox textBox = (TextBox)sender;

		if (!int.TryParse(e.Text, out _) || e.Text == "," || e.Text == ".")
		{
			e.Handled = true;
		}
	}

	void OnTransferFail()
	{
		labelTransferFailText.IsVisible = true;
	}

	private void Transfer(object? sender, RoutedEventArgs e)
	{
		if (decimal.TryParse(textBoxAmountToTransfer.Text, out _)&& int.TryParse(textBoxBankAcconutIdTransferTo.Text, out int bankAccountId) && comboBoxBankAccountTransferFrom.SelectedValue != comboBoxBankAccountTransferTo.SelectedValue)
		{
			decimal amount = decimal.Parse(textBoxAmountToTransfer.Text);

			if ((bool)checkBoxTransferToOtherUser.IsChecked)
			{
				BankAccount bankAccountTransferTo = BankAccountDatabase.Instance.GetSingleBankAccount(bankAccountId);
				bankAccountTransferTo.Transfer(amount, (BankAccount)comboBoxBankAccountTransferFrom.SelectedValue);
			}
			else
			{
				BankAccount bankAccountTransferTo = (BankAccount)comboBoxBankAccountTransferTo.SelectedValue;
				bankAccountTransferTo.Transfer(amount, (BankAccount)comboBoxBankAccountTransferFrom.SelectedValue);
			}

			labelTransferFailText.IsVisible = false;
		}
		else
			OnTransferFail();
	}

	private void CheckBox_Click(object? sender, RoutedEventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;

		textBoxBankAcconutIdTransferTo.IsVisible = (bool)checkBox.IsChecked;
		comboBoxBankAccountTransferTo.IsVisible = !(bool)checkBox.IsChecked;
	}

	private void LogOut(object? sender, RoutedEventArgs e)
	{
		BankUser.LogOut();
		MainContent.Content = new LoginPage();
	}

	private void DeleteUser(object? sender, RoutedEventArgs e)
	{
		BankViewModel.DeleteUser();
		MainContent.Content = new LoginPage();
	}
}