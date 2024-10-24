using Avalonia.Controls;

namespace BankAccount;

public partial class CreateBankAccountPage : UserControl
{
    public CreateBankAccountPage()
    {
        InitializeComponent();
        DataContext = new BankAccountContolViewModel(CurrentPage.Content);
    }
}