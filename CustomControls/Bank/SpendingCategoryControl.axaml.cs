using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BankAccount;

public partial class SpendingCategoryControl : UserControl
{
	public static readonly StyledProperty<ShopItemCategory> ShopItemCategory =
		AvaloniaProperty.Register<ShopItemControl, ShopItemCategory>(nameof(ShopItemCategory));

	public ShopItemCategory Category
	{
		get => GetValue(ShopItemCategory);
		set => SetValue(ShopItemCategory, value);
	}

	

	public SpendingCategoryControl()
    {
        InitializeComponent();
		DataContext = new BankMainPageViewModel();
    }
}