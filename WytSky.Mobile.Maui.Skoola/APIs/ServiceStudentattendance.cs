using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceStudentattendance
    {
        private const string BASE = "appservices";
        private const string CONTROLR = "Studentattendance";
        public const string FormUpdate = "api/formupdate/getupdate";
        public const string KeyName = "StudentID";
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

        #region StudentAttendanceByStudyGroup
        public async static Task<ObservableCollection<StudentattendanceModel>> GetStudentAttendanceByStudyGroupID
                                                                                (string studentId, string groupId)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                      {"StudentID", studentId},
                      {"GroupID", groupId},
                };

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentattendanceModel>>(BASE, "studentattendance", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceComplex", "GetParentCategories");
                return null;
            }
        }
        #endregion

        #region Update Student Attedance
        public async static Task<ObservableCollection<AttendanceModel>> UpdateStudentAttendance(Dictionary<string, object> formData)
        {
            try
            {
                var dictionary = new Dictionary<string, string>
                {
                    { "_datatype", "json" },
                    { "_jsonarray", "1" },
                    { "_key", Settings.AttendanceId },
                    { "_keyname", "AttendanceID" }
                    //{ "_key", Settings.StudentId },
                    //{ "_keyname", "StudentID" },
                };

                // Add form data while ensuring null values are not added
                foreach (var item in formData)
                {
                    if (item.Value != null)
                        dictionary[item.Key] = item.Value.ToString();
                }

                // Call API
                var result = await Services.RequestProvider.Current.GetUpdate<TempletData<AttendanceModel>>(
                    FormUpdate, "studentattendance", dictionary, Enums.AuthorizationType.UserNamePassword);

                // Ensure result and data are valid
                if (result == null || !result.IsPassed || result.Data == null)
                {
                    Debug.WriteLine("❌ Update failed: Response is null or not passed.");
                    return null;
                }

                Debug.WriteLine("✅ Update Successful!");
                return result.Data.itemData ?? new ObservableCollection<AttendanceModel>();
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
}
