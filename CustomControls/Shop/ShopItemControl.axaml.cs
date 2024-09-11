using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System.IO;
using Avalonia.Controls.Shapes;
using System;
using BankAccount.Database;

namespace BankAccount;

public partial class ShopItemControl : UserControl
{
	public static readonly StyledProperty<string> ImageFilePath =
	    AvaloniaProperty.Register<ShopItemControl, string>(nameof(ImageFilePath));

	public static readonly StyledProperty<decimal> ShopPrice =
		AvaloniaProperty.Register<ShopItemControl, decimal>(nameof(ShopPrice));

	public static readonly StyledProperty<ShopItemType>  ShopItemName =
		AvaloniaProperty.Register<ShopItemControl, ShopItemType>(nameof(ShopItemName));
    
    public decimal Price
    {
        get => GetValue(ShopPrice);
        set => SetValue(ShopPrice, value);
    }

    public ShopItemType ItemName
    {
        get => GetValue(ShopItemName);
        set => SetValue(ShopItemName, value);
    }

	public string FilePath
    {
        get => GetValue(ImageFilePath);
        set => SetValue(ImageFilePath, value);
    }

	public ShopItemControl()
    {
        InitializeComponent();
	}

    private void ItemLoaded(object sender, RoutedEventArgs e)
    {
        string? filePath = System.IO.Path.GetFullPath(@FilePath, AppContext.BaseDirectory);

        if (File.Exists(filePath))
            imageShopItem.Source = new Bitmap(filePath);

        txtBlockShopItemName.Text = ItemName.ToString();
		txtBlockShopItemPrice.Text = Price.ToString() + "kr.";
	}

    private void BuyItem(object sender, RoutedEventArgs e)
    {
        ShopUser.CurrentShopUser.BuyItem(new(ItemName, Price));
    }
}