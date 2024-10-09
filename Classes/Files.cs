using Avalonia.Media.Imaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Files
{
	public static Dictionary<Images, string> ImageFiles =  new Dictionary<Images, string>()
	{
		{ Images.Milk, "../../../Images/Milk.jpg"},
		{ Images.Suger, "../../../Images/Sugar.jpg" },
		{ Images.Battery, "../../../Images/battery.jpg"},
		{ Images.Car, "../../../Images/Car.jpg" },
		{ Images.Chair, "../../../Images/Chair.jpg"},
		{ Images.Charger, "../../../Images/Charger.jpg" },
		{ Images.QuestionMark, "../../../Images/QuestionMark.png"}
		};
}
