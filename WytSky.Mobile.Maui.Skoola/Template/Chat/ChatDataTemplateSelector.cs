
using WytSky.Mobile.Maui.Skoola.Dtos.Used;

namespace WytSky.Mobile.Maui.Skoola.Template.Chat
{
    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RecievedMessageTemplate { get; set; }
        public DataTemplate SentMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var senderId = ((MessageModel)item).SenderId; 
            return senderId == Helpers.Settings.UserId ? SentMessageTemplate : RecievedMessageTemplate;
        }
    }
}
