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
        if(UserDatabase.Instance.FindUser(textBoxUsername.Text, textBoxPassword.Text, out User user))
        {
			this.FindControl<ContentControl>("MainContent").Content = new MainPage(user);
		}
	}

	private void Signup(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new SignupPage();
    }


}