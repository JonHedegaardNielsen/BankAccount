using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI;
namespace BankAccount;

public class CasinoViewModel : ReactiveObject
{
	private static Bitmap DefaultImageUrl = new(Files.ImageFiles[Images.QuestionMark]);

	private SlotsMachine SlotsMachine;

	public decimal CherryReward => SlotsMachine.Rewards[Images.Cherry];
	public decimal BellReward => SlotsMachine.Rewards[Images.Bell];
	public decimal GrapesReward => SlotsMachine.Rewards[Images.Grapes];
	public decimal SevenReward => SlotsMachine.Rewards[Images.Seven];
	public decimal OrangeReward => SlotsMachine.Rewards[Images.Orange];

	private UserControl _mainContent;
	public UserControl MainContent
	{
		get => _mainContent;
		set => this.RaiseAndSetIfChanged(ref _mainContent, value);
	}


	public decimal AmountToWinBack
	{
		get => CasinoUser.CurrentUser.AmountToWinBack > 0 ? CasinoUser.CurrentUser.AmountToWinBack : 0m;
		set => this.RaisePropertyChanged();
	}

	private decimal _reward;
	public decimal Reward
	{
		get => _reward;
		set => this.RaiseAndSetIfChanged(ref _reward, value);
	}

	private decimal _rewardTotal = CasinoWinsDatabase.Instance.GetTotalRewards(CasinoUser.CurrentUser.Id);
	public decimal RewardTotal
	{
		get => _rewardTotal;
		set => this.RaiseAndSetIfChanged(ref _rewardTotal, value);
	}

	

	private bool _failTextVisible = false;
	public bool FailTextVisible
	{
		get => _failTextVisible;
		set => this.RaiseAndSetIfChanged(ref _failTextVisible, value);
	}

	public decimal Cost => 20;

	private decimal _balance = CasinoUser.CurrentUser.BankAccount.Balance;
	public decimal Balance
	{
		get => _balance;
		set => this.RaiseAndSetIfChanged(ref _balance, value);
	}

	private Bitmap _urlSource1 = DefaultImageUrl;
	public Bitmap UrlSource1
	{
		get => _urlSource1;
		set => this.RaiseAndSetIfChanged(ref _urlSource1, value);
	}

	private Bitmap _urlSource2 = DefaultImageUrl;
	public Bitmap UrlSource2
	{
		get => _urlSource2;
		set => this.RaiseAndSetIfChanged(ref _urlSource2, value);
	}

	private Bitmap _urlSource3 = DefaultImageUrl;
	public Bitmap UrlSource3
	{
		get => _urlSource3;
		set => this.RaiseAndSetIfChanged(ref _urlSource3, value);
	}

	private bool isPlaying;

	public ReactiveCommand<Unit, Unit> PlaySlotsCommand { get; }
	public ReactiveCommand<Unit, Unit> LogOutCommand { get; }
	public ReactiveCommand<Unit, Unit> DeleteUserCommand { get; }

	public CasinoViewModel()
	{
		SlotsMachine = new SlotsMachine();
		PlaySlotsCommand = ReactiveCommand.Create(PlaySlots);
		MainContent = mainContent; 
	}

	private void Logout()
	{
		CasinoUser.CurrentUser = null;
	}

	private void SetSymbols(Bitmap[] bitmaps)
	{
		UrlSource1 = bitmaps[0];
		UrlSource2 = bitmaps[1];
		UrlSource3 = bitmaps[2];
	}

	private void LogoutCommand()
	{

	}

	private void PlaySlots()
	{
		if (isPlaying)
			return;

		Thread thread = new(() =>
		{
			isPlaying = true;

			if (CasinoUser.CurrentUser.BankAccount.Balance <= Cost)
			{
				FailTextVisible = true;
				return;
			}

			CasinoUser.CurrentUser.BankAccount.Balance -= Cost;
			TransactionDatabase.Instance.Insert(Cost, SpendingCategory.Gambling, CasinoUser.CurrentUser.Id);

			bool win = SlotsMachine.Play(out Images[] images, out decimal reward);

			CasinoUser.CurrentUser.AmountToWinBack += Cost - reward;
			this.RaisePropertyChanged(nameof(AmountToWinBack));

			CasinoUserDatabase.Instance.UpdateAmountToWinBack(AmountToWinBack, CasinoUser.CurrentUser.Id);

			for (int i = 0; i <= 10; i++)
			{
				SetSymbols(SlotsMachine.GetRandCombinationAsBitmap());
				Thread.Sleep(200);
			}

			if (win)
			{
				CasinoUser.CurrentUser.BankAccount.Balance += reward;
				CasinoWinsDatabase.Instance.Insert(reward, CasinoUser.CurrentUser.Id);
				RewardTotal += reward;
			}
			
			Reward = reward;
			BankAccountDatabase.Instance.UpdateBalance(CasinoUser.CurrentUser.BankAccount.Id, CasinoUser.CurrentUser.BankAccount.Balance);
			Balance = CasinoUser.CurrentUser.BankAccount.Balance;
			SetSymbols(Files.ImagesToBitmaps(images));

			isPlaying = false;
		});

		thread.Start();
	}


}
