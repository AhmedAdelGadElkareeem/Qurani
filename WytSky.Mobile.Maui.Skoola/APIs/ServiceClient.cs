using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceClient
    {
        public const string BASE = "appservices";
        public const string CONTROLR = "StClient";

        #region GetAll()
        public async static Task<ObservableCollection<Dtos.StClient>> GetAll(int pageIndex = 0, Dictionary<string, string> filter = null)
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
                var result = await Services.RequestProvider.Current.GetDataNoLoding<TempletData<StClient>>(BASE, CONTROLR, filter, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceClient", "GetAll()");
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

                var result = await Services.RequestProvider.Current.PostDataMultipartNoLoding<Dtos.ReturnData>(BASE , CONTROLR, dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceClient", "SaveNew()");
                return null;
            }
        }
        #endregion

        #region Update()
        public async static System.Threading.Tasks.Task<Dtos.ReturnData> Update(Dictionary<string, object> formData)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                    {"_datatype", "json"},
                    {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.PutDataMultipart<Dtos.ReturnData>(BASE, CONTROLR, dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceClient", "Update()");
                return null;
            }
        }
        #endregion

        #region UpdateCLientFbToken(string userName,string FbToken)
        public async static System.Threading.Tasks.Task<Models.ResultApi<object>> UpdateCLientFbToken()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                    {"userName", Settings.UserName},
                    {"SocialID", Settings.UserName},
                    // {"FbToken", Plugin.FirebasePushNotification.CrossFirebasePushNotification.Current.Token},
                };
                var result = await Services.RequestProvider.Current.GetDataWithBaseUrlNoLoading<object>("v1StClient", $"UpdateCLientFbToken", dictionary, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceTechnical", "UpdateCLient()");
                return null;
            }
        }
        #endregion
        
        #region UpdateCLient(Dtos.StClient item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<Dtos.StClient>> UpdateCLient(Dtos.StClient item)
        {
            try
            {
                item.ModifiedBy = Settings.UserName;
                item.FbToken = Settings.DeviceToken;
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrl<Dtos.StClient, Dtos.StClient>(item, "v1StClient", "UpdateCLient", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "UpdateCLient()");
                return null;
            }
        }
        #endregion

        #region RestPassword(object item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<object>> RestPassword(object item)
        {
            try
            {
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrl<object, object>(item, "v1Identity", "RestPassword", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "UpdateCLient()");
                return null;
            }
        }
        #endregion

        #region ChangePassword(object item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<object>> ChangePassword(object item)
        {
            try
            {
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrl<object, object>(item, "v1Identity", "ChangePassword", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "UpdateCLient()");
                return null;
            }
        }
        #endregion
        
        #region SignUp(Dtos.StClient item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<object>> SignUp(Dtos.StClientSocial item)
        {
            try
            {
                item.FbToken = Settings.DeviceToken;
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrlNoLoading<object, Dtos.StClientSocial>(item, "v1StClient", "CreateCLient", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "SignUp()");
                return null;
            }
        }
        #endregion

        #region GetCLientByEmail(string email)
        public async static System.Threading.Tasks.Task<Models.ResultApi<Dtos.StClient>> GetCLientByEmail(string email)
        {
            try
            {
                var result = await Services.RequestProvider.Current.GetDataWithBaseUrl<Dtos.StClient>("v1StClient", $"GetCLientByEmail?email={email}", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, email , "ServiceTechnical", "SignUp()");
                return null;
            }
        }
        #endregion
        
        #region ResendVerficationCode(object item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<Models.Verfication>> ResendVerficationCode(object item)
        {
            try
            {
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrl<Models.Verfication, object>(item, "v1Identity", "ResendVerficationCode", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "SignUp()");
                return null;
            }
        }
        #endregion

        #region SignUpSocial(Dtos.StClient item)
        public async static System.Threading.Tasks.Task<Models.ResultApi<object>> SignUpSocial(Dtos.StClientSocial item)
        {
            try
            {
                item.FbToken = Settings.DeviceToken;
                var result = await Services.RequestProvider.Current.PostDataWithBaseUrlNoLoading<object, Dtos.StClientSocial>(item, "v1StClient", "socialRegister", null, "http://skyaibak.saskw.online", "api/", Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.success)
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(item), "ServiceTechnical", "SignUp()");
                return null;
            }
        }
        #endregion





    }
}
