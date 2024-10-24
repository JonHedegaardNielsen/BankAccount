using Avalonia.Controls;

namespace BankAccount;

public partial class LoanControl : UserControl
{
    public LoanControl()
    {
        InitializeComponent();
    }

    public LoanControl(Loan loan)
    {
        InitializeComponent();
		DataContext = new BankLoanViewModel(loan);
    }
}