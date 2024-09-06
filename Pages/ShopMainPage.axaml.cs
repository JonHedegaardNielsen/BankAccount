using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BankAccount;

public partial class ShopMainPage : UserControl
{
    public ShopMainPage()
    {
        InitializeComponent();
    }

	private void LoadItems(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		ShopItem1 = new ShopItemControl(new(1, "Milk", "Its milk", 10));
	}
}