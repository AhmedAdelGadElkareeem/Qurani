using Mopups.Interfaces;
using Mopups.Pages;
using Mopups.Services;

namespace WytSky.Mobile.Maui.Skoola.Services.Implementation
{
    public class ShowPopupService : IShowPopupService, IDisposable
    {
        private static readonly Lazy<ShowPopupService> lazyInstance = new Lazy<ShowPopupService>(() => new ShowPopupService());
        public static ShowPopupService Instance
        {
            get { return lazyInstance.Value; }
        }
        private ShowPopupService()
        {
            navigation = MopupService.Instance;
        }
        private readonly IPopupNavigation navigation;

        public async void Dispose()
        {
            await navigation.PopAsync();
        }

        public async Task<IDisposable> Show(PopupPage popupPage)
        {
            await navigation.PushAsync(popupPage, true);
            return this;
        }
    }
}
