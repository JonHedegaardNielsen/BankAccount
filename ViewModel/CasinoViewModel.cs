using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
namespace BankAccount;

public class CasinoViewModel : ReactiveObject
{
	private static string DefaultImageUrl = Files.ImageFiles[Images.QuestionMark];

	private string _urlSource1 = DefaultImageUrl;
	public string UrlSource1
	{
		get => _urlSource1;
		set => this.RaiseAndSetIfChanged(ref _urlSource1, value);
	}

	private string _urlSource2 = DefaultImageUrl;
	public string UrlSource2
	{
		get => _urlSource2;
		set => this.RaiseAndSetIfChanged(ref _urlSource2, value);
	}

	private string _urlSource3 = DefaultImageUrl;
	public string UrlSource3
	{
		get => _urlSource3;
		set => this.RaiseAndSetIfChanged(ref _urlSource3, value);
	}
}
