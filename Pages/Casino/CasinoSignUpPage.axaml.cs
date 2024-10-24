using Avalonia.Controls;

namespace BankAccount;

public partial class CasinoSignUpPage : UserControl
{
    public CasinoSignUpPage()
    {
        InitializeComponent();
        DataContext = new CasinoSignUpViewModel(MainContent.Content);

        comboBoxBankAccount.Items.Clear();
        comboBoxBankAccount.ItemsSource = BankUser.CurrentUser.BankAccounts;
	}
}