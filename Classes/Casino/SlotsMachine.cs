using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace BankAccount;

public class SlotsMachine
{
	private static Image[] Options =
	{
		Image.Cherry,
		Image.Grapes,
		Image.Orange,
		Image.Seven,
		Image.Bell,
	};

	Random rand = new Random();
	public static Dictionary<Image, Decimal> Rewards = new()
	{
		{Image.Cherry, 100m},
		{Image.Grapes, 100m},
		{Image.Orange, 300m},
		{Image.Seven, 200m},
		{Image.Bell, 500m },
	};

	private Image GetRandElement() =>
			Options[rand.Next(Options.Length)];

	public Image[] GetRandCompination() =>
		[ GetRandElement(), GetRandElement(), GetRandElement() ];

	private Image[] GetRandCombinationUnique()
	{
		Image[] result;

		do
		{
			result = GetRandCompination();
		} while (CheckCombinationMatching(result));
		
		return result;
	}

	private bool CheckCombinationMatching(Image[] images) =>
		images[0] == images[1] && images[0] == images[2];


	public bool Play(out Image[] images, out decimal reward)
	{
		images = GetRandCompination();

		if (images[0] == images[1] && images[0] == images[2])
		{
			reward = Rewards[images[0]];
			return true;
		}

		reward = 0m;
		return false;
	}

	public Bitmap[] GetRandCombinationAsBitmap() =>
		Files.ImagesToBitmaps(GetRandCompination());

	public Bitmap[] GetRandCombinationUniqueAsBitmap() => 
		Files.ImagesToBitmaps(GetRandCombinationUnique());
}
