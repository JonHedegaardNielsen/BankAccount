using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

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

	public ShopItemAmountControl(ShopItem shopItem)
    {
        InitializeComponent();
		DataContext = new ShopItemAmountViewModel(shopItem);
	}

    private void OnLoad(object? sender, RoutedEventArgs e)
    {
		//DataContext = new ShopItemAmountViewModel( ShopItem.ShopItemTypes[ItemName]);
	}
}