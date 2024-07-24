using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using gestaoEmpresarial.org.BancoDados;
using gestaoEmpresarial.org.Formularios;
using gestaoEmpresarial.org.Formularios.org.Formilarios.Configuracoes;

namespace gestaoEmpresarial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CBLogin login = new CBLogin(this);
            login.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void abrirForm(int nivel, Form f)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= nivel)
                {
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido".ToUpper(), "CBL ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado".ToUpper(), "CBL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                CBLEmpregado alunoF = new CBLEmpregado();
                abrirForm(1, alunoF);
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado".ToUpper(), "CBL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gestãoDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLGestaoDeEmpregados gestão_De_Alunos = new CBLGestaoDeEmpregados();
            abrirForm(2, gestão_De_Alunos);
        }

        private void novoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLAdicionarLogin adicionarLogin = new CBLAdicionarLogin();
            abrirForm(1, adicionarLogin);
        }

        private void gestãoDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLSuperiores gestão = new CBLSuperiores();
            abrirForm(1, gestão);
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 2)
                {
                    string diretorioBanco = Globais.caminhoBanco + Globais.nomeBanco;
                    if (File.Exists(diretorioBanco))
                    {
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.UseShellExecute = false;
                        psi.CreateNoWindow = true;
                        psi.Arguments = $"start {diretorioBanco}";
                        Process.Start(diretorioBanco);
                    }
                    else
                    {
                        MessageBox.Show("Banco de dados não localizado!".ToUpper(), "CBL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Acesso não permitido".ToUpper(), "CBL ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado".ToUpper(), "CBL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void horáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLHorarios horariosF = new CBLHorarios();
            abrirForm(2, horariosF);
        }

        private void superioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLGestaoDeSuperiores professoresF = new CBLGestaoDeSuperiores();
            abrirForm(2, professoresF);
        }

        private void setoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLGestaoDeSetores gestãoF = new CBLGestaoDeSetores();
            abrirForm(2, gestãoF);
        }

        private void lOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBLogin login = new CBLogin(this);
            login.ShowDialog();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lb_acesso.Text = "0";
            lb_nomeUsuario.Text = "---";
            Globais.nivel = 0;
            Globais.logado = false;
        }

        #region Configurações de botões (Designer, chamda de métodos, código e etc...)
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

        private void cls_MouseHover(object sender, EventArgs e)
        {
            cls.IconColor = Color.Red;
        }

        private void cls_MouseLeave(object sender, EventArgs e)
        {
            cls.IconColor = Color.Silver;
        }

        private void min_MouseHover(object sender, EventArgs e)
        {
            min.IconColor = Color.FromArgb(100, 100, 100);
        }

        private void min_MouseLeave(object sender, EventArgs e)
        {
            min.IconColor = Color.Silver;
        }
        #endregion
    }
}
