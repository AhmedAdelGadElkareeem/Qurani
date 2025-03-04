using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Courses;
using WytSky.Mobile.Maui.Skoola.Views.Quarni;
using Settings = WytSky.Mobile.Maui.Skoola.Helpers.Settings;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class CenterVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<CentersModel> centers = new ObservableCollection<CentersModel>();

        [ObservableProperty]
        public CentersModel centersModel ;

        [ObservableProperty]
        public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();
    
        
        private string complexId;

        public CenterVM(string complexId = "")
        {
            CentersModel = new CentersModel();
            if (!string.IsNullOrWhiteSpace(complexId) && int.TryParse(complexId, out int complexIdInt))
            {
                CentersModel.ComplexID = complexIdInt;
            }
        }


        public CenterVM()
        {
        }

        #region Methods
        public async Task GetMainCategoriesByParentCategoryId(string ParentId)
        {
            IsRunning = true;
            Staff = await APIs.ServiceStaff.GetStaff(ParentId);
            IsRunning = false;
        }

     
        #endregion

        #region Commands
        [RelayCommand]
        public async Task SelectParentCategory(CentersModel StaffModel)
        {
            try
            {
                //CategoriesVisiblity = false;

                foreach (var item in Staff)
                {
                    item.IsSelected = false;
                    item.TextColor = Colors.DimGray;
                    item.BackgroundColor = Colors.White;
                }

                StaffModel.IsSelected = true;
                StaffModel.TextColor = StringExtensions.ToColorFromResourceKey("White");
                StaffModel.BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
                await GetMainCategoriesByParentCategoryId(StaffModel.CenterID.ToString());
                App.Current.MainPage = new StaffPage(StaffModel.CenterID.ToString());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
            }
        }
        public async Task GetCenters(string ComplexID)
           {
               try
               {
                   IsRunning = true;
                //CategoriesVisiblity = false;

                   Centers = await APIs.ServiceCenter.GetCenter(ComplexID);
                   if (Centers != null && Centers.Count > 0)
                   {
                       Centers[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                       Centers[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");

                       //await GetMainCategoriesByParentCategoryId(Complexes[0].Id.ToString()); Navigate to Masajid page

                   }
                   IsRunning = false;
               }
               catch (Exception ex)
               {
                   ExtensionLogMethods.LogExtension(ex, "", "", "GetCenters");
               }
        }
            [RelayCommand]
            public async Task AddCenter()
            {
            try
            {
                if (string.IsNullOrWhiteSpace(CentersModel.CenterName))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "يجب إدخال إسم المسجد", "OK");
                    return;
                }

                IsRunning = true;

                // Create form data dictionary
                var formData = new Dictionary<string, object>
                {
                    { "CenterName", CentersModel.CenterName },
                    { "ComplexID" ,CentersModel.ComplexID },
                    { "Address", CentersModel.Address}

                };

                // Call the AddComplex service method
                var result = await APIs.ServiceCenter.AddCenter(formData);

                if (result != null)
                {
                    // Successfully added, update the list
                    Centers.Add(result);
                    await App.Current.MainPage.DisplayAlert("Success", "تم إضافة مسجد بنجاح", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "خطأ إثناء إضافة المسجد", "OK");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "HomeVM", "AddComplex");
                await App.Current.MainPage.DisplayAlert("Error", "An unexpected error occurred", "OK");
            }
            finally
            {
                IsRunning = false;
            }
        }
        public async Task GetStaff(string CenterID)
        {
                IsRunning = true;
            try
            {
                //CategoriesVisiblity = false;

                Staff = await APIs.ServiceStaff.GetStaff(CenterID);
                if (Centers != null && Centers.Count > 0)
                {
                    Centers[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                    Centers[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");

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
