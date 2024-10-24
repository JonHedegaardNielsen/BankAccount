using Avalonia.Controls;

namespace BankAccount;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
		DataContext = new LoginPageViewmodel(MainContent.Content, bankLogin.MainContent.Content);
		bankLogin.MainContent = MainContent;
	}
}