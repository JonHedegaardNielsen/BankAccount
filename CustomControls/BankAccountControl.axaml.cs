using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace BankAccount;

public partial class BankAccountControl : UserControl
{
    BankAccount BankAccount { get; set; }

    public BankAccountControl() 
    {
        InitializeComponent();
    }

    public BankAccountControl(BankAccount bankAccount)
    {
        InitializeComponent();
        DataContext = bankAccount;
	}
}