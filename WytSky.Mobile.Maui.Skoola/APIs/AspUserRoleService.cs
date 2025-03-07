using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs;

public class AspUserRoleService
{
    private const string BASE = "appservices";
    private const string CONTROLR = "Aspnetuserroles";

    //https://qr.saskw.net/appservices/Aspnetuserroles?_datatype=json&_jsonarray=1&UserName=sky365    #region Get Asp User Roles

    #region GetAspUserRoles
    public static async Task<ObservableCollection<AspUserRoleModel>> GetUserRoles()
    {
        try
        {
            var dictionary = new Dictionary<string, string>()
            {
                {"UserName", Settings.UserName},
                {"_datatype", "json"},
                {"_jsonarray", "1"},
            };
            var result = await Services.RequestProvider.Current.GetData<TempletData<AspUserRoleModel>>(BASE, CONTROLR, dictionary, Enums.AuthorizationType.UserNamePassword);
            if (result != null && result.IsPassed)
                return result.Data.itemData;
            else
                return null;
        }
        catch (Exception ex)
        {
            string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "AspUserRoleService", "GetUserRoles");
            return null;
        }
    }
    #endregion
}