using Avalonia.Controls;
using System.IO;
using System;
using System.Windows;
using Avalonia.Markup;
using Avalonia.Interactivity;


namespace BankAccount
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnWindowLoaded(object sender, RoutedEventArgs e)
		{
			this.FindControl<ContentControl>("MainContent").Content = new LoginPage();
		}

	}
}