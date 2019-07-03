using System;
using System.Windows;
using Labtech.Utilidades;

namespace Labtech.Janelas
{
    /// <summary>
    /// Lógica interna para CadastroObras.xaml
    /// </summary>
    public partial class CadastroObras : Window
    {
        public CadastroObras()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtProjeto.Text = ProjectVars.currentProjectFileName;
        }
    }
}
