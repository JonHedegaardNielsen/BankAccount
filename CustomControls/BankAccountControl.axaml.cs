using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BankAccount;

public partial class BankAccountControl : UserControl
{
    BankAccount BankAccount { get; set; }

    public BankAccountControl() 
    {
        InitializeComponent();
    }

    public BankAccountControl(BankAccount bankAccount)
    {
        InitializeComponent();
        DataContext = bankAccount;
	}
}