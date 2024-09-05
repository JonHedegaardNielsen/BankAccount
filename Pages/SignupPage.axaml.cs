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
		bool CheckLength(string text)
		{
			try
			{
				return text.Length >= 8 && text.Length <= 32;
			}
			catch(NullReferenceException)
			{
				return false;
			}
		}

		SetFailTextVisibility(false, false);
		try
		{
			BankUserDatabase.Instance.CreateUser(textBoxUsername.Text, textBoxPassword.Text);

			textBoxUsername.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxReInsertPassword.Text = string.Empty;
		}
		catch (Exception)
		{
			SetFailTextVisibility(!(CheckLength(textBoxPassword.Text) || CheckLength(textBoxReInsertPassword.Text) || CheckLength(textBoxUsername.Text)), textBoxPassword.Text != textBoxReInsertPassword.Text);
		}
	}

	private void GoToLogin(object sender, RoutedEventArgs e)
	{
		this.FindControl<ContentControl>("MainContent").Content = new LoginPage();
	}
}