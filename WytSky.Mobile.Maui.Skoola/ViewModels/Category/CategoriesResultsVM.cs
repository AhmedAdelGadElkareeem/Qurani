using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Category
{
    public partial class CategoriesResultsVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StCourse> results;

        [ObservableProperty]
        public ObservableCollection<StCatgeory> categories;

        [ObservableProperty]
        public bool clearAllVisibility = true;

        public CategoriesResultsVM()
        {
            Categories = new ObservableCollection<StCatgeory>()
            {
                new StCatgeory(){IsSelected = true,NameEn="Englis"},
                new StCatgeory(){IsSelected = false,NameEn="Egypt"},
                new StCatgeory(){IsSelected = false,NameEn="JavaScript"},
                new StCatgeory(){IsSelected = false,NameEn="Certificate"},
            };
            Results = new ObservableCollection<StCourse>()
            {
                new StCourse(){Isfav = true},
                new StCourse(),
                new StCourse(){Isfav = true},
                new StCourse(),
                new StCourse(){Isfav = true},
                new StCourse(),
                new StCourse(){Isfav = true},
                new StCourse(),
                new StCourse(){Isfav = true},
            };
        }

        [RelayCommand]
        public void ClearCategory(StCatgeory stCatgeory)
        {
            try
            {
                Categories.Remove(stCatgeory);
                if (Categories.Count == 0)
                    ClearAllVisibility = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CategoriesResultsVM", "ClearCategory");
            }
        }

        [RelayCommand]
        public void ClearAll()
        {
            try
            {
                Categories.Clear();
                ClearAllVisibility = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CategoriesResultsVM", "ClearAll");
            }
        }

    }
}
