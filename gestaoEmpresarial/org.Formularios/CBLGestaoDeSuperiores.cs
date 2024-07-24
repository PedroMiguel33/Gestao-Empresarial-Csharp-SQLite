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

namespace gestaoEmpresarial.org.Formularios.org.Formilarios.Configuracoes
{
    public partial class CBLGestaoDeSuperiores : Form
    {
        public CBLGestaoDeSuperiores()
        {
            InitializeComponent();
        }

        private void CBLGestaoDeSuperiores_Load(object sender, EventArgs e)
        {
            string vquery = @"
                SELECT
                    N_IDPROFESSOR as 'ID',
                    T_NOMEPROFESSOR as 'Nome do Professor',
                    T_TELEFONE as 'Telefone'
                    FROM
                    tb_professores
            ";
            dgv_superiores.DataSource = Banco.dql(vquery);
            dgv_superiores.Columns[0].Width = 50;
            dgv_superiores.Columns[1].Width = 150;
            dgv_superiores.Columns[2].Width = 100;
        }

        private void dgv_superiores_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if (contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string vquery = @"
                    SELECT 
                        *
                        FROM
                        tb_professores
                        WHERE 
                        N_IDPROFESSOR =" + vid;
                dt = Banco.dql(vquery);
                txt_id.Text = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString();
                txt_nomeSuperior.Text = dt.Rows[0].Field<string>("T_NOMEPROFESSOR");
                txt_telefone.Text = dt.Rows[0].Field<string>("T_TELEFONE");


                if (contLinhas <= 0)
                {
                    MessageBox.Show("NÃO TEM MAIS LINHAS");
                }
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_nomeSuperior.Clear();
            txt_telefone.Clear();
            txt_nomeSuperior.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (txt_id.Text == "")
            {
                vquery = "INSERT INTO tb_professores (T_NOMEPROFESSOR, T_TELEFONE) VALUES ('" + txt_nomeSuperior.Text + "','" + txt_telefone.Text + "')";
            }
            else
            {
                vquery = "UPDATE tb_professores SET T_NOMEPROFESSOR='" + txt_nomeSuperior.Text + "', T_TELEFONE = '" + txt_telefone.Text + "' WHERE N_IDPROFESSOR=" + txt_id.Text;
            }
            Banco.dml(vquery);
            vquery = @"
                SELECT
                    N_IDPROFESSOR as 'ID',
                    T_NOMEPROFESSOR as 'Nome do Professor',
                    T_TELEFONE as 'Telefone'
                    FROM
                        tb_professores
                    ORDER BY
                        N_IDPROFESSOR
            ";
            dgv_superiores.DataSource = Banco.dql(vquery);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma exclusão?".ToUpper(), "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string vquery = "DELETE FROM tb_professores WHERE N_IDPROFESSOR =" + txt_id.Text;
                Banco.dml(vquery);
                dgv_superiores.Rows.Remove(dgv_superiores.CurrentRow);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
