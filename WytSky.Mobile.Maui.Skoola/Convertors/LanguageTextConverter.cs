
using System.Globalization;

namespace WytSky.Mobile.Maui.Skoola.Convertors;

public class LanguageTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string currentLang = value as string;
        if (currentLang == "en")
        {
            return "العربية";
        }
        else
        {
            return "English";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
