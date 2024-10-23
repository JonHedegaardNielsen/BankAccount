using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class CreateBankAccountPage : UserControl
{
    public CreateBankAccountPage()
    {
        InitializeComponent();
        DataContext = new BankAccountContolViewModel(CurrentPage.Content);
    }

    private void CreateBankAccount(object sender, RoutedEventArgs e)
    {
        BankAccountDatabase.Instance.Insert(BankUser.CurrentUser.Id, textBoxName.Text, 0);
    }

	private void Binding(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
	}
}