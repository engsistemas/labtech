using System;
using System.ComponentModel;

namespace Labtech.Models
{
    public class Peneira : INotifyPropertyChanged
    {
        // Propriedades
        // Número da malha
        private string _NumeroMalha;
        public string NumeroMalha
        {
            get { return _NumeroMalha; }
            set
            {
                _NumeroMalha = value;
                RaisePropertyChange("NumeroMalha");
            }
        }
        // Abertura da malha em MM
        private double _AberturaMalha;
        public double AberturaMalha
        {
            get { return _AberturaMalha; }
            set
            {
                _AberturaMalha = value;
                RaisePropertyChange("AberturaMalha");
            }
        }
        // Peso retido simples
        private double _PesoRetidoG;
        public double PesoRetidoG
        {
            get { return _PesoRetidoG; }
            set
            {
                _PesoRetidoG = value;
                RaisePropertyChange("PesoRetidoG");

            }
        }

        // Peso retido porc
        private double _PesoRetidoPrct;
        public double PesoRetidoPrct
        {
            get { return _PesoRetidoPrct; }
            set
            {
                _PesoRetidoPrct = value;
                RaisePropertyChange("PesoRetidoGac");
            }
        }

        //Peso retido ac
        private double _PesoRetidoPrctAc;
        public double PesoRetidoPrctAc
        {
            get { return _PesoRetidoPrctAc; }
            set
            {
                _PesoRetidoPrctAc = value;
                RaisePropertyChange("PesoRetidoPrctAc");
            }
        }

        // % Passante
        private double _PorcPassando;
        public double PorcPassando
        {
            get { return _PorcPassando; }
            set
            {
                _PorcPassando = value;
                RaisePropertyChange("PorcPassando");
            }
        }
        


        // Método que tem raise quando um objeto tem a propriedade alterada
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        // Evento da interface
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
