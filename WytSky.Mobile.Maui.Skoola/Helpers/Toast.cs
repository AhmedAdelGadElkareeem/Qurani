using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using WytSky.Mobile.Maui.Skoola.AppResources;

namespace WytSky.Mobile.Maui.Skoola.Helpers
{
    public class Toast
    {
        public static void ShowToast(CustomControl.ToastPopup popup, int CloseAfterSecond)
        {
            try
            {
                App.Current.MainPage.ShowPopup(popup);
                if (CloseAfterSecond > 0)
                {
                    IDispatcherTimer timer;

                    timer = Application.Current.Dispatcher.CreateTimer();
                    timer.Interval = TimeSpan.FromSeconds(CloseAfterSecond);
                    timer.Tick += (s, e) =>
                    {
                        try
                        {
                            popup.Close();
                            timer.Stop();
                        }
                        catch (System.Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                            timer.Stop();
                        }
                    };
                    timer.Start();
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToast");
            }
        }
        public static void ShowToastMessage(string title, string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Message,
                    ToastMessage = message,
                    ToastTitle = title,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastMessage");
            }
        }
        public static void ShowToastSuccess(string title, string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Success,
                    ToastMessage = message,
                    ToastTitle = title,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastSuccess");
            }
        }
        public static void ShowToastError(string title, string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Error,
                    ToastMessage = message,
                    ToastTitle = title,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastError");
            }
        }
        public static void ShowToastWarning(string title, string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Warning,
                    ToastMessage = message,
                    ToastTitle = title,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastWarning");
            }
        }
        public static void ShowToastMessage(string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Message,
                    ToastMessage = message,
                    ToastTitle = SharedResources.Text_Message,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastMessage");
            }
        }
        public static void ShowToastSuccess(string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Success,
                    ToastMessage = message,
                    ToastTitle = SharedResources.Text_Success,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastSuccess");
            }
        }
        public static void ShowToastError(string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Error,
                    ToastMessage = message,
                    ToastTitle = SharedResources.Text_Error,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastError");
            }
        }
        public static void ShowToastWarning(string message, int CloseAfterSecond = 5)
        {
            try
            {
                /*var popup = new CustomControl.ToastPopup()
                {
                    ToastType = Enums.TypeOfToast.Warning,
                    ToastMessage = message,
                    ToastTitle = SharedResources.Text_Warning,
                    ImageSource = "default_image.png"
                };
                ShowToast(popup, CloseAfterSecond);*/

                ShowCustomToast(message);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "Toast", "ShowToastWarning");
            }
        }

        public static void ShowCustomToast(string message)
        {
            var toast = CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Long, 16);
            toast.Show();
        }
    }
}
