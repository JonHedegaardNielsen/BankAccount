using Avalonia.Controls;

namespace BankAccount;

public partial class BankSignupPage : UserControl
{
	public BankSignupPage()
	{
		InitializeComponent();
		DataContext = new BankSignupPageViewModel(MainContent.Content);
	}
}