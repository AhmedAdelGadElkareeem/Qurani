using WytSky.Mobile.Maui.Skoola.ViewModels.Notification;

namespace WytSky.Mobile.Maui.Skoola.Views.Notification;

public partial class NotificationsPage : BaseContentPage
{
    public NotificationsPage()
    {

        try
        {
            InitializeComponent();
            BindingContext = new NotificationVM();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "NotificationsPage", "Constructor");
        }
    }
}