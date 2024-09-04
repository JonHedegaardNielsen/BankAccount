using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class LoanControl : UserControl
{
    private Loan Loan;

    public LoanControl()
    {
        InitializeComponent();
    }

    public LoanControl(Loan loan)
    {
        InitializeComponent();
        Loan = loan;
        btnPayDebt.IsVisible = Loan.IsPayTime();
		DataContext = Loan;
    }

	private void PayOffLoan(object? sender, RoutedEventArgs e)
	{
        Loan.PayLoan();
		textBoxPayDate.Text = Loan.PayDateString;
		textBoxDebt.Text = Loan.DebtString;
        btnPayDebt.IsVisible = Loan.IsPayTime();
	}
}