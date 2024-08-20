using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.Data.SqlClient;

namespace BankAccount;

public partial class SignupPage : UserControl
{
	public SignupPage()
	{
		InitializeComponent();
	}

	private void SetFailTextVisibility(bool isVisible)
	{
		textBoxFailText1.IsVisible = isVisible;
		textBoxFailText2.IsVisible = isVisible;
	}

	private void CreatUser(object sender, RoutedEventArgs e)
	{
		if (textBoxPassword.Text == textBoxReInsertPassword.Text && UserDatabase.Instance.CreateUser(textBoxUsername.Text, textBoxPassword.Text))
		{
			SetFailTextVisibility(false);
			textBoxUsername.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxReInsertPassword.Text = string.Empty;
		}
		else
			SetFailTextVisibility(true);
	}

	private void Login(object sender, RoutedEventArgs e)
	{
		this.FindControl<ContentControl>("MainContent").Content = new LoginPage();
	}
}