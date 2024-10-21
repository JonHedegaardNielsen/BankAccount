using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;

namespace BankAccount;

public partial class ShopMainPage : UserControl
{
	private ShopMainViewModel ShopViewModel;
    public ShopMainPage()
    {
        InitializeComponent();
		ShopViewModel = new ShopMainViewModel();
		DataContext = ShopViewModel;
    }

	private void ShopItemAmountLoaded(object? sender, RoutedEventArgs e)
	{
	}

	private void LogOut(object? sender, RoutedEventArgs e)
	{
		ShopUser.CurrentUser.LogOut();
		MainContent.Content = new LoginPage();
	}

	private void DeleteUser(object? sender, RoutedEventArgs e)
	{
		ShopViewModel.DeleteCurrentUser();
		MainContent.Content = new LoginPage();
	}
}