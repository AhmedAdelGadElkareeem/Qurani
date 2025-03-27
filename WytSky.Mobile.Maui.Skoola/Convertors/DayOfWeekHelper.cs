
namespace WytSky.Mobile.Maui.Skoola.Convertors;

public static class DayOfWeekHelper
{
    private static readonly Dictionary<string, DayOfWeek> DayNameMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        // English mappings
        {"Sunday", DayOfWeek.Sunday},
        {"Monday", DayOfWeek.Monday},
        {"Tuesday", DayOfWeek.Tuesday},
        {"Wednesday", DayOfWeek.Wednesday},
        {"Thursday", DayOfWeek.Thursday},
        {"Friday", DayOfWeek.Friday},
        {"Saturday", DayOfWeek.Saturday},
        
        // Arabic mappings
        {"الأحد", DayOfWeek.Sunday},
        {"الإثنين", DayOfWeek.Monday},
        {"الثلاثاء", DayOfWeek.Tuesday},
        {"الأربعاء", DayOfWeek.Wednesday},
        {"الخميس", DayOfWeek.Thursday},
        {"الجمعة", DayOfWeek.Friday},
        {"السبت", DayOfWeek.Saturday}
    };

    public static DayOfWeek? ConvertToDayOfWeek(string dayName)
    {
        if (string.IsNullOrWhiteSpace(dayName))
            return null;

        return DayNameMappings.TryGetValue(dayName.Trim(), out var dayOfWeek)
            ? dayOfWeek
            : null;
    }

    public static string GetLocalizedDayName(DayOfWeek dayOfWeek)
    {
        return App.IsArabic
            ? DayNameMappings.First(x => x.Value == dayOfWeek && IsArabicDayName(x.Key)).Key
            : dayOfWeek.ToString();
    }

    private static bool IsArabicDayName(string name)
    {
        // Simple check for Arabic characters
        return name.Any(c => c >= 0x0600 && c <= 0x06FF);
    }
}
