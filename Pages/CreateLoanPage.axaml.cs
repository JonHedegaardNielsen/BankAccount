using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;


namespace BankAccount;
public partial class CreateLoanPage : UserControl
{

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
		BankAccounts = BankAccountDatabase.Instance.GetBankAccounts(User.CurrentUser.Id);
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
        LoanDatabase.Instance.Insert(SelectedLoanType, User.CurrentUser.Id, ((BankAccount)comboBoxBankAccount.SelectedItem).Id);
        User.CurrentUser.Loans.Add(SelectedLoanType);
        SelectedLoanType = null;
        comboBoxLoanTypes.Clear();
        comboBoxLoanTypes.ItemsSource = LoanTypes;
    }

	private void BackToMainPage(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new MainPage();
	}
}