using gestaoEmpresarial.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestaoEmpresarial.org.BancoDados;
using System.Web.UI.WebControls;

namespace gestaoEmpresarial.org.Formularios
{
    public partial class CBLogin : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();
        public CBLogin(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }
        private void CBLogin_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login(txt_username.Text, txt_password.Text);
        }

        public void login(string username, string password)
        {
            if(username == null || password == null)
            {
                return;
            }

            string sql = "SELECT * FROM tb_usuarios WHERE T_USERNAME='" + username + "' AND T_SENHAUSUARIO='" + password + "'";
            dt = Banco.dql(sql);
            if (dt.Rows.Count == 1)
            {
                form1.lb_acesso.Text = dt.Rows[0].ItemArray[5].ToString();
                form1.lb_nomeUsuario.Text = dt.Rows[0].Field<string>("T_NOMEUSUARIO");
                Globais.nivel = int.Parse(dt.Rows[0].Field<Int64>("N_NIVELUSUARIO").ToString());
                Globais.logado = true;
                this.Close();
            }else { MessageBox.Show("USUÁRIO NÃO ENCONTRADO!", "CBL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

        }

        private void cls_Click(object sender, EventArgs e)
        {
            /* Muitas vezes o C# acaba ocorrendo erros, e não fecha uma aplicação por completo!
               Com o código abaixo estamos encerrado por completo nossa aplicação.
            */
            var proc = Process.GetProcessById(Process.GetCurrentProcess().Id);
            int process = proc.Id;
            if (process > 0)
            {
                Environment.Exit(0);
            }
        }
    }
}
