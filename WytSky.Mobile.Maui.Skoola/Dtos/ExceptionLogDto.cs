using System;
using System.Collections.Generic;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class ExceptionLogDto
    {
        public Guid ExceptionId { get; set; } = Guid.NewGuid();
        public string Place { get; set; } = "";
        public string Content { get; set; } = "";
        public string Data { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(2);
        public string Platform { get; set; } = "";
    }
}
