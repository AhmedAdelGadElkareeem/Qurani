using WytSky.Mobile.Maui.Skoola.Dtos;

namespace WytSky.Mobile.Maui.Skoola;

public partial class MainPage : FlyoutPage
{
	public MainPage()
	{
		InitializeComponent();
		flyoutPage.MenuItemsListView.ItemSelected += OnItemSelected;
	}

	private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var item = e.SelectedItem as MenuModelItem;
		if (item != null)
		{            
			Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
			if (!((IFlyoutPageController)this).ShouldShowSplitMode)
				IsPresented = false;
		}
	}
}