using System;
using System.Collections.Generic;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceOrderStage
    {
        public const string BASE = "appservices";
        public const string CONTROLR = "StOrderStage";

        #region GetAll()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.StOrderStage>> GetAll(int pageIndex = 0, Dictionary<string, string> filter = null)
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
                var result = await Services.RequestProvider.Current.GetData<Models.TempletData<Dtos.StOrderStage>>(BASE, CONTROLR, filter, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceOrderStage", "GetAll()");
                return null;
            }
        }
        #endregion

        #region SaveNew()
        public async static Task<Dtos.ReturnData> SaveNew(OrderStageModel orderStageModel,bool isLoading)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostData<ReturnData, OrderStageModel>(orderStageModel, BASE, CONTROLR, dictionary, Enums.AuthorizationType.UserNamePassword, isLoading);
                //var result = await Services.RequestProvider.Current.PostDataMultipart<Dtos.ReturnData>(BASE , CONTROLR, dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(orderStageModel), "ServiceOrderStage", "SaveNew()");
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceOrderStage", "Update()");
                return null;
            }
        }
        #endregion

        #region UpdateOrderStage(Dtos.WytSky.Mobile.Maui.Skoola item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<object>> UpdateOrderStage(Dtos.StOrderStage item)
        {
            try
            {
                item.ModifiedBy = Settings.UserName;
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrl<object, Dtos.StOrderStage>(item, "v1WytSkyECommerceTalabat", "UpdateStOrderStage", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
                if (result != null)
                {
                    return result;
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "UpdateOrderStage()");
                return null;
            }
        }
        #endregion
    }
}
