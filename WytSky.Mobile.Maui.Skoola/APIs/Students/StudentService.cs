using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Models.Qurani.Students;

namespace WytSky.Mobile.Maui.Skoola.APIs.Students
{
    public class StudentService
    {
        private const string BASE = "appservices";
        private const string CONTROLR = "students";

        // https://qr.saskw.net/appservices/studygroupstudentlist?datatype=json&jsonarray=1&GroupID=1 
        #region Get Students
        public static async Task<ObservableCollection<StudentModel>> GetStudents(string groupID)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"GroupID", groupID},
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentModel>>(BASE, "studygroupstudentlist", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudents");
                return null;
            }
        }
        #endregion
        
        #region Add Student
        public static async Task<Dtos.ReturnData> AddStudent(Dictionary<string, object> formData)
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceItem", "SaveNew()");
                return null;
            }
        }
        #endregion
    }
}
