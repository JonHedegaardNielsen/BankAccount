using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;

namespace BankAccount;

public partial class ShopMainPage : UserControl
{
    public ShopMainPage()
    {
        InitializeComponent();
		DataContext = new ShopMainViewModel();
    }

	private void ShopItemAmountLoaded(object? sender, RoutedEventArgs e)
	{
	}

	private void LogOut(object? sender, RoutedEventArgs e)
	{
		ShopUser.CurrentShopUser.LogOut();
		MainContent.Content = new LoginPage();
	}

}