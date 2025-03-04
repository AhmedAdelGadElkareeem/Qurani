using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class StaffVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();

        public StaffVM()
        {

        }
        #region Methods
        public async Task GetStaff(string CenterID)
        {
            try
            {
                IsRunning = true;
                //CategoriesVisiblity = false;

                staff = await APIs.ServiceStaff.GetStaff(CenterID);
                if (Staff != null && Staff.Count > 0)
                {
                    Staff[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                    Staff[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");

                    //await GetMainCategoriesByParentCategoryId(Complexes[0].Id.ToString()); Navigate to Masajid page

                }
                IsRunning = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "", "GetCenters");
            }
        }
        #endregion
    }
}
