using Labtech.Utilidades;
using System;
using System.IO;
using System.Windows;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Drawing;

namespace Labtech.Janelas
{
    /// <summary>
    /// Lógica interna para CadastroProjeto.xaml
    /// </summary>
    public partial class CadastroProjeto : Window
    {
        string pathToSelectedLogo = null;
        public CadastroProjeto()
        {
            InitializeComponent();
        }

        // Botão para salvar o projeto criado
        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(txtProjeto.Text))
            {
                // Seleciona a pasta para criar o projeto
                string folderPath = DialogsHelper.getFolderPath("Selecione uma pasta para criar o projeto.\nObs: Para manter a integridade do projeto sempre utilize uma pasta vazia.");
                //Checa se o valor retornado contem um caminho 
                // Caso retorne, procede ao algoritmo, caso retorne null, não realiza ação alguma
                if (!String.IsNullOrEmpty(folderPath))
                {
                    try
                    {
                        // Copia os arquivos base da pasta de instalação do software
                        XElement projectXML = new XElement("projeto",
                                                new XElement("nome", txtProjeto.Text),
                                                new XElement("descricao", txtDescricao.Text),
                                                new XElement("responsavel", txtResponsavel.Text),
                                                new XElement("cargo", txtCargo.Text),
                                                new XElement("observacoes", txtObs.Text),
                                                new XElement("razaosocial", txtRazaoSocial.Text),
                                                new XElement("cnpj", txtCnpj.Text),
                                                new XElement("endereco", txtEndereco.Text),
                                                new XElement("telefone", txtTelefone.Text),
                                                new XElement("email", txtEmail.Text),
                                                new XElement("site", txtSite.Text)
                                                );
                        string projectName = txtProjeto.Text.Replace(' ', '-');
                        // Salva o xml preenchido
                        projectXML.Save(Path.Combine(folderPath, projectName + ".xml"));

                        Directory.CreateDirectory(Path.Combine(Path.Combine(folderPath, "recursos")));
                        Directory.CreateDirectory(Path.Combine(Path.Combine(folderPath, "recursos", "relatorios")));
                        Directory.CreateDirectory(Path.Combine(Path.Combine(folderPath, "recursos", "logs")));
                        Directory.CreateDirectory(Path.Combine(Path.Combine(folderPath, "recursos", "dados")));
                        Directory.CreateDirectory(Path.Combine(Path.Combine(folderPath, "recursos", "imagens")));
                        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "Arquivos/Padrao/lab.db"), Path.Combine(Path.Combine(folderPath, "recursos", "dados", "lab.db")));
                        System.Windows.MessageBox.Show("Projeto criado com sucesso, abra o projeto para utilizar o sistema.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Fecha a janela
                        this.Close();

                        if (!String.IsNullOrEmpty(pathToSelectedLogo))
                        {
                            Image img = Image.FromFile(pathToSelectedLogo);
                            Bitmap bitmap = ImageProcessing.ResizeImage(img, 180, 150);
                            Image resizedImage = (Image)bitmap;
                            resizedImage.Save(Path.Combine(folderPath, "recursos", "imagens", "logo.png"), System.Drawing.Imaging.ImageFormat.Png);
                        }


                        clearFields();
                    }
                    catch (Exception ex)
                    {
                        Directory.Delete(folderPath, true);
                        DialogsHelper.askUserToSeeError(ex);
                    }
                }
            } else
            {
                System.Windows.MessageBox.Show("O nome do projeto deve ser inserido.", "Erro",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            
        }

        // Botão para limpar os campos
        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        // Método que limpa os campos textbox
        private void clearFields()
        {
            txtProjeto.Text = null;
            txtDescricao.Text = null;
            txtResponsavel.Text = null;
            txtCargo.Text = null;
            txtObs.Text = null;
            txtRazaoSocial.Text = null;
            txtCnpj.Text = null;
            txtEndereco.Text = null;
            txtTelefone.Text = null;
            txtEmail.Text = null;
            txtSite.Text = null;
        }

        // Botão seleciona imagem
        private void BtnSelecLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Arquivos de imagem|*.png;*.jpg;*.jpeg";
            DialogResult dr = op.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                imgLogo.Source = new BitmapImage(new Uri(op.FileName, UriKind.Absolute));
                pathToSelectedLogo = op.FileName;
            }
        }

    }
}
