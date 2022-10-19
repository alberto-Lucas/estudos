using LoginSqLITE.Services;
using LoginSqLITE.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginSqLITE.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public UsuarioService usuarioService;



        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }
        }

        public ICommand EntrarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }




        private async void Entrar()
        {
            try
            {
                var user = await usuarioService.GetLoginAsync(Email);

                if (user == null)
                    await App.Current.MainPage.DisplayAlert("Atenção", "Email inválido.", "Ok");

                else
                {
                    if (user.Senha == Senha)
                        await Application.Current.MainPage.Navigation.PushModalAsync(new PrincipalView());
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Atenção", "Senha inválida.", "Ok");
                    }
                }

            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Erro", "Erro original: " + ex, "Ok");
            }            
        }

        public async void Registrar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroView());
        }

        public LoginViewModel()
        {
            EntrarCommand = new Command(Entrar);
            RegistrarCommand = new Command(Registrar);
            usuarioService = new UsuarioService();
        }
    }
}
