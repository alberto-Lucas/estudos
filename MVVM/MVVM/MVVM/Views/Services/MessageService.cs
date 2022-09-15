using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Views.Services
{
    public class MessageService : ViewModels.Services.IMessageService
    {
        public MessageService()
        {
            
        }

        public async Task ShowAsync(string message)
        {
            await MVVM.App.Current.MainPage.DisplayAlert("Aviso", message, "Ok");
        }
    }
}
