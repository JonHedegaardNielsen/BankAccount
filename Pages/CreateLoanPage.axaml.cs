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
		new("House Loan",PaymentTypes.Monthly , 10000000 , 1.5m, 5000),
		new("Car Loan", PaymentTypes.Quarterly, 100000, 3, 2000),
		new("Quick Loan", PaymentTypes.Monthly , 5000, 20, 1000)
	};
	List<BankAccount> BankAccounts;

	public CreateLoanPage()
	{
		InitializeComponent();
		BankAccounts = BankAccountDatabase.Instance.GetBankAccounts(BankUser.CurrentUser.Id);
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
		if (SelectedLoanType != null)
		{
			BankAccount bankAccount = (BankAccount)comboBoxBankAccount.SelectedItem;
			SelectedLoanType.ChangePayDate();
			LoanDatabase.Instance.Insert(SelectedLoanType, BankUser.CurrentUser.Id, bankAccount.Id);
			bankAccount.Balance += SelectedLoanType.InitialValue;
			BankAccountDatabase.Instance.UpdateBalance(bankAccount.Id, bankAccount.Balance);
			BankUser.CurrentUser.Loans.Add(SelectedLoanType);
			SelectedLoanType = null;
			comboBoxLoanTypes.Clear();
			comboBoxLoanTypes.ItemsSource = LoanTypes;
		}
	}

	private void BackToMainPage(object sender, RoutedEventArgs e)
	{
		this.FindControl<ContentControl>("MainContent").Content = new MainPage();
	}
}