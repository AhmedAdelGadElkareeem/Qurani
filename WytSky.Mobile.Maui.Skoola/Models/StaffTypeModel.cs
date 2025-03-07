using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class StaffTypeModel
    {

        public string TypeName { get; set; }
        public string TypeNameEn { get; set; }
        public bool IsActive { get; set; }
        public object Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int StaffTypeID { get; set; }
    }
}
