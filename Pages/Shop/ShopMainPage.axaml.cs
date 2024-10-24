using Avalonia.Controls;

namespace BankAccount;

public partial class ShopMainPage : UserControl
{
	private ShopMainViewModel ShopViewModel;
    public ShopMainPage()
    {
        InitializeComponent();
		ShopViewModel = new ShopMainViewModel(MainContent.Content);
		DataContext = ShopViewModel;
    }

	private void Binding(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
	}
}