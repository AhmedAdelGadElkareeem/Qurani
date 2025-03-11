
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs;

public class StudentStudyGroupList
{
    private const string BASE = "appservices";
    private const string CONTROLR = "StudyGroupStudentList";

    // https://qr.saskw.net/appservices/studygroups?_datatype=json&_jsonarray=1

    #region Get Study Groups
    public static async Task<ObservableCollection<StudyGroupModel>> GetStudyGroupStudentList()
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
            {
                {"_datatype", "json"},
                {"_jsonarray", "1"},
            };

            dictionary.Add("GroupID", Settings.StudyGroupId);

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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudyGroupStudentList", "GetStudyGroupStudentList");
            return null;
        }
    }
    #endregion

    #region AddStudyGroup
    public static async Task<Dtos.ReturnData> AddStudyGroupStudentList(Dictionary<string, object> formData)
    {
        try
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"_datatype","json"},
                {"_jsonarray","1"},
            };
            dictionary.Add("GroupID", Settings.StudyGroupId);

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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "StudyGroupStudentList", "AddStudyGroupStudentList");
            return null;
        }
    }
    #endregion
}
