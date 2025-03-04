using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs;

public class ServiceCourses
{
    public const string BASE = "appservices";

    #region Categories
    public async static Task<ObservableCollection<CourseModel>> GetCoursesByCategoryId(string CategoryId)
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
                {
                      { "CategoryID",CategoryId},
                      { "_datatype", "json"},
                      { "_jsonarray", "1"},
                };
            var result = await Services.RequestProvider.Current.GetData<TempletData<CourseModel>>(BASE, "course", dictionary, Enums.AuthorizationType.UserNamePassword);
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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceCourses", "GetCoursesByCategoryId");
            return null;
        }
    }
    public async static Task<ObservableCollection<CourseModel>> GetCourseContentByCourseId(string CourseId)
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
                {
                    {"CourseID", CourseId},
                    {"_datatype", "json"},
                    {"_jsonarray", "1"},
                };
            var result = await Services.RequestProvider.Current.GetData<TempletData<CourseModel>>(BASE, "coursecontents", dictionary, Enums.AuthorizationType.UserNamePassword);
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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceCourses", "GetCourseContentByCourseId");
            return null;
        }
    }
    public async static Task<ObservableCollection<CourseModel>> GetCourseMaterialByCourseContentId(string CourseContentId)
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
                {
                      {"CourseContentID", CourseContentId},
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };
            var result = await Services.RequestProvider.Current.GetData<TempletData<CourseModel>>(BASE, "coursematerial", dictionary, Enums.AuthorizationType.UserNamePassword);
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
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "ServiceCourses", "GetCourseMaterialByCourseContentId");
            return null;
        }
    }
    #endregion
}
