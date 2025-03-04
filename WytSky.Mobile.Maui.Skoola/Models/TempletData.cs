using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class TempletData<T>
    {
        public long? TotalRowCount { get; set; }
        public long? PageSize { get; set; }
        public long? PageIndex { get; set; }
        public long? RowCount { get; set; }
        public ObservableCollection<T> ItemData { get; set; }
    }
}
