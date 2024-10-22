using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class DecimalConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is decimal valueDecimal)
		{
			return valueDecimal.ToString(culture);
		}

		return String.Empty;
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
		if (value is string valueString )
		{
			if (decimal.TryParse(valueString, NumberStyles.Any, culture, out decimal decimalValue))
				return decimalValue;
		}

		return null;
	}

}
