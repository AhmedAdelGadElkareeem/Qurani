using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Enums;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class IResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool IsPassed { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}
