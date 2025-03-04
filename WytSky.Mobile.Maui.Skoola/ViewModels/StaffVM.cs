using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class StaffVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();

        [ObservableProperty] public string centerID;
        #region Methods
        public async Task GetStaff()
        {
            try
            {
                IsRunning = true;
                Staff = await APIs.ServiceStaff.GetStaff(CenterID);
                if (Staff != null && Staff.Count > 0)
                {
                    Staff[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                    Staff[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "", "GetCenters");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public void SelectStaff(StaffModel staff)
        {
            App.Current.MainPage.Navigation.PushAsync(new StudyGroupsPage(staff.StaffID.ToString()));
        }
        
        [RelayCommand]
        public void OpenAddStaff()
        {
            
        }
        #endregion
    }
}
