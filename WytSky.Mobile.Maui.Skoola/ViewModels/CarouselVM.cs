using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Views.Public;
using WytSky.Mobile.Maui.Skoola.Views.SplashViews;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class CarouselVM : BaseViewModel
    {
        [ObservableProperty]
        public List<StCarouselItem> carouselItems;

        [ObservableProperty]
        public int positionSelected = 0;

        public CarouselVM()
        {
            CarouselItems = new List<StCarouselItem>()
            {
                new StCarouselItem() {Title="Lorem ipsum dolor sit amet",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum. ",
                    ImageNumber="test_skip_1",Image="test_splash_1"},

                new StCarouselItem() {Title="Lorem ipsum dolor sit amet",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum. ",
                    ImageNumber="test_skip_2",Image="test_splash_2"},

                new StCarouselItem() {Title="Lorem ipsum dolor sit amet",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum. ",
                    ImageNumber="test_skip_3",Image="test_splash_3"},
            };
        }

        [RelayCommand]
        public void Skip()
        {
            if (Settings.IsLogedin)
                App.Current.MainPage = new NavigationPage(new MainPage());
            else
                App.Current.MainPage = new NavigationPage(new SignInSignUpPage());
        }

        [RelayCommand]
        public void Next()
        {
            if (PositionSelected < 2)
                PositionSelected++;
            else if (PositionSelected == 2)
            {
                if (Settings.IsLogedin)
                    App.Current.MainPage = new NavigationPage(new MainPage());
                else
                    App.Current.MainPage = new NavigationPage(new SignInSignUpPage());
            }
        }
    }
}