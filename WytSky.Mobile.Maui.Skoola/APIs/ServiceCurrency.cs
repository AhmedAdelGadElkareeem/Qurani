using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceCurrency
    {
        public const string BASE = "appservices";
        public const string CONTROLR = "StCurrency";

        #region GetAll()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.StCurrency>> GetAll(int pageIndex = 0, Dictionary<string, string> filter = null)
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
                var result = await Services.RequestProvider.Current.GetData<Models.TempletData<Dtos.StCurrency>>(BASE, CONTROLR, filter, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceCurrency", "GetAll()");
                return null;
            }
        }
        #endregion

        #region SaveNew()
        public async static System.Threading.Tasks.Task<Dtos.ReturnData> SaveNew(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<Dtos.ReturnData>(BASE , CONTROLR, dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceCurrency", "SaveNew()");
                return null;
            }
        }
        #endregion

        #region Update()
        public async static System.Threading.Tasks.Task<Dtos.ReturnData> Update(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<Dtos.ReturnData>(BASE, CONTROLR, dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceCurrency", "Update()");
                return null;
            }
        }
        #endregion
    }
}
