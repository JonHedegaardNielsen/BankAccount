using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace BankAccount;

public partial class MainPage : UserControl
{
    User? User;

	public MainPage()
	{
		InitializeComponent();
	}

	public MainPage(User user)
    {
        User = user;
        InitializeComponent();
    }

	private void BankAccountLoaded(object sender, RoutedEventArgs e)
	{
		Grid grid = (Grid)sender;
        
		foreach (var item in User.bankAccounts)
	        grid.Children.Add(new BankAccountControl());
	}
}