using CaraOuCoroa.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaraOuCoroa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DesafioView();
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
