using LoginSqLITE.Models;
using LoginSqLITE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginSqLITE.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        public UsuarioService usuarioService;

        private string _nome;
        private string _email;
        private string _senha;

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }
        }

        public ICommand InserirCommand { get; set; }

        public async void Inserir()
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nome = Nome,
                    Email = Email,
                    Senha = Senha
                };

                await usuarioService.AddAsync(usuario);

                await App.Current.MainPage.DisplayAlert("Informação", "Registro salvo com sucesso.", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro original: " + ex, "Ok");
            }
        }

        public RegistroViewModel()
        {
            InserirCommand = new Command(Inserir);

            usuarioService = new UsuarioService();
        }
    }
}
