using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class LoanControl : UserControl
{

    public LoanControl(Loan loan)
    {
        InitializeComponent();
		DataContext = new BankLoanViewModel(loan);
    }
}