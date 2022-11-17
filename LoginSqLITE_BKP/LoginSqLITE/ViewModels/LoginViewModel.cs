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
        //Instancia da classe com os metodos de persistencia
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
                //Recuperar o registro que possua o email informado
                //E atribuido o retorno ao objeto user
                var user = await usuarioService.GetLoginAsync(Email); 

                if (user == null) //verifica se o retorno foi nulo
                    await App.Current.MainPage.DisplayAlert("Atenção", "Email inválido.", "Ok");

                else
                {
                    if (user.Senha == Senha) //valida a senha carregada no objeto
                        await Application.Current.MainPage.Navigation.PushModalAsync(new PrincipalView()); //abre a tela principal
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Atenção", "Senha inválida.", "Ok");
                    }
                }

            }
            catch (Exception ex)
            {
                //Tratamento de exceção para subir mensagem de erro ao usuário
                await App.Current.MainPage.DisplayAlert("Erro", "Erro original: " + ex.Message, "Ok");
            }            
        }
        public async void Registrar()
        {
            //Abrir a View para registrar um novo usuário
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
