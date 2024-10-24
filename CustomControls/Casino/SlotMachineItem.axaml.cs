using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

namespace BankAccount;

public partial class SlotMachineItem : UserControl
{
	public static readonly StyledProperty<string> Source =
			AvaloniaProperty.Register<SlotMachineItem, string>(nameof(ImageSource));

	public string ImageSource
	{
		get => GetValue(Source);
		set
		{
			SetValue(Source, value);
			//imageSymbol.Source = new Bitmap(value);
		}
	}

	public SlotMachineItem()
	{
		InitializeComponent();
	}

	public void Play(Bitmap lastImage)
	{

	}
}