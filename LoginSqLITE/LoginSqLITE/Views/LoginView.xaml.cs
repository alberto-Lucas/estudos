﻿using LoginSqLITE.ViewModels;
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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        /*
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroView());
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage.
            Navigation.PushModalAsync(new PrincipalView());
        }*/
    }
}