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
        int rowCounter = 0;

		foreach (var bankAccount in User.BankAccounts)
		{
			var child = new BankAccountControl(bankAccount);
			child.SetValue(Grid.RowProperty, rowCounter);


			grid.Children.Add(child);

			rowCounter++;
		}
	}

	private void CreateNewBankAccount(object sender , RoutedEventArgs e)
	{

	}
}