using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankAccount;

public class Files
{
	private readonly static string AppSettingsFilePath = "../../../JSON/AppSettings.json";

	public static Dictionary<Images, string> ImageFiles = new Dictionary<Images, string>()
	{
		{ Images.Milk, "../../../Images/Milk.jpg"},
		{ Images.Suger, "../../../Images/Sugar.jpg" },
		{ Images.Battery, "../../../Images/battery.jpg"},
		{ Images.Car, "../../../Images/Car.jpg" },
		{ Images.Chair, "../../../Images/Chair.jpg"},
		{ Images.Charger, "../../../Images/Charger.jpg" },
		{ Images.QuestionMark, "../../../Images/QuestionMark.png"},
		{ Images.Seven, "../../../Images/Seven.jpg" },
		{Images.Grapes, "../../../Images/Grapes.jpg" },
		{Images.Orange, "../../../Images/Orange.jpg" },
		{Images.Cherry, "../../../Images/Cherry.jpg" },
		{Images.Bell, "../../../Images/Bell.jpg" },
	};

	public static Bitmap[] ImagesToBitmaps(Images[] images) =>
	[
		new(ImageFiles[images[0]]),
		new(ImageFiles[images[1]]),
		new(ImageFiles[images[2]])
	];

	private static JToken ReadJson<TKey, Type>(TKey key, string filePath)
		where Type : notnull
	{
		var jsonContent = File.ReadAllText(filePath);
		JObject keys = (JObject)JsonConvert.DeserializeObject(jsonContent);
		return keys[key];
	}

	public static string GetConnectionString() =>
		ReadJson<string, string>("ConnectionString", AppSettingsFilePath).Value<string>();
}
