using CaraOuCoroa.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaraOuCoroa.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DesafioView : ContentPage
    {
        public DesafioView()
        {
            InitializeComponent();
            this.BindingContext = new DesafioViewModel();
        }
    }
}