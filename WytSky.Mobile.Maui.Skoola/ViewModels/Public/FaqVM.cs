using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Views.Public;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Public
{
    public partial class FaqVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StCatgeory> faqCategories;

        public FaqVM()
        {
            FaqCategories = new ObservableCollection<StCatgeory>()
            {
                new StCatgeory(){NameEn="General",IsSelected = true},
                new StCatgeory(){NameEn="Account"},
                new StCatgeory(){NameEn="Courses"},
                new StCatgeory(){NameEn="Payment"},
            };
        }

        [RelayCommand]
        public void SelectCategory(StCatgeory stCatgeory)
        {
            try
            {
                foreach (var item in FaqCategories)
                {
                    item.IsSelected = false;
                }
                stCatgeory.IsSelected = true;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "FaqVM", "SelectCategory");
            }
        }

        [RelayCommand]
        public async Task OpenCustomerService()
        {
            await NavigateToPage.OpenPage(new CustomerServiceChatPage());
        }
    }
}
