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
    public partial class CBLHorarios : Form
    {
        public CBLHorarios()
        {
            InitializeComponent();
        }

        private void CBLHorarios_Load(object sender, EventArgs e)
        {
            string vquery = @"
                SELECT
                    N_IDHORARIO as 'ID',
                    T_DSCHORARIO as 'Horário'
                    FROM
                    tb_horarios
            ";
            dgv_horarios.DataSource = Banco.dql(vquery);
            dgv_horarios.Columns[0].Width = 50;
            dgv_horarios.Columns[1].Width = 150;
        }

        private void dgv_horarios_SelectionChanged(object sender, EventArgs e)
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
                        tb_horarios
                        WHERE 
                        N_IDHORARIO =" + vid;
                dt = Banco.dql(vquery);
                txt_id.Text = dt.Rows[0].Field<Int64>("N_IDHORARIO").ToString();
                mtb_dscHorario.Text = dt.Rows[0].Field<string>("T_DSCHORARIO");

                if (contLinhas <= 0)
                {
                    MessageBox.Show("NÃO TEM MAIS LINHAS");
                }
            }
        }

        private void btn_novoHorario_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            mtb_dscHorario.Clear();
            mtb_dscHorario.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (txt_id.Text == "")
            {
                vquery = "INSERT INTO tb_horarios (T_DSCHORARIO) VALUES ('" + mtb_dscHorario.Text + "')";
            }
            else
            {
                vquery = "UPDATE tb_horarios SET T_DSCHORARIO='" + mtb_dscHorario.Text + "' WHERE N_IDHORARIO =" + txt_id;
            }
            Banco.dml(vquery);
            vquery = @"
                SELECT
                    N_IDHORARIO as 'ID',
                    T_DSCHORARIO as 'Horário'
                    FROM
                    tb_horarios
            ";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma exclusão?".ToUpper(), "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string vquery = "DELETE FROM tb_horarios WHERE N_IDHORARIO =" + txt_id.Text;
                Banco.dml(vquery);
                dgv_horarios.Rows.Remove(dgv_horarios.CurrentRow);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
