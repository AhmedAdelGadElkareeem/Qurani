using WytSky.Mobile.Maui.Skoola.ViewModels.Public;

namespace WytSky.Mobile.Maui.Skoola.Views.Public;

public partial class CustomerServiceChatPage : BaseContentPage
{
    #region Fields
    CustomerServiceChatVM customerServiceChatVM = new CustomerServiceChatVM();
    #endregion

    #region Constuctor
    public CustomerServiceChatPage()
    {
        InitializeComponent();
        BindingContext = customerServiceChatVM;
    } 
    #endregion

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var lastItem = customerServiceChatVM.Messages.Count - 1;
        messagesCollectionView.ScrollTo(
                        lastItem, 
                        position: ScrollToPosition.MakeVisible, 
                        animate: true);
    }

    private async void GoBack(object sender, TappedEventArgs e)
    {
        await NavigateToPage.ClosePage();
    }
}