using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using Contact = Microsoft.Maui.ApplicationModel.Communication.Contact;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Public
{
    public partial class InviteFriendsVM : BaseViewModel
    {
        [ObservableProperty]
        public List<ContactModel> allContacts = new List<ContactModel>();

        public List<ContactModel>  SelectedContacts = new List<ContactModel>();

        public async Task GetAllContacts()
        {
            try
            {
                IsRunning = true;
                var status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.ContactsRead>();
                }
                if (status == PermissionStatus.Granted)
                {
                    var list = await Microsoft.Maui.ApplicationModel.Communication.Contacts.Default.GetAllAsync();
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            AllContacts.Add(new ContactModel()
                            {
                                DisplayName = item.DisplayName,
                                FamilyName = item.FamilyName,
                                Id = item.Id,
                                GivenName = item.GivenName,
                                MiddleName = item.MiddleName,
                                NamePrefix = item.NamePrefix,
                                NameSuffix = item.NameSuffix,
                                Emails = item.Emails,
                                Phones = item.Phones,
                            });
                        }
                    }
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "InviteFriendsVM", "GetAllContacts");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public void SelectedContact(ContactModel contact)
        {
            contact.Image = "white_true_sign";
            contact.BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
            contact.TextColor = StringExtensions.ToColorFromResourceKey("White");
            SelectedContacts.Add(contact);
        }
    }
}
