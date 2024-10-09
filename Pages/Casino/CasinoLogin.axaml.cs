using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using System;

namespace BankAccount;

public partial class CasinoLogin : UserControl
{
    public Action OnSignUp;
    public ContentControl MainContent;
    public CasinoLogin()
    {
        InitializeComponent();
		DataContext = new CasinoLoginViewmodel(LoginSucces, LoginFailed, OnLogin, MainContent);
	}

	private void LoginSucces()
    {
        MainContent.Content = new CasinoMainPage();
    }

    private void LoginFailed()
    {
        LabelFailText.IsVisible = true;
    }

    public void SignUp(object sender, RoutedEventArgs e)
    {
        OnSignUp();
    }

    private Tuple<string, string> OnLogin() =>
		new Tuple<string, string>(textBoxUsername.Text, textBoxPassword.Text);
}