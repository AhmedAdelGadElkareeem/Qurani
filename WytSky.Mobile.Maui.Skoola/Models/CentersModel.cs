using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class CentersModel : BaseModel
    {
        public int CenterID { get; set; }
        public int ComplexID { get; set; }
        public string CenterName { get; set; }
        public string? CenterNameEn { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? SupervisorID { get; set; }
        public string? Notes { get; set; }
        public int? StudyGroupCount { get; set; }
        public string? ComplexName { get; set; }
        public string? ComplexRegionName { get; set; }
        public string ComplexRegionCountryName { get; set; }


        private Color textColor = Colors.DimGray;
        public Color TextColor
        {
            get => textColor;
            set => SetProperty(ref textColor, value);
        }

        private Color backgroundColor = Colors.White;
        public Color BackgroundColor
        {
            get => backgroundColor;
            set => SetProperty(ref backgroundColor, value);
        }

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get => _IsSelected;
            set => SetProperty(ref _IsSelected, value);
        }

        #region SetProperty
        protected bool SetProperty<T>(ref T backingStore, T value,
            [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
