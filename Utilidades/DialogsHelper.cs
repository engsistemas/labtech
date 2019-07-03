using System;
using System.Windows.Forms;

namespace Labtech.Utilidades
{
    public static class DialogsHelper
    {
        // Método que pede para o usuário selecionar uma pasta e retorna o caminho para a mesma
        public static string getFolderPath(string descriptiveMessage)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = descriptiveMessage;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                return fb.SelectedPath;
            } else { return null; }
        }

        // Pergunta se o usuário quer ver o erro
        public static void askUserToSeeError(Exception ex)
        {
            DialogResult dr = MessageBox.Show("Ocorreu um erro de operação, deseja ver a descrição do erro?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
