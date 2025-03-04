using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.ViewPublic;
using CommunityToolkit.Mvvm.Messaging;

namespace WytSky.Mobile.Maui.Skoola.Views.Public;

public partial class MenuPage : FlyoutPage
{
    public MenuPage()
    {
        try
        {
            InitializeComponent();
            this.FlowDirection = Settings.Language == "en" ?
                FlowDirection.LeftToRight : FlowDirection.RightToLeft;
            NavigationPage.SetHasNavigationBar(this, false);
            this.Flyout.BindingContext = new MenuVM();
            MenuItemsListView.ItemSelected += ListView_ItemSelected;

            // sent from custom header when click on menu
            WeakReferenceMessenger.Default.Register<string>(this, (r, m) =>
            {
                IsPresented = true;
            });
        }
        catch (System.Exception ex)
        {
            string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "MenuPage", "Constructor");
        }
    }
    public MenuPage(Page page)
    {
        try
        {
            InitializeComponent();
            this.FlowDirection = (Settings.Language == "en") ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
            NavigationPage.SetHasNavigationBar(this, false);
            //this.Detail = page;
            var _newPage = (Page)Activator.CreateInstance(page.GetType());
            _newPage.Title = page.Title;
            Detail = new NavigationPage(_newPage);
            this.Flyout.BindingContext = new MenuVM();
            MenuItemsListView.ItemSelected += ListView_ItemSelected;

            // sent from custom header when click on menu
            WeakReferenceMessenger.Default.Register<string>(this, (r, m) =>
            {
                IsPresented = true;
            });
        }
        catch (System.Exception ex)
        {
            string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
            ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "MenuPage", "Paramaterized Constructor");
        }
    }
    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            var item = e.SelectedItem as MenuModelItem;
            if (item == null)
            {
                return;
            }
            else if (item.TargetType == null)
            {
                item.CommandE.Execute(null);
                return;
            }
            if (item.TargetType != ((NavigationPage)this.Detail).CurrentPage.GetType())
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;
                //Detail = new NavigationPage(page);
                NavigateToPage.OpenPage(page);
                IsPresented = false;
                MenuItemsListView.SelectedItem = null;
            }
            else
            {
                IsPresented = false;
                MenuItemsListView.SelectedItem = null;
            }
        }
        catch (System.Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
        }
    }
    private void MasterDetailPage_IsPresentedChanged(object sender, EventArgs e)
    {
        try
        {
            ((MenuVM)this.Flyout.BindingContext).SetMune();
        }
        catch (System.Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
        }
    }
    private void HideMenu(object sender, TappedEventArgs e)
    {
        IsPresented = false;
    }
}