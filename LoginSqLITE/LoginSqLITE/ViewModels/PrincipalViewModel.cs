using LoginSqLITE.Models;
using LoginSqLITE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginSqLITE.ViewModels
{
    public class PrincipalViewModel : BaseNotifyViewModel
    {
        
        public UsuarioService usuarioService;

        bool _isRefreshing = false;
        private List<Usuario> _usuarioList;

        #region properts
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
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

        public ICommand CarregarUsuariosCommand { get; set; }

        public PrincipalViewModel()
        {
            CarregarUsuariosCommand = new Command(async () => await CarregarUsuarios());
            usuarioService = new UsuarioService();

            _ = CarregarUsuarios();
        }

        async Task CarregarUsuarios()
        {
            IsRefreshing = true;

            try
            {
                UsuarioList = await usuarioService.GetAllAsync(true);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro original: " + ex, "Ok");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
