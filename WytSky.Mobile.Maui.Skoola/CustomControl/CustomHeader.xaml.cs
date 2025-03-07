
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Views;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class CustomHeader : ContentView
{

    public CustomHeader()
    {
        InitializeComponent();
        //FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        try
        {
            InitializeComponent();
            if (Settings.Language == "ar")
            {
                FlowDirection = FlowDirection.RightToLeft;
                pageTitle.Margin = new Thickness(0, 0, 40, 0);
            }
            else
            {
                FlowDirection = FlowDirection.LeftToRight;
                pageTitle.Margin = new Thickness(40, 0, 0, 0);
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }
    }




    #region PageTitle
    public static readonly BindableProperty PageTitleProperty =
            BindableProperty.Create(nameof(PageTitle),
            typeof(string), typeof(CustomHeader), "", BindingMode.TwoWay);
    public string PageTitle
    {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }
    #endregion

    #region PageTitleColor
    public static readonly BindableProperty PageTitleColorProperty =
            BindableProperty.Create(nameof(PageTitleColor),
            typeof(Color), typeof(CustomHeader), Colors.White, BindingMode.TwoWay);
    public Color PageTitleColor
    {
        get => (Color)GetValue(PageTitleColorProperty);
        set => SetValue(PageTitleColorProperty, value);
    }
    #endregion

    #region HasTitle
    public static readonly BindableProperty HasTitleProperty =
        BindableProperty.Create(nameof(HasTitle),
        typeof(bool), typeof(CustomHeader), false,
        BindingMode.TwoWay);
    public bool HasTitle
    {
        get => (bool)GetValue(HasTitleProperty);
        set => SetValue(HasTitleProperty, value);
    }
    #endregion

    #region HasBack
    public static readonly BindableProperty HasBackProperty =
        BindableProperty.Create(nameof(HasBack),
        typeof(bool), typeof(CustomHeader), false,
        BindingMode.TwoWay);
    public bool HasBack
    {
        get => (bool)GetValue(HasBackProperty);
        set => SetValue(HasBackProperty, value);
    }
    #endregion

    #region HasLogout
    public static readonly BindableProperty HasLogoutProperty =
        BindableProperty.Create(nameof(HasLogout),
        typeof(bool), typeof(CustomHeader), false,
        BindingMode.TwoWay);
    public bool HasLogout
    {
        get => (bool)GetValue(HasLogoutProperty);
        set => SetValue(HasLogoutProperty, value);
    }
    #endregion

    private void GoBack(object sender, TappedEventArgs e)
    {
        try
        {

            App.Current.MainPage.Navigation.PopModalAsync();

        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }
    }
    private async void Logout(object sender, TappedEventArgs e)
    {
        try
        {
            var confirm = await App.Current.MainPage.DisplayAlert(SharedResources.Text_LogOut,
                                                                          SharedResources.Text_LogOut,
                                                                          SharedResources.Text_Yes,
                                                                          SharedResources.Text_No);
            if (confirm)
            {
                App.Logout();
            }

        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }

    }



    #region IsSearchVisible
    public static readonly BindableProperty IsSearchVisibleProperty =
        BindableProperty.Create(nameof(IsSearchVisible), typeof(bool), typeof(CustomHeader), false, BindingMode.TwoWay);
    public bool IsSearchVisible
    {
        get => (bool)GetValue(IsSearchVisibleProperty);
        set => SetValue(IsSearchVisibleProperty, value);
    }
    #endregion

    #region IsMenuVisible
    public static readonly BindableProperty IsMenuVisibleProperty =
        BindableProperty.Create(nameof(IsMenuVisible), typeof(bool), typeof(CustomHeader), false, BindingMode.TwoWay);
    public bool IsMenuVisible
    {
        get => (bool)GetValue(IsMenuVisibleProperty);
        set => SetValue(IsMenuVisibleProperty, value);
    }
    #endregion

    #region IsFilterVisible
    public static readonly BindableProperty IsFilterVisibleProperty =
        BindableProperty.Create(nameof(IsFilterVisible), typeof(bool), typeof(CustomHeader), true, BindingMode.TwoWay);
    public bool IsFilterVisible
    {
        get => (bool)GetValue(IsFilterVisibleProperty);
        set => SetValue(IsFilterVisibleProperty, value);
    }
    #endregion

    #region IsGridListVisible
    public static readonly BindableProperty IsGridListVisibleProperty =
        BindableProperty.Create(nameof(IsGridListVisible), typeof(bool), typeof(CustomHeader), false, BindingMode.TwoWay);
    public bool IsGridListVisible
    {
        get => (bool)GetValue(IsGridListVisibleProperty);
        set => SetValue(IsGridListVisibleProperty, value);
    }
    #endregion

    #region ListCommand
    public static readonly BindableProperty ListCommandProperty =
    BindableProperty.Create(nameof(ListCommand),
        typeof(ICommand), typeof(CustomHeader), defaultValue: null, BindingMode.TwoWay);
    public ICommand ListCommand
    {
        get => (ICommand)GetValue(ListCommandProperty);
        set => SetValue(ListCommandProperty, value);
    }
    #endregion

    #region GridCommand
    public static readonly BindableProperty GridCommandProperty =
    BindableProperty.Create(nameof(GridCommand),
        typeof(ICommand), typeof(CustomHeader), defaultValue: null, BindingMode.TwoWay);
    public ICommand GridCommand
    {
        get => (ICommand)GetValue(GridCommandProperty);
        set => SetValue(GridCommandProperty, value);
    }
    #endregion

    #region SearchText
    public static readonly BindableProperty SearchTextProperty =
        BindableProperty.Create(nameof(SearchText), typeof(string), typeof(CustomHeader), null, BindingMode.TwoWay);
    public string SearchText
    {
        get => (string)GetValue(SearchTextProperty);
        set => SetValue(SearchTextProperty, value);
    }
    #endregion
    
    private void OpenCartPage(object sender, EventArgs e)
    {
        //NavigateToPage.OpenPage(new CartPage());
    }

    private void OpenMenu(object sender, TappedEventArgs e)
    {
        WeakReferenceMessenger.Default.Send("OpenMenu");
    }

    //private void GoBack(object sender, TappedEventArgs e)
    //{
    //    NavigateToPage.ClosePage();
    //}

    //private void GridClicked(object sender, TappedEventArgs e)
    //{
    //    gridImage.Source = "red_grid";
    //    listImage.Source = "list";
    //}
    //private void ListClicked(object sender, TappedEventArgs e)
    //{
    //    gridImage.Source = "grid";
    //    listImage.Source = "red_list";
    //}
}