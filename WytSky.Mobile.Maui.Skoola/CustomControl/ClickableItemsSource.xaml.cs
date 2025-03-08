using Mopups.Pages;
using Mopups.Services;
using WytSky.Mobile.Maui.Skoola.Helpers;
namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class ClickableItemsSource : PopupPage
{
    #region Constractor
    public ClickableItemsSource()
    {
        try
        {
            InitializeComponent();
            //this.FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "ClickableItemsSource", "Constructor");
        }
    }

    #endregion
    private void CancelClicked(object sender, EventArgs e)
    {
        try
        {
            ((ClickableItem)this.BindingContext).SelectedItem = null;
            ((ClickableItem)this.BindingContext).SelectedIndex = -1;
            App.ShowPopupService.Dispose();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "ClickableItemsSource", "Button_Clicked");
        }
    }
    private void ClosePopup(object sender, EventArgs e)
    {
        try
        {
            App.ShowPopupService.Dispose();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "ClickableItemsSource", "ClosePopup");
        }
    }
    private void CollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            var _BindingContext = ((ClickableItem)this.BindingContext);
            if (_BindingContext != null && _BindingContext.SelectedItem != null)
            {
                _BindingContext.SelectedIndex = _BindingContext.ItemsSource.IndexOf(_BindingContext.SelectedItem);
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        App.ShowPopupService.Dispose();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "ClickableItemsSource", "CollectionViewSelectionChanged");
                }
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "ClickableItemsSource", "CollectionViewSelectionChanged");
        }
    }
}