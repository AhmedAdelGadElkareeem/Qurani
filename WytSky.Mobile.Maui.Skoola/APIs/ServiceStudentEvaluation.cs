using WytSky.Mobile.Maui.Skoola.Helpers;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Models;
using System.Diagnostics;
using System.Text.Json;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceStudentEvaluation
    {
        public const string BASE = "appservices";
        public const string FormUpdate = "api/formupdate/getupdate";
        public const string KeyName = "EvaluationID";

        #region GetStudentEvulationBySessionId
        public async static Task<ObservableCollection<StudentEvaluationModel>> GetStudentEvulationBySessionId()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                      {"SessionID", Settings.SessionId},
                };

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentEvaluationModel>>(BASE, "studentevaluation", dictionary, Enums.AuthorizationType.UserNamePassword);
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

        #region GetStudentEvulationByEvaluationID
        public async static Task<ObservableCollection<StudentEvaluationModel>> GetStudentEvulationByEvaluationID()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                      {"SessionID", Settings.SessionId},
                };

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentEvaluationModel>>(BASE, "studentevaluation", dictionary, Enums.AuthorizationType.UserNamePassword);
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

        #region AddStudentEvulation
        public async static Task<StudentEvaluationModel> AddStudentEvulation(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<StudentEvaluationModel>(BASE, "studentevaluation", dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
        #endregion

        #region UpdateStudentEvulation
        public async static Task<ObservableCollection<StudentEvaluationModel>> UpdateStudentEvulation(Dictionary<string, object> formData)
        {
            try
            {
                var dictionary = new Dictionary<string, string>
                {
                    { "_datatype", "json" },
                    { "_jsonarray", "1" },
                    { "_key", Settings.EvulationId },
                    { "_keyname", KeyName }
                };

                // Add form data while ensuring null values are not added
                foreach (var item in formData)
                {
                    if (item.Value != null)
                        dictionary[item.Key] = item.Value.ToString();
                }

                // Call API
                var result = await Services.RequestProvider.Current.GetUpdate<TempletData<StudentEvaluationModel>>(
                    FormUpdate, "studentevaluation", dictionary, Enums.AuthorizationType.UserNamePassword
                );

                // Ensure result and data are valid
                if (result == null || !result.IsPassed || result.Data == null)
                {
                    Debug.WriteLine("❌ Update failed: Response is null or not passed.");
                    return null;
                }

                Debug.WriteLine("✅ Update Successful!");
                return result.Data.itemData ?? new ObservableCollection<StudentEvaluationModel>();
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

        #region StudentEvaluationByStudyGroup
        public async static Task<ObservableCollection<StudentEvaluationModel>> GetStudentEvaluationByStudyGroupID
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

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentEvaluationModel>>(BASE, "studentevaluation", dictionary, Enums.AuthorizationType.UserNamePassword);
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
    }
}
