using CommunityToolkit.Mvvm.ComponentModel;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StBase : ObservableObject
    {
        #region Properties
        public Nullable<bool> IsActive { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        #endregion
    }
}
