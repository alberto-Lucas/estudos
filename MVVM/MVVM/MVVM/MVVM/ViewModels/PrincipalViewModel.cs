using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MVVM.ViewModels;
using MVVM.Views;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MVVM.ViewModels 
{
    public class PrincipalViewModel : BaseNotifyViewModel
    {
        public string Nome { get; set; }

        private string _retorno;
        public string Retorno 
        {
            get { return _retorno; }
            set 
            { 
                _retorno = value;
                OnPropertyChanged();
            }
        }

        public Command RetornoCommand
        { 
            get
            {
                return new Command(() =>
                {
                    Retorno = "Olá, " + Nome;
                });
            }
        }

        public ICommand ClienteCommand { get; set; }

        private async void Cliente()
        {
           await  Application.Current.MainPage.Navigation.PushAsync(new Views.CadClienteView());
        }

        public PrincipalViewModel()
        {
            this.ClienteCommand = new Command(this.Cliente);
        }




        /*
        public Command ClienteCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.GoToAsync(nameof(CadClienteView));
                });
            }
        }*/
    }
}
