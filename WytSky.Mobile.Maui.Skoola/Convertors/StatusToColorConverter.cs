
using System.Globalization;
using WytSky.Mobile.Maui.Skoola.AppResources;

namespace WytSky.Mobile.Maui.Skoola.Convertors;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return Colors.Orange; // Absent

        if (value.ToString() == SharedResources.Present)
        {
            return  Colors.Green ; 
        }
        
        if(value.ToString() == SharedResources.NotPresent) { return Colors.Red ; }

        return Colors.Orange; // Default (Absent)
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Color color)
        {
            if (color == Colors.Green) return 1;  // Present
            if (color == Colors.Red) return 0;    // Not Present
            if (color == Colors.Orange) return null; // Absent
        }

        return null; // Default case
    }

}