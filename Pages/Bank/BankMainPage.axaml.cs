using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankAccount;

public partial class BankMainPage : UserControl
{
	private string AmountToTranferText = String.Empty;
	BankMainPageViewModel BankViewModel;

	public BankMainPage()
	{
		InitializeComponent();
		comboBoxBankAccountTransferFrom.ItemsSource = BankUser.CurrentUser.BankAccounts;
		comboBoxBankAccountTransferTo.ItemsSource = BankUser.CurrentUser.BankAccounts;
		BankUser.UpdateCurrentUser();
		BankViewModel = new BankMainPageViewModel(MainContent.Content);
		DataContext = BankViewModel;
	}

	private void CreateNewBankAccount(object sender, RoutedEventArgs e)
	{
		MainContent.Content = new CreateBankAccountPage();
	}

	private void CreateLoan(object sender, RoutedEventArgs e)
	{
		MainContent.Content = new CreateLoanPage();
	}

	private void ValidateNumber(object sender, TextInputEventArgs e)
	{

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

	private void AmountToTransferTextChanged(object? sender, TextChangedEventArgs e)
	{
		if (sender is TextBox textBox && textBox != null)
		{
			if (String.IsNullOrWhiteSpace(textBox.Text) || decimal.TryParse(textBox.Text, out decimal TextDecimal))
			{
				AmountToTranferText = textBox.Text;
				textBox.CaretIndex = textBox.Text.Length;
			}
			else
				textBox.Text = AmountToTranferText;
		}
	}
}