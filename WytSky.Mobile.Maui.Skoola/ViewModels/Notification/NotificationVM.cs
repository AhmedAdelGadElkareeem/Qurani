using CommunityToolkit.Mvvm.ComponentModel;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Notification
{
    public partial class NotificationVM : BaseViewModel
    {
        [ObservableProperty]
        public List<StClientNotification> notifications;

        public NotificationVM()
        {
            Notifications = new List<StClientNotification>()
            {
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = true,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now, CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = false,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = true,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = false,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = true,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = false,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = true,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
                new StClientNotification()
                {
                    CreatedBy ="Felipe García", CreatedOn = DateTime.Now,CreatedOnString="15/10/2023 - 05:34 pm",
                    IsRead = false,
                    ContentEn="Lorem ipsum dolor sit amet, consectetur adipiscing elit, Vestibulum mollis nunc a molestie dictum."
                },
            };
        }
    }
}
