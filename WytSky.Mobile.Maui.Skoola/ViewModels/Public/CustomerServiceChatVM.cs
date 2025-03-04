using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Public
{
    public partial class CustomerServiceChatVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<MessageModel> messages;

        public CustomerServiceChatVM()
        {
            Messages = new ObservableCollection<MessageModel>()
            {
                new MessageModel(){ SenderId = "1" , Time = "09:10" , Title= "Test Test Test Test Test Test Test Test Test "},
                new MessageModel(){ SenderId = "2" , Time = "09:11" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:12" , Title= "Test Test "},
                new MessageModel(){ SenderId = "1" , Time = "09:12" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:12" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:13" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:13" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:13" , Title= "Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:14" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:14" , Title= "Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:10" , Title= "Test Test Test Test Test Test Test Test Test "},
                new MessageModel(){ SenderId = "2" , Time = "09:11" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:12" , Title= "Test Test "},
                new MessageModel(){ SenderId = "1" , Time = "09:12" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:12" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:13" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:13" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:13" , Title= "Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:14" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:14" , Title= "Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:10" , Title= "Test Test Test Test Test Test Test Test Test "},
                new MessageModel(){ SenderId = "2" , Time = "09:11" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:12" , Title= "Test Test "},
                new MessageModel(){ SenderId = "1" , Time = "09:12" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:12" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:13" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:13" , Title= "Test Test Test Test Test Test Test Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:13" , Title= "Test"},
                new MessageModel(){ SenderId = "1" , Time = "09:14" , Title= "Test"},
                new MessageModel(){ SenderId = "2" , Time = "09:14" , Title= "Test"},
            };
        }
    }
}