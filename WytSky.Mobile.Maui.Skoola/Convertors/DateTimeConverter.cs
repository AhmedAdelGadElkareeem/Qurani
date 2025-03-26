﻿using System.Globalization;
using WytSky.Mobile.Maui.Skoola.AppResources;


namespace WytSky.Mobile.Maui.Skoola.Convertors;

public class DateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return SharedResources.Msg_NoDataFound;

        if (value is DateTime dateTime)
        {
            return dateTime.ToString("dddd, dd MMM yyyy, hh:mm tt"); // Example: "Sunday, 09 Mar 2025"
        }
        // Format includes both date and time (e.g., "Sunday, 09 Mar 2025, 12:34 PM")
        if (DateTime.TryParse(value.ToString(), out DateTime parsedDate))
        {
            return parsedDate.ToString("dddd, dd MMM yyyy, hh:mm tt");
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (DateTime.TryParse(value?.ToString(), out DateTime parsedDate))
        {
            return parsedDate;
        }

        return null;
    }
}
