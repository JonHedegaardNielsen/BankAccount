using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankAccount;

public class SlotsMachine
{
	private static Images[] Options =
	{
		Images.Cherry,
		Images.Grapes,
		Images.Orange,
		Images.Seven
	};

	Random rand = new Random();
	private static Dictionary<Images, Decimal> Rewards = new()
	{
		{Images.Cherry, 100},
		{Images.Grapes, 100},
		{Images.Orange, 100},
		{Images.Seven, 100},
	};

	private Images GetRandElement() =>
			Options[rand.Next(Options.Length)];

	public Images[] GetRandCompination() =>
		new Images[3] { GetRandElement(), GetRandElement(), GetRandElement() };

	private Images[] GetRandCombinationUnique()
	{
		Images[] result;
		do
		{
			result = GetRandCompination();
		} while (CheckCombinationMatching(result));
		
		return result;
	}

	private bool CheckCombinationMatching(Images[] images) =>
		images[0] == images[1] && images[0] == images[2];


	public bool Play(out Images[] images, out decimal reward)
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
