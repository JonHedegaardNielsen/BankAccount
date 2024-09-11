using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace BankAccount;


public partial class ShopItemAmountControl : UserControl
{
	public static readonly StyledProperty<ShopItemType> ShopItemName =
			AvaloniaProperty.Register<ShopItemControl, ShopItemType>(nameof(ShopItemName));

    public ShopItemType ItemName
    {
        get => GetValue(ShopItemName);
        set => SetValue(ShopItemName, value);
    }

	public ShopItemAmountControl()
    {
        InitializeComponent();

	}

	public void Reload()
    {
    }

    private void OnLoad(object? sender, RoutedEventArgs e)
    {
		DataContext = ShopItem.ShopItemTypes[ItemName];
	}
}