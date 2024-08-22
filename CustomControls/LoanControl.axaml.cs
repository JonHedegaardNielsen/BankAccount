using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BankAccount;

public partial class LoanControl : UserControl
{
    private Loan? Loan;

    public LoanControl()
    {
        InitializeComponent();
    }

    public LoanControl(Loan loan)
    {
        InitializeComponent();
        Loan = loan;

        DataContext = Loan;
    }
}