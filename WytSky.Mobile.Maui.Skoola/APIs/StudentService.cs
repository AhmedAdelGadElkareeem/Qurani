using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class StudentService
    {
        private const string BASE = "appservices";
        private const string CONTROLR = "students";
        public const string FormUpdate = "api/formupdate/getupdate";
        public const string KeyName = "StudentID";

        //https://qr.saskw.net/appservices/studygroupstudentlist?_datatype=json&_jsonarray=1
        #region Get Students
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
        #endregion

        #region GetStudentsByCenterId
        public static async Task<ObservableCollection<StudentModel>> GetStudentsByCenterId()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                if (!string.IsNullOrEmpty(Settings.CenterId))
                    dictionary.Add("CenterID", Settings.CenterId);

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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudentsByCenterId");
                return null;
            }
        }
        #endregion

        #region Get StudentById & GroupID
        public static async Task<ObservableCollection<StudentModel>> GetStudentByIdAndGroupID()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                if (!string.IsNullOrEmpty(Settings.StudentId) && !string.IsNullOrEmpty(Settings.StudyGroupId))
                {
                    dictionary.Add("StudentD", Settings.StudentId);
                    dictionary.Add("GroupID", Settings.StudyGroupId);
                }

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
        #endregion
        #region Get All Students
        public static async Task<ObservableCollection<StudentModel>> GetAllStudents()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                //if (!string.IsNullOrEmpty(Settings.StudyGroupId))
                //    dictionary.Add("GroupID", Settings.StudyGroupId);

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

        public static async Task<ObservableCollection<StudyGroupStudentList>> GetStudyGroupStudentList()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                dictionary.Add("GroupID", Settings.StudyGroupId);

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudyGroupStudentList>>(BASE, "studygroupstudentlist", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudyGroupStudentList");
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceItem", "SaveNew()");
                return null;
            }
        }
        #endregion
        #region Update Student
        public async static Task<ObservableCollection<StudentModel>> UpdateStudent(Dictionary<string, object> formData)
        {
            try
            {
                var dictionary = new Dictionary<string, string>
                {
                    { "_datatype", "json" },
                    { "_jsonarray", "1" },
                    { "_key", Settings.StudentId },
                    { "_keyname", KeyName }
                };

                // Add form data while ensuring null values are not added
                foreach (var item in formData)
                {
                    if (item.Value != null)
                        dictionary[item.Key] = item.Value.ToString();
                }

                // Call API
                var result = await Services.RequestProvider.Current.GetUpdate<TempletData<StudentModel>>(
                    FormUpdate, "students", dictionary, Enums.AuthorizationType.UserNamePassword);

                // Ensure result and data are valid
                if (result == null || !result.IsPassed || result.Data == null)
                {
                    Debug.WriteLine("❌ Update failed: Response is null or not passed.");
                    return null;
                }

                Debug.WriteLine("✅ Update Successful!");
                return result.Data.itemData ?? new ObservableCollection<StudentModel>();
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
