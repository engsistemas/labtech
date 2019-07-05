using System;
using System.Windows;
using Labtech.Utilidades;
using Labtech.Models;
using System.Collections.ObjectModel;
using DatabaseTools.SQLite;

namespace Labtech.Janelas
{
    /// <summary>
    /// Lógica interna para CadastroObras.xaml
    /// </summary>
    public partial class CadastroObras : Window
    {
        ObservableCollection<Trecho> listaDeTrechos;
        public CadastroObras()
        {
            InitializeComponent();
            listaDeTrechos = new ObservableCollection<Trecho>();
            gridTrecho.ItemsSource = listaDeTrechos;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtProjeto.Text = ProjectVars.currentProjectFileName.Replace(".xml","");
        }

        private void BtnAddTrecho_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTrecho.Text) && !String.IsNullOrEmpty(txtTrecho.Text) && !String.IsNullOrEmpty(txtTrecho.Text))
            {
                Trecho tr = new Trecho { NomeTrecho = txtTrecho.Text, PontoInicial = txtPontoIni.Text, PontoFinal = txtPontoFin.Text };
                listaDeTrechos.Add(tr);
                txtPontoIni.Text = txtPontoFin.Text;
                txtPontoFin.Text = "";
                txtTrecho.Text = "";
                
            } else
            {
                MessageBox.Show("Informação faltante no trecho, é necessário inserir todas as informações!");
            }
        }

        private void BtnSaveObra_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtObra.Text) || String.IsNullOrEmpty(txtLoca.Text) || String.IsNullOrEmpty(txtResp.Text))
            {
                MessageBox.Show("É necessário inserir no mínimo o nome da obra, a localização e o responsável", "Faltam informações", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                CRUD sql = new CRUD(ProjectVars.currentProjectDbPath);

                if (sql.CheckRegistryExistente("obra","nome_obra",txtObra.Text, $"Data Source={ProjectVars.currentProjectDbPath};Version=3;") == false)
                {
                    sql.voidQuery($"INSERT INTO obra (nome_obra,local_obra,responsavel_obra,contrato_obra,descricao_obra,inicio_obra,termino_obra,obs_obra) values ('{txtObra.Text}','{txtLoca.Text}','{txtResp.Text}','{txtContrato.Text}','{txtDesc.Text}','{dateInicio.Text}','{dateTermino.Text}','{txtObs.Text}')", "Erro ao inserir dados", "Erro desconhecido", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error, $"Data Source={ProjectVars.currentProjectDbPath};Version=3;");

                    if (listaDeTrechos.Count > 0)
                    {
                        foreach (Trecho tr in listaDeTrechos)
                        {
                            sql.voidQuery($"INSERT INTO trecho (nome_obra,nome_trecho,pontoini_trecho,pontofin_trecho) values ('{txtObra.Text}','{tr.NomeTrecho}','{tr.PontoInicial}','{tr.PontoFinal}')", "Erro ao inserir dados", "Erro desconhecido", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error, $"Data Source={ProjectVars.currentProjectDbPath};Version=3;");
                        }
                    }
                    MessageBox.Show("Obra cadastrada com sucesso!", "Informativo", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    MessageBox.Show("Já existe uma obra com este nome, os nomes devem ser únicos.");
                }
            }
        }
    }
}
