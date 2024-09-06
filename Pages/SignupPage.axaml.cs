using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace BankAccount;

public partial class SignupPage : UserControl
{
	public SignupPage()
	{
		InitializeComponent();
	}

	private List<char> Password = new();
	private List<char> ReInsertPassword = new();

	private void SetFailTextVisibility(bool isVisibleLengthFail, bool isVisibleMatchFail)
	{
		textBoxFailText1.IsVisible = isVisibleLengthFail;
		textBoxFailText2.IsVisible = isVisibleLengthFail;
		textBoxPasswordMatchFail.IsVisible = isVisibleMatchFail;
	}

	private void CreatUser(object sender, RoutedEventArgs e)
	{
		SetFailTextVisibility(false, false);

		try
		{
			if (textBoxPassword.Text != textBoxReInsertPassword.Text)
				throw new Exception();

			BankUserDatabase.Instance.CreateUser(textBoxUsername.Text, textBoxPassword.Text);

			textBoxUsername.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxReInsertPassword.Text = string.Empty;
		}
		catch (Exception)
		{
			SetFailTextVisibility(!(Login.CheckLength(textBoxPassword.Text) || Login.CheckLength(textBoxReInsertPassword.Text) || Login.CheckLength(textBoxUsername.Text)), textBoxPassword.Text != textBoxReInsertPassword.Text);
		}
	}

	private void GoToLogin(object sender, RoutedEventArgs e)
	{
		MainContent.Content = new LoginPage();
	}
}