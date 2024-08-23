using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Azure;

namespace BankAccount;

public partial class CreateBankAccountPage : UserControl
{
    User CurrentUser;
    public CreateBankAccountPage()
    {
        InitializeComponent();
    }

    public CreateBankAccountPage(User user)
    {
        CurrentUser = user;
		InitializeComponent();
	}

    private void CreateBankAccount(object sender, RoutedEventArgs e)
    {

    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
		this.FindControl<ContentControl>("MainContent").Content = new MainPage();
	}
}