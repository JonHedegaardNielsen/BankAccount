using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace BankAccount;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Login(object sender, RoutedEventArgs e)
    {
        if ()
        {
			this.FindControl<ContentControl>("MainContent").Content = new MainPage();
		}
	}


}