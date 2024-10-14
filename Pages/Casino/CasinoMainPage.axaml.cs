using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Runtime.CompilerServices;

namespace BankAccount;

public partial class CasinoMainPage : UserControl
{
    public CasinoMainPage()
    {
        InitializeComponent();
        DataContext = new CasinoViewModel();
    }
}