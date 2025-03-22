using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs;

public class StudyGroupService
{
    private const string BASE = "appservices";
    private const string CONTROLR = "studygroups";
    public const string FormUpdate = "api/formupdate/getupdate";
    public const string KeyName = "GroupID";


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
    public static async Task<ObservableCollection<StudyGroupModel>> GetStudyGroupsByTeacherId(string id)
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

    #region Edit StudyGroup 
    public async static Task<ObservableCollection<ComplexModel>> UpdateStaff(Dictionary<string, object> formData)
    {
        try
        {
            var dictionary = new Dictionary<string, string>
         {
             { "_datatype", "json" },
             { "_jsonarray", "1" },
             { "_key", Settings.StudyGroupId },
             { "_keyname", KeyName }
         };

            // Add form data while ensuring null values are not added
            foreach (var item in formData)
            {
                if (item.Value != null)
                    dictionary[item.Key] = item.Value.ToString();
            }

            // Call API
            var result = await Services.RequestProvider.Current.GetUpdate<TempletData<ComplexModel>>(
                FormUpdate, CONTROLR , dictionary, Enums.AuthorizationType.UserNamePassword
            );

            // Ensure result and data are valid
            if (result == null || !result.IsPassed || result.Data == null)
            {
                Debug.WriteLine("? Update failed: Response is null or not passed.");
                return null;
            }

            Debug.WriteLine("? Update Successful!");
            return result.Data.itemData ?? new ObservableCollection<ComplexModel>();
        }
        catch (Exception ex)
        {
            string exceptionMessage = $"Error: {ex.Message} | Inner Exception: {(ex.InnerException != null ? ex.InnerException.Message : "None")}";
            System.Diagnostics.Debug.WriteLine(exceptionMessage);
            ExtensionLogMethods.LogExtension(exceptionMessage, $"Form Data: {JsonSerializer.Serialize(formData)}", "ServiceComplex", "UpdateComplex");
            return null;
        }
    }
    #endregion
}