using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;

namespace BankAccount;

public partial class CasinoSignUpPage : UserControl
{
    private Tuple<bool,bool> FailState = Tuple.Create(false, false);
    public CasinoSignUpPage()
    {
        InitializeComponent();
        var viewModel = new CasinoSignUpViewModel(MainContent.Content);
		DataContext = viewModel;

        comboBoxBankAccount.Items.Clear();
        comboBoxBankAccount.ItemsSource = BankUser.CurrentUser.BankAccounts;
	}

    private void UpdateUi(Tuple<bool, bool> fails)
    {
        
        Dispatcher.UIThread.Invoke(() =>
        {
			if (fails.Item1 && fails.Item2)
			{
				MainContent.Content = new LoginPage();
				return;
			}
			labelPasswordMatchingFailText.IsVisible = fails.Item1;
            labelPasswordLengthFailtext.IsVisible = fails.Item2;
        });
	}
}