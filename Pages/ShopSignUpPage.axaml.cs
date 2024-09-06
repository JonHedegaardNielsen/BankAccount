using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
namespace BankAccount;

public partial class ShopSignUpPage : UserControl
{
    public ShopSignUpPage()
    {
        InitializeComponent();
    }

	private void CreateAccount(object? sender, RoutedEventArgs e)
	{
        if (textBoxReInsertPassword.Text == textBoxPassword.Text && Login.CheckLength(textBoxUserName.Text) && Login.CheckLength(textBoxPassword.Text))
            ShopUserDatabase.Instance.CreateUser(textBoxUserName.Text, textBoxPassword.Text);
	}
}