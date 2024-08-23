using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
}