using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class ComplexModel
    {
        public string ComplexName { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public int? SupervisorID { get; set; }
        public int? ComplexID { get; set; }
        public string? CountryName { get; set; }
        public string? RegionName { get; set; }
        public string? SupervisorFirstName { get; set; }
        public string OrganizationCountryName { get; set; }
        public string SupervisorPhoneNumber { get; set; }
        public string SupervisorUserName { get; set; }
        public int? SupervisorRegionID { get; set; }
        public string SupervisorMobile { get; set; }
        public string SupervisorEmail { get; set; }
        public string SupervisorFullName { get; set; }
        public DateTime? SupervisorDateOfBirth { get; set; }
        public string SupervisorCenterName { get; set; }
        public string SupervisorStaffTypeName { get; set; }
        public bool IsActive { get; set; }

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
