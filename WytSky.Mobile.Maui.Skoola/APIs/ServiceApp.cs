
using System.Text.Json;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceApp
    {
        public const string CONTROLR = "appservices";

        #region GetAllNoLoding()

        public async static Task<System.Collections.ObjectModel.ObservableCollection<T>> GetAllNoLoding<T>(string pageNane, int pageIndex = 0, Dictionary<string, string> filter = null)
        {
            try
            {
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
                var result = await Services.RequestProvider.Current.GetDataNoLoding<TempletData<T>>(CONTROLR, pageNane, filter, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceChat", "GetAll()");
                return null;
            }
        }

        #endregion

        #region GetAll()

        public async static Task<System.Collections.ObjectModel.ObservableCollection<T>> GetAll<T>(string pageNane, int pageIndex = 0, Dictionary<string, string> filter = null, bool isLoading = true)
        {
            try
            {
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
                    filter.Add("_pageIndex", pageIndex + "");

                    if (filter.ContainsKey("pageSize"))
                        filter.Add("_pageSize", "5"); // used in home vm to get nearest 5 
                    else
                        filter.Add("_pageSize", Services.ApiServices.PAGESIZE);
                }

                var result = await Services.RequestProvider.Current.GetData<TempletData<T>>(CONTROLR, pageNane, filter, Enums.AuthorizationType.UserNamePassword, isLoading);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceChat", "GetAll()");
                return null;
            }
        }

        #endregion

        #region GetDaitCatgeoryItems()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.CatgeoryDto>> GetDaitCatgeoryItems()
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };
                var result = await Services.RequestProvider.Current.GetData<Models.TempletData<Dtos.CatgeoryDto>>(CONTROLR, "DaitCatgeoryItems", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion

        #region GetDaititems()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.ItemDto>> GetDaititems()
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<ItemDto>>(CONTROLR, "daititems", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion

        #region _auth()
        public async static Task<Dtos.CustomerDto> auth(string userName, string password)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"skyuser",userName},
                    {"skyuserpwd",password},
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };
                var result = await Services.RequestProvider.Current.GetData<Dtos.CustomerDto>(CONTROLR, "_auth", dictionary, Enums.AuthorizationType.nun);
                if (result != null && result.IsPassed)
                {
                    return result.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion
    }
}
