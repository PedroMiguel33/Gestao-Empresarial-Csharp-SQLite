using gestaoEmpresarial.org.BancoDados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestaoEmpresarial.org.Formularios
{
    public partial class CBLAdicionarLogin : Form
    {
        public CBLAdicionarLogin()
        {
            InitializeComponent();
        }

        private void CBLAdicionarLogin_Load(object sender, EventArgs e)
        {
            txt_nome.Clear();
            txt_username.Clear();
            txt_senha.Clear();
            cb_status.SelectedIndex = -1;
            txt_nome.Focus();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Usuario usuário = new Usuario();
            usuário.nome = txt_nome.Text;
            usuário.username = txt_username.Text;
            usuário.password = txt_senha.Text;
            usuário.status = cb_status.Text;
            usuário.nivel = Convert.ToInt32(Math.Round(np_nivel.Value, 0));
            Banco.NovoUsuario(usuário);
            richTextBox1.Text = $"Informações: \nNome: {txt_nome.Text}\nUsuário: {txt_username.Text}\nSenha: {txt_senha.Text}\nStatus: {cb_status.SelectedItem}\nNivel: {np_nivel.Value.ToString()}";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nome.Clear();
            txt_senha.Clear();
            txt_username.Clear();
            cb_status.Text = "";
            np_nivel.Value = 0;
            txt_nome.Focus();
        }

        private void cls_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
