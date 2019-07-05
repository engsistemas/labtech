using System;
using System.Collections.ObjectModel;
using System.Windows;
using Labtech.Models;


namespace Labtech.Janelas.Asfalto
{
    /// <summary>
    /// Lógica interna para ExtracaoBetumeGranulometria.xaml
    /// </summary>
    public partial class ExtracaoBetumeGranulometria : Window
    {
        ObservableCollection<Peneira> peneiras;
        public ExtracaoBetumeGranulometria()
        {
            InitializeComponent();
            peneiras = new ObservableCollection<Peneira>();
            dgridGranulometria.ItemsSource = peneiras;
            initializePeneiras();
        }

        private void initializePeneiras()
        {
            // Inicialização das peneiras e adicionar na lista
            Peneira Peneira50p00mm = new Peneira { NumeroMalha = " 2\"", AberturaMalha = 50.00 };
            Peneira Peneira37p50mm = new Peneira { NumeroMalha = " 1 1/2\"", AberturaMalha = 37.500 };
            Peneira Peneira25p00mm = new Peneira { NumeroMalha = " 1\"", AberturaMalha = 25.000 };
            Peneira Peneira19p00mm = new Peneira { NumeroMalha = " 3/4\"", AberturaMalha = 19.000 };
            Peneira Peneira12p50mm = new Peneira { NumeroMalha = " 1/2\"", AberturaMalha = 12.500 };
            Peneira Peneira09p50mm = new Peneira { NumeroMalha = " 3/8\"", AberturaMalha = 09.500 };
            Peneira Peneira06p30mm = new Peneira { NumeroMalha = " 1/4\"", AberturaMalha = 06.300 };
            Peneira Peneira04p75mm = new Peneira { NumeroMalha = " Nº 4", AberturaMalha = 04.750 };
            Peneira Peneira02p36mm = new Peneira { NumeroMalha = " Nº 8", AberturaMalha = 02.360 };
            Peneira Peneira02p00mm = new Peneira { NumeroMalha = " Nº 10", AberturaMalha = 02.000 };
            Peneira Peneira01p18mm = new Peneira { NumeroMalha = " Nº 16", AberturaMalha = 01.180 };
            Peneira Peneira00p60pmm = new Peneira { NumeroMalha = " Nº 30", AberturaMalha = 00.600 };
            Peneira Peneira00p425mm = new Peneira { NumeroMalha = " Nº 40", AberturaMalha = 00.425 };
            Peneira Peneira00p30mm = new Peneira { NumeroMalha = " Nº 50", AberturaMalha = 00.300 };
            Peneira Peneira00p15mm = new Peneira { NumeroMalha = " Nº 100", AberturaMalha = 00.150 };
            Peneira Peneira00p075mm = new Peneira { NumeroMalha = " Nº 200", AberturaMalha = 00.075 };
            peneiras.Add(Peneira50p00mm);
            peneiras.Add(Peneira37p50mm);
            peneiras.Add(Peneira25p00mm);
            peneiras.Add(Peneira19p00mm);
            peneiras.Add(Peneira12p50mm);
            peneiras.Add(Peneira09p50mm);
            peneiras.Add(Peneira06p30mm);
            peneiras.Add(Peneira04p75mm);
            peneiras.Add(Peneira02p36mm);
            peneiras.Add(Peneira02p00mm);
            peneiras.Add(Peneira01p18mm);
            peneiras.Add(Peneira00p60pmm);
            peneiras.Add(Peneira00p425mm);
            peneiras.Add(Peneira00p30mm);
            peneiras.Add(Peneira00p15mm);
            peneiras.Add(Peneira00p075mm);

        }
    }
}
