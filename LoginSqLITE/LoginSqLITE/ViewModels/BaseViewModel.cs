using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginSqLITE.ViewModels
{
    public class BaseViewModel : BaseNotifyViewModel
    {
        bool _isPassword = true;
        public bool IsPassword
        {
            get { return _isPassword; }
            set
            {
                _isPassword = value;
                OnPropertyChanged();
            }
        }

        bool _isShowPassword = false;
        public bool IsShowPassword
        {
            get { return _isShowPassword; }
            set
            {
                _isShowPassword = value;
                OnPropertyChanged();
                IsPassword = !IsShowPassword;
            }
        }
        public ICommand MostrarSenhaCommand { get; set; }
        private void MostrarSenha()
        {
            IsShowPassword = !IsShowPassword;
        }
        public BaseViewModel()
        {
            MostrarSenhaCommand = new Command(MostrarSenha);
        }
    }
}
