using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceComplex
    {
        public const string BASE = "appservices";
        public const string KeyName = "ComplexID";

        #region Complexes
        public async static Task<ObservableCollection<ComplexModel>> GetComplexs()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<ComplexModel>>(BASE, "complexes", dictionary, Enums.AuthorizationType.UserNamePassword);
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
          public async static Task<ObservableCollection<ComplexModel>> UpdateComplex(Dictionary<string, object> formData)
          {
              try
              {
                  var dictionary = new Dictionary<string, string>()
                  {
                        {"_datatype", "json"},
                        {"_jsonarray", "1"},
                        {"_key", Settings.ComplexId },
                        {"_keyname", KeyName }
                  };
                foreach (var item in formData)
                {
                    dictionary[item.Key] = item.Value?.ToString() ?? string.Empty;
                }

                var result = await Services.RequestProvider.Current.GetData<TempletData<ComplexModel>>(BASE, "complexes", dictionary, Enums.AuthorizationType.UserNamePassword);

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
                  ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceComplex", "GetComplexById");
                  return null;
              }
          }

        public async static Task<ComplexModel> AddComplex(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<ComplexModel>(BASE, "complexes", dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "AddComplexs", "SaveNew()");
                return null;
            }
        }
        #region Update()
        public async static System.Threading.Tasks.Task<ComplexModel> Update(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<ComplexModel>(BASE, "complexes", dictionary, formData, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceFeadbackQuestion", "Update()");
                return null;
            }
        }
        #endregion
        public async static Task<ObservableCollection<CentersModel>> GetCenters(string ParentId)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"ComplexID", ParentId},
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<CentersModel>>(BASE, "centers", dictionary, Enums.AuthorizationType.UserNamePassword);
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











































        #region skoola
        public async static Task<ObservableCollection<CategoryModel>> GetMainCategories(string ParentId)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                    {"ParentCategoryID", ParentId},
                    {"_datatype", "json"},
                    {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<CategoryModel>>(BASE, "maincategory", dictionary, Enums.AuthorizationType.UserNamePassword, isLoading:false);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceComplex", "GetMainCategories");
                return null;
            }
        }
        public async static Task<ObservableCollection<CategoryModel>> GetCategoriesByMainCategoryId(string MainCategoryId)
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"MainCategoryID", MainCategoryId},
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
                var result = await Services.RequestProvider.Current.GetData<TempletData<CategoryModel>>(BASE, "category", dictionary, Enums.AuthorizationType.UserNamePassword);
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceComplex", "GetCategories");
                return null;
            }
        }
        #endregion
        #endregion
    }
}
