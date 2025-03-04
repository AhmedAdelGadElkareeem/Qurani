using CommunityToolkit.Mvvm.ComponentModel;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public partial class ContactModel : ObservableObject
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string NamePrefix { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string NameSuffix { get; set; }

        public List<ContactPhone> Phones { get; set; }
        public string Phone { get { if (Phones.Any()) return Phones.First().PhoneNumber; else return ""; } }

        public List<ContactEmail> Emails { get; set; }
        public string Email { get { if (Emails.Any()) return Emails.First().EmailAddress; else return ""; } }

        [ObservableProperty]
        public Color backgroundColor = StringExtensions.ToColorFromResourceKey("White");

        [ObservableProperty]
        public Color textColor = StringExtensions.ToColorFromResourceKey("Gray500");

        [ObservableProperty]
        public string image = "add_interest";
    }
}
