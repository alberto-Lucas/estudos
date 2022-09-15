using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    public class ClienteViewModel : BaseNotifyViewModel
    {
        private string _nome;
        private string _idade;
        private string _telefone;

        public string Nome 
        {
            get { return _nome; }
            set 
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        public string Idade
        {
            get { return _idade; }
            set
            {
                _idade = value;
                OnPropertyChanged();
            }
        }

        public string Telefone
        {
            get { return _telefone; }
            set
            {
                _telefone = value;
                OnPropertyChanged();
            }
        }

        public Command CadastrarCommand
        {
            get
            {
                return new Command(() => 
                {
                    // Application.Current.MainPage.Navigation.PushAsync(new Views.VisClienteView());

                    this._messageService.ShowAsync("Nome: " + Nome + Environment.NewLine +
                                                   "Idade: " + Idade + Environment.NewLine +
                                                   "Telefone: " + Telefone);
                });
            }
        }

        private readonly Services.IMessageService _messageService;

        public ClienteViewModel()
        {
            this._messageService = DependencyService.Get<Services.IMessageService>();
        }
    }
}
