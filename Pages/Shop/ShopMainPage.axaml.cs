using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class ShopMainPage : UserControl
{
    public ShopMainPage()
    {
        InitializeComponent();
        DataContext = ShopUser.CurrentShopUser.UserBankAccount;
    }
}