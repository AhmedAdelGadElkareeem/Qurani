using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Models.Qurani.Students;
using WytSky.Mobile.Maui.Skoola.Models.Qurani.StudyGroup;

namespace WytSky.Mobile.Maui.Skoola.APIs.StudyGroups;

public class StudyGroupService
{
     private const string BASE = "appservices";
     private const string CONTROLR = "studygroups";

        // https://qr.saskw.net/appservices/studygroupstudentlist?datatype=json&jsonarray=1&GroupID=1 
        #region Get Study Groups
        public static async Task<ObservableCollection<StudyGroupModel>> GetStudyGroups(string staffId = null, string centerId= null)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                
                if(staffId != null)
                    dictionary.Add("TeacherID", staffId);
                else
                    dictionary.Add("CenterID", centerId);
                
                var result = await Services.RequestProvider.Current.GetData<TempletData<StudyGroupModel>>(BASE, CONTROLR, dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudyGroupService", "GetStudyGroups");
                return null;
            }
        }
        #endregion
        
        #region Add Student
        public static async Task<Dtos.ReturnData> AddStudyGroup(Dictionary<string, object> formData)
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "StudyGroupService", "AddStudent");
                return null;
            }
        }
        #endregion
}