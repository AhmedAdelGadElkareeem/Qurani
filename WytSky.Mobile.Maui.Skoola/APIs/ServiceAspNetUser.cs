﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceAspNetUser
    {
        public const string BASE = "appservices";
        public const string CONTROLR = "AspNetUsers";

        #region GetAll()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.AspNetUser>> GetAll(int pageIndex = 0, Dictionary<string, string> filter = null)
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
                var result = await Services.RequestProvider.Current.GetData<Models.TempletData<Dtos.AspNetUser>>(BASE, CONTROLR, filter, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data.itemData;
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(filter), "ServiceWorkshopAspNetUser", "GetAll()");
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceWorkshopAspNetUser", "SaveNew()");
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceWorkshopAspNetUser", "Update()");
                return null;
            }
        }
        #endregion
    }
}
