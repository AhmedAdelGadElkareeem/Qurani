using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public class UserTypeModel
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
