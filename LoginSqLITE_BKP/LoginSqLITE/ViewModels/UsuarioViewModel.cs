using LoginSqLITE.Models;
using LoginSqLITE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginSqLITE.ViewModels
{
    public class UsuarioViewModel : BaseNotifyViewModel
    {
        public UsuarioService usuarioService;

        private int _id;
        private string _nome;
        private string _email;
        private string _senha;
        private List<Usuario> _usuarioList;

        #region properts
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
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

        public List<Usuario> UsuarioList
        {
            get { return _usuarioList; }
            set
            {
                _usuarioList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand InserirCommand { get; set; }
        public ICommand AlterarCommand { get; set; }
        public ICommand ExcluirCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }

        public async void Inserir()
        {
            Usuario usuario = new Usuario()
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha
            };

            usuarioService.AddAsync(usuario);
            getTask();
        }

        public async void Alterar()
        {

        }
        public async void Excluir()
        {

        }
        public async void Consutlar()
        {

        }

        public UsuarioViewModel()
        {
            InserirCommand = new Command(Inserir);
            AlterarCommand = new Command(Alterar);
            ExcluirCommand = new Command(Excluir);
            ConsultarCommand = new Command(Consutlar);

            usuarioService = new UsuarioService();
        }

        public async void getTask()
        {
            UsuarioList = await usuarioService.GetAllAsync();
        }
    }
}
