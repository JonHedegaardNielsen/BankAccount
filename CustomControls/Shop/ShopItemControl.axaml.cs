using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System.IO;
using Avalonia.Controls.Shapes;
using System;

namespace BankAccount;

public partial class ShopItemControl : UserControl
{
    private ShopItem CurrentShopItem;
	public static readonly StyledProperty<string> ImageFilePath =
	    AvaloniaProperty.Register<ShopItemControl, string>(nameof(ImageFilePath));

	public static readonly StyledProperty<string> ShopPrice =
		AvaloniaProperty.Register<ShopItemControl, string>(nameof(ShopPrice));

	public static readonly StyledProperty<string>  ShopItemName =
		AvaloniaProperty.Register<ShopItemControl, string>(nameof(ShopItemName));

    public string Price
    {
        get => GetValue(ShopPrice);
        set => SetValue(ShopPrice, value);
    }

    public string ItemName
    {
        get => GetValue(ShopItemName);
        set => SetValue(ShopItemName, value);
    }

	private string FilePath
    {
        get => GetValue(ImageFilePath);
        set => SetValue(ImageFilePath, value);
    }

	public ShopItemControl()
    {
        InitializeComponent();
	}

    public ShopItemControl(ShopItem shopItem)
    {
        InitializeComponent();
        CurrentShopItem = shopItem;
	}

    private void ItemLoaded(object sender, RoutedEventArgs e)
    {
        string filePath = System.IO.Path.GetFullPath(@FilePath, AppContext.BaseDirectory);

		if (File.Exists(filePath))
			imageShopItem.Source = new Bitmap(filePath);

		txtBlockShopItemName.Text = ItemName;
		txtBlockShopItemPrice.Text = Price;
	}
}