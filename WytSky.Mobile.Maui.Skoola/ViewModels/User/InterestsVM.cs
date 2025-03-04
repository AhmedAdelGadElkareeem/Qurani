using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.User
{
    public partial class InterestsVM : BaseViewModel
    {
        #region Fields
        public ObservableCollection<StInterest> SelectedInterests = new ObservableCollection<StInterest>();
        #endregion

        #region Properties
        [ObservableProperty]
        public ObservableCollection<StInterest> interests;
        #endregion

        #region Constructor
        public InterestsVM()
        {
            Interests = new ObservableCollection<StInterest>()
            {
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
                new StInterest()
                {   Name = "Programming and Development",
                    Skills = new List<StInterest>()
                    {
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                        new StInterest() {Name="Introduction to Programming" },
                        new StInterest() {Name="Java Script" },
                    }
                },
            };
        }
        #endregion

        #region Commands
        [RelayCommand]
        public void SelectedSkill(StInterest selectedSkill)
        {
            /*foreach (var interest in Interests)
            {
                foreach (var item in interest.Skills)
                {
                    item.Image = "add_interest";
                    item.BackgroundColor = StringExtensions.ToColorFromResourceKey("White");
                    item.TextColor = StringExtensions.ToColorFromResourceKey("Gray500");
                }
            }*/

            selectedSkill.Image = "white_true_sign";
            selectedSkill.BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
            selectedSkill.TextColor = StringExtensions.ToColorFromResourceKey("White");
            SelectedInterests.Add(selectedSkill);
        }

        [RelayCommand]
        public async Task CreateAccount()
        {
            await NavigateToPage.OpenPage(new AccountCreatedSuccessfullyPage());
        } 
        #endregion
    }
}
