using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public class StComment : StBase
    {
        public string Title { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc.";
        public string Creator { get; set; } = "Eslam Hisham";
        public string Time { get; set; } = "05:00 pm";
        public string Date { get; set; } = "31/10/2023";
        public List<StComment> Replies { get; set; } = new List<StComment>();
        public bool HasReplies => Replies.Any();
    }
}
