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
    public CasinoSignUpPage()
    {
        InitializeComponent();
        DataContext = new CasinoSignUpViewModel(MainContent.Content);

        comboBoxBankAccount.Items.Clear();
        comboBoxBankAccount.ItemsSource = BankUser.CurrentUser.BankAccounts;
	}
}