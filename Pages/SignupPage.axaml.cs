using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace BankAccount;

public partial class SignupPage : UserControl
{
	public SignupPage()
	{
		InitializeComponent();
	}

	private List<char> Password = new();
	private List<char> ReInsertPassword = new();

	private void SetFailTextVisibility(bool isVisible)
	{
		textBoxFailText1.IsVisible = isVisible;
		textBoxFailText2.IsVisible = isVisible;
	}

	private void CreatUser(object sender, RoutedEventArgs e)
	{
		string password = Login.PasswordToString(Password);
		string reInsertPassword = Login.PasswordToString(ReInsertPassword);

		if (password == reInsertPassword && UserDatabase.Instance.CreateUser(textBoxUsername.Text, Login.PasswordToString(Password)))
		{
			SetFailTextVisibility(false);
			textBoxUsername.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxReInsertPassword.Text = string.Empty;
		}
		else
			SetFailTextVisibility(true);
	}

	private void GoToLogin(object sender, RoutedEventArgs e)
	{
		this.FindControl<ContentControl>("MainContent").Content = new LoginPage();
	}

	private void PasswordTextChanged(object sender, TextChangedEventArgs e)
	{
		Login.HideLogin((TextBox)sender, Password);
	}

	private void PasswordReInsertChanged(object sender, TextChangedEventArgs e)
	{
		Login.HideLogin((TextBox)sender, ReInsertPassword);
	}
}