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
        //Instancia da classe com os metodos de persistencia
        public UsuarioService usuarioService;


        #region properts

        //Propriedade do componente RefreshView para exibir icone de carregamento
        bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        //Criar uma lista de objetos
        private List<Usuario> _usuarioList;
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

            //Assim que a classe for instanciada ja ira carrega a lista de registros
            //neste cenario estamos usando o _ como despejo de memoria (uso opicional)
            _ = CarregarUsuarios(); 
        }

        async Task CarregarUsuarios()
        {
            //Exibimos o icone de carregamento assim que iniciamos a recupração dos registros
            IsRefreshing = true;

            try
            {
                //meotodo base que retorna todos os registros
                UsuarioList = await usuarioService.GetAllAsync();
            }
            catch (Exception ex)
            {   
                //Tratamento de excessão
                await App.Current.MainPage.DisplayAlert("Erro", "Erro original: " + ex.Message, "Ok");
            }
            finally
            {
                //Retira o icone de carregamento
                IsRefreshing = false;
            }
        }
    }
}
