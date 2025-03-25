using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace WytSky.Mobile.Maui.Skoola.Convertors;

public class TimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return string.Empty;

        // ✅ If value is already a TimeSpan
        if (value is TimeSpan timeSpan)
        {
            return DateTime.Today.Add(timeSpan).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        // ✅ If value is a string and needs to be parsed as TimeSpan
        if (value is string timeString && TimeSpan.TryParse(timeString, out TimeSpan parsedTime))
        {
            return DateTime.Today.Add(parsedTime).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        return value.ToString(); // Fallback
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string timeString && DateTime.TryParseExact(timeString, "hh:mm tt",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
        {
            return parsedDateTime.TimeOfDay; // ✅ Convert string "11:31 AM" back to TimeSpan
        }

        return null;
    }
}
