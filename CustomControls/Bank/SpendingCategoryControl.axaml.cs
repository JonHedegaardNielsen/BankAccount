using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Data;
using Avalonia.Interactivity;

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
    }

	public void Update(int bankAccountId)
	{
		((ShopItemCategoryViewModel)DataContext).UpdateData(bankAccountId);
	}

	private void CategoryLoaded(object? sender, RoutedEventArgs e)
	{
		DataContext = new ShopItemCategoryViewModel(Category);
	}
}