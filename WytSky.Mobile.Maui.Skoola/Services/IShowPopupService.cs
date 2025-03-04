using Mopups.Pages;

namespace WytSky.Mobile.Maui.Skoola.Services
{
    public interface IShowPopupService
    {
        Task<IDisposable> Show(PopupPage popupPage);
        void Dispose();
    }
}
