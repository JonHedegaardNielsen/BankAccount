using Avalonia.Controls;

namespace BankAccount;

public partial class ShopSignUpPage : UserControl
{
    public ShopSignUpPage()
    {
        InitializeComponent();
		comboBoxChosenBankAccount.ItemsSource = BankUser.CurrentUser.BankAccounts;
		DataContext = new ShopSignUpViewModel(MainContent.Content);
	}
}