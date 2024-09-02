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
		string password = Login.PasswordToString(Password);

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

		string reInsertPassword = Login.PasswordToString(ReInsertPassword);
		SetFailTextVisibility(false, false);
		try
		{
			UserDatabase.Instance.CreateUser(textBoxUsername.Text, Login.PasswordToString(Password));

			textBoxUsername.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxReInsertPassword.Text = string.Empty;
		}
		catch (Exception)
		{
			SetFailTextVisibility(!(CheckLength(password) || CheckLength(reInsertPassword) || CheckLength(textBoxUsername.Text)), password != reInsertPassword);
		}
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