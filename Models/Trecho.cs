using System;
using System.ComponentModel;

namespace Labtech.Models
{
    public class Trecho : INotifyPropertyChanged
    {
        private string _nomeTrecho;
        public string NomeTrecho
        {
            get
            {
                return _nomeTrecho;
            }
            set
            {
                _nomeTrecho = value;
                RaisePropertyChange("NomeTrecho");
            }
        }

        private string _pontoInicial;
        public string PontoInicial
        {
            get
            {
                return _pontoInicial;
            }
            set
            {
                _pontoInicial = value;
                RaisePropertyChange("PontoInicial");
            }
        }

        private string _pontoFinal;
        public string PontoFinal
        {
            get
            {
                return _pontoFinal;
            }
            set
            {
                _pontoFinal = value;
                RaisePropertyChange("PontoFinal");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Método que tem raise quando um objeto tem a propriedade alterada
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
