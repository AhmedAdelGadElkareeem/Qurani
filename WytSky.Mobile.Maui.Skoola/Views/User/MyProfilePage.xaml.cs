using System.Globalization;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.ViewModels.User;

namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class MyProfilePage : BaseContentPage
{
    MyProfileVM MyProfileVM = new MyProfileVM();
    public MyProfilePage()
    {
        InitializeComponent();
        BindingContext = MyProfileVM;
    }
}