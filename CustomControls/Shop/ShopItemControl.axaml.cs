using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace BankAccount;

public partial class ShopItemControl : UserControl
{
	public static readonly StyledProperty<Image> ImageName =
	    AvaloniaProperty.Register<ShopItemControl, Image>(nameof(Image));

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

	public Image Image
    {
        get => GetValue(ImageName);
        set => SetValue(ImageName, value);
    }

	public ShopItemControl()
    {
        InitializeComponent();
	}

    private void ItemLoaded(object sender, RoutedEventArgs e)
    {
        imageShopItem.Source = new Bitmap(Files.ImageFiles[Image]);

        txtBlockShopItemName.Text = ItemName.ToString();
		txtBlockShopItemPrice.Text = $"{ShopItem.ShopItemTypes[ItemName].Price} kr.";
	}
}