using Avalonia.Controls;

namespace BankAccount;

public partial class CasinoMainPage : UserControl
{
    public CasinoMainPage()
    {
        InitializeComponent();
		DataContext = new CasinoViewModel(MainContent.Content);
	}
}