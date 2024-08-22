using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace BankAccount;

public partial class MainPage : UserControl
{
    User? User;

	public MainPage()
	{
		InitializeComponent();
	}

	public MainPage(User user)
    {
        User = user;
        InitializeComponent();
    }

	private void BankAccountLoaded(object sender, RoutedEventArgs e)
	{
		Grid grid = (Grid)sender;
        int rowCounter = 0;

		foreach (var bankAccount in User.BankAccounts)
		{
			var child = new BankAccountControl(bankAccount);
			child.SetValue(Grid.RowProperty, rowCounter);
			grid.Children.Add(child);
			rowCounter++;
		}
	}
	
	private void LoadLoan(object sender, RoutedEventArgs e)
	{
		Grid grid = (Grid)sender;
		int rowCounter = 0;

		foreach (var loan in User.Loans)
		{
			var child = new LoanControl(loan);
			child.SetValue(Grid.RowProperty, rowCounter);
			grid.Children.Add(child);
			rowCounter++;
		}
	}

	private void Changeopage(UserControl page)
	{
		this.FindControl<ContentControl>("MainContent").Content = page;
	}


	private void CreateNewBankAccount(object sender , RoutedEventArgs e)
	{
		//Changeopage(new CreateLoanPage(User));
	}

	private void CreateLoan(object sender, RoutedEventArgs e)
	{
		Changeopage(new CreateLoanPage(User));
	}
}