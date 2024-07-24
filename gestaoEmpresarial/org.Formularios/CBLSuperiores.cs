using gestaoEmpresarial.org.BancoDados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestaoEmpresarial.org.Formularios
{
    public partial class CBLSuperiores : Form
    {
        string idSelecionado;
        int modo = 0; //0=Padrão, 1=Edição, 2=Inserção
        string vqueryDGV;
        public CBLSuperiores()
        {
            InitializeComponent();
        }

        private void CBLSuperiores_Load(object sender, EventArgs e)
        {
            dgv_usuarios.DataSource = Banco.ObterOsUsuariosIdNome();
            dgv_usuarios.Columns[0].Width = 85;
            dgv_usuarios.Columns[1].Width = 190;

        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsuario(vid);
                txt_id.Text = dt.Rows[0].Field<Int64>("N_IDUSUARIO").ToString();
                txt_nome.Text = dt.Rows[0].Field<string>("T_NOMEUSUARIO").ToString();
                txt_usuario.Text = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                txt_senha.Text = dt.Rows[0].Field<string>("T_SENHAUSUARIO").ToString();
                cb_status.Text = dt.Rows[0].Field<string>("T_STATUSUSUARIO").ToString();
                np_nivel.Value = dt.Rows[0].Field<Int64>("N_NIVELUSUARIO");  
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cb_status_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {


                if (txt_id.Text != "")
                {
                    if (modo != 0)
                    {
                        string queryTurma = "";
                        string msg = "";
                        if (modo == 1)
                        {
                            msg = "Dados Alterados";
                            queryTurma = String.Format(@"
                      UPDATE 
                    tb_usuarios
                        SET
                    T_NOMEUSUARIO = '{0}',
                    T_USERNAME = '{1}',
                    T_SENHAUSUARIO = '{2}',
                    T_STATUSUSUARIO = '{3}'
                    N_NIVELUSUARIO = {4},
                       WHERE 
                    N_IDUSUARIO = {5}", txt_nome.Text, txt_usuario.Text, txt_senha.Text, cb_status.SelectedItem, np_nivel.Value, txt_id.Text);
                        }
                        int linha = dgv_usuarios.SelectedRows[0].Index;

                        Banco.dml(queryTurma);
                    }
                }
                else
                {
                    string vquery;

                    if (string.IsNullOrEmpty(txt_id.Text))
                    {
                        vquery = "INSERT INTO tb_usuarios " +
                            "(T_NOMEUSUARIO, " +
                            "T_USERNAME, " +
                            "T_SENHAUSUARIO, " +
                            "T_STATUSUSUARIO, " +
                            "N_NIVELUSUARIO) " +
                            "VALUES ('" + txt_nome.Text + "', '" + txt_usuario.Text + "', '" + txt_senha.Text + "', '" + cb_status.SelectedItem + "', " + np_nivel.Value + ")";
                    }
                    else
                    {
                        vquery = "UPDATE tb_usuarios SET T_NOMEUSUARIO = '" + txt_nome.Text + "', T_USERNAME = '" + txt_usuario.Text + "', " +
                                 "T_SENHAUSUARIO = '" + txt_senha.Text + "', T_STATUSUSUARIO = '" + cb_status.SelectedItem + "', " +
                                 "N_NIVELUSUARIO = " + np_nivel.Value + " " +
                                 "WHERE N_IDUSUARIO = " + txt_id.Text;
                    }

                    Banco.dml(vquery);

                    vquery = @"
                    SELECT
                        N_IDUSUARIO as 'ID',
                        T_NOMEUSUARIO as 'Nome',
                        T_USERNAME as 'Username',
                        T_STATUSUSUARIO as 'Status',
                        N_NIVELUSUARIO as 'Nível'
                    FROM
                        tb_usuarios
                ";
                }
            }
            catch (Exception)
            {
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            txt_nome.Clear();
            txt_usuario.Clear();
            txt_senha.Clear();
            cb_status.SelectedItem = -1;
            txt_nome.Focus();
            txt_id.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclução?".ToUpper(), "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string vqueryExcluirAluno = String.Format(@"
                    DELETE FROM
                        tb_usuarios
                    WHERE
                        N_IDUSUARIO = {0}  
                ", txt_id.Text);
                Banco.dml(vqueryExcluirAluno);
                dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
            }
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void cb_status_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void np_nivel_ValueChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }
    }
}
