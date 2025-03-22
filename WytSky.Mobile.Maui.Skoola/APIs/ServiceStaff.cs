using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceStaff
    {
        public const string BASE = "appservices";
        public const string FormUpdate = "api/formupdate/getupdate";
        public const string KeyName = "StaffID";


        #region staff
        public async static Task<ObservableCollection<StaffModel>> GetCenterStaff()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"CenterID", Helpers.Settings.CenterId},
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<StaffModel>>(BASE, "staff", dictionary, Enums.AuthorizationType.UserNamePassword);
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
        
         public async static Task<ObservableCollection<StaffModel>> GetStaff()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<StaffModel>>(BASE, "staff", dictionary, Enums.AuthorizationType.UserNamePassword);
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
         public async static Task<ObservableCollection<StaffTypeModel>> GetStaffType()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<StaffTypeModel>>(BASE, "stafftypes", dictionary, Enums.AuthorizationType.UserNamePassword);
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

        public async static Task<StaffModel> AddStaff(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<StaffModel>(BASE, "staff", dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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

        public async static Task<ObservableCollection<ComplexModel>> UpdateStaff(Dictionary<string, object> formData)
        {
            try
            {
                var dictionary = new Dictionary<string, string>
                {
                    { "_datatype", "json" },
                    { "_jsonarray", "1" },
                    { "_key", Settings.StaffId },
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
                    FormUpdate, "staff", dictionary, Enums.AuthorizationType.UserNamePassword
                );

                // Ensure result and data are valid
                if (result == null || !result.IsPassed || result.Data == null)
                {
                    Debug.WriteLine("❌ Update failed: Response is null or not passed.");
                    return null;
                }

                Debug.WriteLine("✅ Update Successful!");
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
}

