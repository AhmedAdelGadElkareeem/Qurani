using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceCountriesRegions
    {
        private const string BASE = "appservices";

        // https://qr.saskw.net/appservices/countries?_datatype=json&_jsonarray=1
        public static async Task<ObservableCollection<CountryModel>> GetCountries()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                var result = await Services.RequestProvider.Current.GetData<TempletData<CountryModel>>(BASE, "countries", dictionary, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data.ItemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceCountries", "GetCountries");
                return null;
            }
        }

        // https://qr.saskw.net/appservices/regions?_datatype=json&_jsonarray=1
        public static async Task<ObservableCollection<RegionModel>> GetRegions(string countryId)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                      {"CountryID", countryId},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<RegionModel>>(BASE, "regions", dictionary, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data.ItemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceCountries", "GetCountries");
                return null;
            }
        }
    }
}
