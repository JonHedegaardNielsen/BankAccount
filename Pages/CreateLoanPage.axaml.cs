using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
namespace BankAccount;
using System;
public partial class CreateLoanPage : UserControl
{
    private User? User;

    Loan? SelectedLoanType;

    List<Loan> LoanTypes = new List<Loan>()
    {
        new("House Loan", 10000000, PaymentTypes.monthly, 1.5m, 5000),
        new("Car Loan", 100000, PaymentTypes.quarterly, 3, 2000),
        new("Quick Loan", 5000, PaymentTypes.monthly, 20, 1000)
    };

    public CreateLoanPage()
    {
        InitializeComponent();
	}

    public CreateLoanPage(User user)
    {
        InitializeComponent();
        User = user;
	}

    private void PageLoaded(object sender, RoutedEventArgs e)
    {
        comboBoxLoanTypes.ItemsSource = LoanTypes;
    }

    private void SelectLoan(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        SelectedLoanType = (Loan?)comboBox.SelectedItem;
        DataContext = SelectedLoanType;
    }
}