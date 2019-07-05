using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using Labtech.Utilidades;
using Labtech.Janelas.Asfalto;
using msg = System.Windows.Forms.MessageBox;
using Stimulsoft;
using System.IO;
using Labtech.Janelas;
using System.Windows.Forms;

namespace Labtech
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            licenseStimulsoft();
            setCulture();
        }

        // Licencia a aplicação para usar os relatórios stimulsoft
        private void licenseStimulsoft()
        {
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHktWurXLF+WTZZGQRq5yOOTj1io3uufpWCk0PYYDpCEytnU76" +
            "WxthaiSrtFPNqmO9HouoRv7/vgzsFlXyVJCVvBOpU6QRH1gmGyF8/i/aYHZx2H3nYDy0uIXr3a53Vg1Ur/Yjv0F5Pz" +
            "OoFKdyZrJvrd3k3VFE9q2NOPH99wlBUbpzvG1n4V7c+cWlNavRTBX7u5YHyZVHLxIltrr7jTE8uHPXXl2f/aeeAvKw" +
            "94yBvL4RuJuRP0UW+bGCsz6m8tSzALkeMGFAljgTPqLm7cE3G0YyptDbYgk3c0XJP8L4Vy2N+flqC83YoZBROkW4KI" +
            "UPzs07hjdb4rNlwJ8om+62L1yHzYRtuacXGLwmW1bhfWP+9E55AaXrZBdcA1qYF+ODyOtDwBoWz9lo0TznM6g6BbMc" +
            "IWY0+A6qoYEyHggJvCnqXG7KpnC8UEtBbUQb3P42E0Xn6zZX2CR9gsMgLmYabniE9KoAmdrKp3nzXrIUyRMRxu3ID6" +
            "PWBV8d7SJHyAjnIIL8QXWNEcNI9+nCzAZMAKkjLyUETwz1U/x9XTHmYK+A==";
        }

        // Aplica cultura pt-BR
        private void setCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        // Item do menu para criar projeto
        private void MenuCriarProjeto_Click(object sender, RoutedEventArgs e)
        {
            CadastroProjeto cad = new CadastroProjeto();
            cad.Show();
        }

        // Item do menu para abrir projeto
        private void MenuAbrirProjeto_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Selecione a pasta do projeto";
            DialogResult dr = fb.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fb.SelectedPath);
                var list = dir.GetFiles("*.xml");
                if (list.Length > 1)
                {
                    System.Windows.MessageBox.Show("Para abrir o projeto, é necessário somente conter um arquivo .xml na pasta raiz.","Informativo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                } else if(list.Length < 1)
                {
                    System.Windows.MessageBox.Show("A pasta selecionada não contém um arquivo .xml de projeto", "Informativo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                else
                {
                    foreach (var item in list)
                    {
                        // Seta as vars do projeto e atualiza o projeto selecionado
                        ProjectVars.currentProjectFolderPath = fb.SelectedPath;
                        ProjectVars.currentProjectFilePath = item.FullName;
                        ProjectVars.currentProjectFileName = item.Name;
                        ProjectVars.currentProjectDbPath = Path.Combine(fb.SelectedPath, "recursos", "dados", "lab.db");
                        string currentProjectFileNameWithoutXml = ProjectVars.currentProjectFileName.Replace(".xml", "");
                        txtCurrentProject.Text = currentProjectFileNameWithoutXml;
                        enableMenus();
                    }
                }

            }
        }

        // Habilita menu caso algum projeto esteja selecionado
        private void enableMenus()
        {
            menuAsfalto.IsEnabled = true;
            menuConcreto.IsEnabled = true;
            menuSolos.IsEnabled = true;
            menuObras.IsEnabled = true;
            menuGerenciar.IsEnabled = true;
        }
        private void disableMenus()
        {
            menuAsfalto.IsEnabled = false;
            menuConcreto.IsEnabled = false;
            menuSolos.IsEnabled = false;
            menuObras.IsEnabled = false;
            menuGerenciar.IsEnabled = false;

        }

        private void MenuExtracaoComGranulometria_Click(object sender, RoutedEventArgs e)
        {
            ExtracaoBetumeGranulometria extr = new ExtracaoBetumeGranulometria();
            extr.Show();
        }

        private void MenuObras_Click(object sender, RoutedEventArgs e)
        {
            CadastroObras cadastro = new CadastroObras();
            cadastro.Show();
        }
    }
}
