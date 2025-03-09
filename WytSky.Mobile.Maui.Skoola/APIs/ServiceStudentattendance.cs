using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceStudentattendance
    {
        private const string BASE = "appservices";
        private const string CONTROLR = "Studentattendance";

        //https://qr.saskw.net/appservices/studygroupstudentlist?_datatype=json&_jsonarray=1
   
        public static async Task<ObservableCollection<StudentModel>> GetStudents()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                if (!string.IsNullOrEmpty(Settings.StudyGroupId))
                    dictionary.Add("GroupID", Settings.StudyGroupId);

                //else  dictionary.Add("GroupID", Settings.CenterId);

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentModel>>(BASE, "students", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudents");
                return null;
            }
        }
    }
}
