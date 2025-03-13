using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs;

public class StudyGroupService
{
    private const string BASE = "appservices";
    private const string CONTROLR = "studygroups";

    // https://qr.saskw.net/appservices/studygroups?_datatype=json&_jsonarray=1
    #region Get Study Groups
    public static async Task<ObservableCollection<StudyGroupModel>> GetStudyGroupsByCenterId()
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
            {
                {"_datatype", "json"},
                {"_jsonarray", "1"},
            };

            //if (!string.IsNullOrEmpty(Settings.StaffId))
            //    dictionary.Add("TeacherID", Settings.StaffId);
            //else  
                dictionary.Add("CenterID", Settings.CenterId);
            
            var result = await Services.RequestProvider.Current.GetData<TempletData<StudyGroupModel>>(BASE, CONTROLR, dictionary, Enums.AuthorizationType.UserNamePassword);
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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudyGroupService", "GetStudyGroups");
            return null;
        }
    }
    public static async Task<ObservableCollection<StudyGroupModel>> GetStudyGroupsByTeacherId(int id)
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
            {
                {"_datatype", "json"},
                {"_jsonarray", "1"},
            };

            //if (!string.IsNullOrEmpty(Settings.StaffId))
            //    dictionary.Add("TeacherID", Settings.StaffId);
            //else  
            dictionary.Add("TeacherID", id.ToString());

            var result = await Services.RequestProvider.Current.GetData<TempletData<StudyGroupModel>>(BASE, CONTROLR, dictionary, Enums.AuthorizationType.UserNamePassword);
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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudyGroupService", "GetStudyGroupsByTeacherId");
            return null;
        }
    }
    #endregion

    #region AddStudyGroup
    public static async Task<Dtos.ReturnData> AddStudyGroup(Dictionary<string, object> formData)
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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "StudyGroupService", "AddStudyGroup");
            return null;
        }
    }
    #endregion
}