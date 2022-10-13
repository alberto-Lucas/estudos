using CaraOuCoroa.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CaraOuCoroa.View
{
    public class DesafioViewModel : BaseNotifyViewModel
    {

        public string LadoMoeda { get; set; }

        public string Resultado { get; set; }

        public string Cor { get; set; }

        private void Jogar(int value)
        {
            int aux = new Random().Next(0, 2);
            if (aux == value)
            {
                LadoMoeda = "CARA";
                Resultado = "GANHOU!";
                Cor = "Green";
            }
            else
            {
                LadoMoeda = "COROA";
                Resultado = "PERDEU!";
                Cor = "Red";
            }

            OnPropertyChanged("Resultado");
            OnPropertyChanged("Cor");
            OnPropertyChanged("LadoMoeda");
        }

        public Command btnCara
        {
            get
            {
                return new Command(() =>
                {
                    this.Jogar(0);
                });
            }
        }

        public Command btnCoroa
        {
            get
            {
                return new Command(() =>
                {
                    this.Jogar(1);
                });
            }
        }
    }
}
