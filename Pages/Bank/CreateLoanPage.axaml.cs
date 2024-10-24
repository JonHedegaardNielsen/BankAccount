using Avalonia.Controls;

namespace BankAccount;
public partial class CreateLoanPage : UserControl
{
	public CreateLoanPage()
	{
		InitializeComponent();
		DataContext = new CreateLoanPageViewModel(MainContent.Content);
	}
}