using MVVM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            //injeção de dependencia
            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();

            MainPage = new NavigationPage(new Views.PrincipalView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
