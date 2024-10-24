using Avalonia.Controls;

namespace BankAccount;

public partial class BankAccountControl : UserControl
{
    public BankAccountControl()
    {
        InitializeComponent();
    }

    public BankAccountControl(BankAccount bankAccount)
    {
        InitializeComponent();
        DataContext = new BankAccountViewModel(bankAccount);
	}
}