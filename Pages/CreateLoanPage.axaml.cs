using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
namespace BankAccount;

using Azure;
using System;
public partial class CreateLoanPage : UserControl
{
    private User? CurrentUser;

    Loan? SelectedLoanType;

    List<Loan> LoanTypes = new List<Loan>()
    {
        new("House Loan", 10000000, PaymentTypes.monthly, 1.5m, 5000),
        new("Car Loan", 100000, PaymentTypes.quarterly, 3, 2000),
        new("Quick Loan", 5000, PaymentTypes.monthly, 20, 1000)
    };
    List<BankAccount> BankAccounts;

    public CreateLoanPage()
    {
        InitializeComponent();
	}

    public CreateLoanPage(User user)
    {
        InitializeComponent();
        CurrentUser = user;
		BankAccounts = BankAccountDatabase.Instance.GetBankAccounts(CurrentUser.Id);
	}

	private void PageLoaded(object sender, RoutedEventArgs e)
    {
        comboBoxLoanTypes.ItemsSource = LoanTypes;
        comboBoxBankAccount.ItemsSource = BankAccounts;
    }

    private void SelectLoan(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        SelectedLoanType = (Loan?)comboBox.SelectedItem;
        DataContext = SelectedLoanType;
    }

    private void CreateLoan(object sender, RoutedEventArgs e)
    {
        LoanDatabase.Instance.Insert(SelectedLoanType, CurrentUser.Id, ((BankAccount)comboBoxBankAccount.SelectedItem).Id);
        CurrentUser.Loans.Add(SelectedLoanType);
    }

	private void BackToMainPage(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new MainPage(CurrentUser);
	}
}