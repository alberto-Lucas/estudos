using LoginSqLITE.Models;
using LoginSqLITE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginSqLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioView : ContentPage
    {

        public UsuarioView()
        {
            InitializeComponent();
            this.BindingContext = new UsuarioViewModel();
        }

       /* public UsuarioContexto usuarioContexto;
        public UsuarioView()
        {
            InitializeComponent();
            //txtId.Text = "0";
            usuarioContexto = new UsuarioContexto();

            lstUsuario.ItemsSource = usuarioContexto.conexao.Query<Usuario>("select * from usuario").ToList();
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    DisplayAlert("Atenção", "Informe o nome do Usuário", "OK");
                    return;
                }

                Usuario usuario = new Usuario()
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Senha = txtSenha.Text
                };

                usuarioContexto.Inserir(usuario);
                DisplayAlert("Atenção", "Usuário inserido com sucesso", "Ok");
            }
            catch (Exception ex)
            {

                DisplayAlert("Erro", ex.Message, "OK");
            }
        }*/
    }
}