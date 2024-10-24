using Avalonia.Controls;
using System;

namespace BankAccount;

public partial class BankMainPage : UserControl
{
	private string AmountToTranferText = String.Empty;
	private string IdToTransferTo = String.Empty;
	BankMainPageViewModel BankViewModel;

	public BankMainPage()
	{
		InitializeComponent();
		BankUser.UpdateCurrentUser();
		BankViewModel = new BankMainPageViewModel(MainContent.Content);
		DataContext = BankViewModel;
	}

	private void TextBoxDecimalParseValidation(object? sender, TextChangedEventArgs e)
	{
		if (sender is TextBox textBox)
			TextBoxParseValidation(textBox, text => decimal.TryParse(text, out decimal _), ref AmountToTranferText, e);
	}

	private void TextBoxIntParseValidation(object? sender, TextChangedEventArgs e)
	{
		if (sender is TextBox textBox)
			TextBoxParseValidation(textBox, text => int.TryParse(text, out int _), ref IdToTransferTo, e);
	}

	private void TextBoxParseValidation(TextBox textBox, Func<string, bool> canParse, ref string originalText, TextChangedEventArgs e)
	{
		if (textBox.Text != null && (String.IsNullOrWhiteSpace(textBox.Text) || canParse(textBox.Text)))
		{
			originalText = textBox.Text;
			textBox.CaretIndex = textBox.Text.Length;
		}
		else
			textBox.Text = originalText;
	}
}