using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceSchedule
    {
        public const string BASE = "appservices";

        public async static Task<ObservableCollection<ScheduleModel>> GetScheduleGroup()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"GroupID", Helpers.Settings.StudyGroupId},
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<ScheduleModel>>(BASE, "Schedule", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceCatgeory", "GetParentCategories");
                return null;
            }
        }
        public async static Task<ScheduleModel> AddScheduleGroup(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<ScheduleModel>(BASE, "Schedule", dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceCartItem", "SaveNew()");
                return null;
            }
        }

    }
}
