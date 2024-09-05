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
        if 
        ShopUserDatabase.Instance.CreateUser()
	}
}