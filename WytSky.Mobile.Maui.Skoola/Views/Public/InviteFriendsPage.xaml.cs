using WytSky.Mobile.Maui.Skoola.ViewModels.Public;

namespace WytSky.Mobile.Maui.Skoola.Views.Public;
public partial class InviteFriendsPage : BaseContentPage
{
    InviteFriendsVM inviteFriendsVM = new InviteFriendsVM();
    public InviteFriendsPage()
	{
		InitializeComponent();
        BindingContext = inviteFriendsVM;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await inviteFriendsVM.GetAllContacts();
    }
}