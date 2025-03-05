namespace WytSky.Mobile.Maui.Skoola.Models;

public class AspUserRoleModel
{
    public string UserID { get; set; }
    public string UserEmail { get; set; }
    public object UserPhoneNumber { get; set; }
    public string RoleID { get; set; }
    public string UserName { get; set; }
    public string AspNetRolesName { get; set; }

    //Supervisor , Offline , admin , Administrators , Teacher , Users
}