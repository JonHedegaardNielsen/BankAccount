using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;

namespace BankAccount;

public partial class ShopItemControl : UserControl
{
    private ShopItem CurrentShopItem;
    public ShopItemControl()
    {
        InitializeComponent();
    }

    public ShopItemControl(ShopItem shopItem)
    {
        InitializeComponent();
        CurrentShopItem = shopItem;
	}

	private void ShopItemLoaded(object? sender, RoutedEventArgs e)
	{
        imageShopItem.Source = new Bitmap("Assets/Milk.png");
    }
}