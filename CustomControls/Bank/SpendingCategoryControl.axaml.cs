using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Data;

namespace BankAccount;

public partial class SpendingCategoryControl : UserControl
{
	public static readonly StyledProperty<SpendingCategory> ShopItemCategory =
		AvaloniaProperty.Register<ShopItemControl, SpendingCategory>(nameof(ShopItemCategory), default, false, BindingMode.TwoWay);

	public SpendingCategory Category
	{
		get => GetValue(ShopItemCategory);
		set => SetValue(ShopItemCategory, value);
	}

	public SpendingCategoryControl()
    {
        InitializeComponent();
	}

	private void CategoryLoaded(object? sender, RoutedEventArgs e)
	{
		DataContext = new ShopItemCategoryViewModel(Category);
	}
}