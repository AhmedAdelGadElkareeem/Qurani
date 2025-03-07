using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Convertors;

public class InverseBoolConverter : IValueConverter
{
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Nullable<bool> res = null;
        try
        {
            if (value == null)
            {
                res = false;
            }
            else if ((value is bool))
            {
                res = !(bool)value;
            }
            else if (parameter == null)
            {
                res = false;
            }
            else
            {
                res = !value.ToString().Equals(parameter.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }


        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }
        return res;
    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return null;
    //    }

}
