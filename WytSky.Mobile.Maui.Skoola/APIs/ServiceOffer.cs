using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Popups;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    internal class ServiceOffer
    {
        public const string BASE = "appservices";
        public const string CONTROLR = "StOffer";

        #region GetAllOffers()
        public async static Task<ObservableCollection<StOffer>> GetAllOffers(int pageIndex = 0, Dictionary<string, string> filter = null)
        {
            try
            {
                await App.ShowPopupService.Show(new LoadingPopup());
                if (filter == null)
                {
                    filter = new Dictionary<string, string>()
                    {
                        {"_datatype", "json"},
                        {"_jsonarray", "1"},
                        {"_pageSize", Services.ApiServices.PAGESIZE},
                        {"_pageIndex", pageIndex + ""},
                    };
                }
                else
                {
                    filter.Add("_datatype", "json");
                    filter.Add("_jsonarray", "1");
                    filter.Add("_pageSize", Services.ApiServices.PAGESIZE);
                    filter.Add("_pageIndex", pageIndex + "");
                }
                var result = await Services.RequestProvider.Current.GetData<TempletData<StOffer>>(BASE, CONTROLR, filter, Enums.AuthorizationType.UserNamePassword);
                App.ShowPopupService.Dispose();

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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceCatgeory", "GetAll()");
                return null;
            }
        }
        #endregion
    }
}
