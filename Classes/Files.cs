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

	public static Dictionary<Image, string> ImageFiles = new Dictionary<Image, string>()
	{
		{ Image.Milk, "../../../Images/Milk.jpg"},
		{ Image.Suger, "../../../Images/Sugar.jpg" },
		{ Image.Battery, "../../../Images/battery.jpg"},
		{ Image.Car, "../../../Images/Car.jpg" },
		{ Image.Chair, "../../../Images/Chair.jpg"},
		{ Image.Charger, "../../../Images/Charger.jpg" },
		{ Image.QuestionMark, "../../../Images/QuestionMark.png"},
		{ Image.Seven, "../../../Images/Seven.jpg" },
		{Image.Grapes, "../../../Images/Grapes.jpg" },
		{Image.Orange, "../../../Images/Orange.jpg" },
		{Image.Cherry, "../../../Images/Cherry.jpg" },
		{Image.Bell, "../../../Images/Bell.jpg" },
	};

	public static Bitmap[] ImagesToBitmaps(Image[] images) =>
	[
		new(ImageFiles[images[0]]),
		new(ImageFiles[images[1]]),
		new(ImageFiles[images[2]])
	];

	private static JToken ReadJson<TKey, Type>(TKey key, string filePath)
		where Type : notnull
	{
		var jsonContent = File.ReadAllText(filePath);
		object? obj = JsonConvert.DeserializeObject(jsonContent);

		if (obj != null)
		{
			JObject keys = (JObject)obj;
			return keys[key];
		}

		throw new JsonReaderException();
	}

	public static string GetConnectionString() =>
		ReadJson<string, string>("ConnectionString", AppSettingsFilePath).Value<string>();
}
