using gestaoEmpresarial.org.BancoDados;
using gestaoEmpresarial.org.Formularios.org.Formilarios.Configuracoes;
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
    public partial class CBLSelecionarSetor : Form
    {
        CBLEmpregado formNovoAluno;
        public CBLSelecionarSetor(CBLEmpregado f)
        {
            InitializeComponent();
            formNovoAluno = f;
        }

        private void CBLGestaoDeSetores_Load(object sender, EventArgs e)
        {
            string queryTurmas = String.Format(@"
               SELECT 
                    tbt.N_IDTURMA as 'ID',
                    tbt.T_DSCTURMA as 'Turma',
                    tbh.T_DSCHORARIO as 'Horário',
                    tbp.T_NOMEPROFESSOR as 'Professor',
                    tbt.N_MAXIMOALUNO as 'Máx. Alunos',
                    (   SELECT
                            count(N_IDALUNO )
                        FROM
                            tb_alunos as tba 
                        WHERE 
                            tba.N_IDTURMA = tbt.N_IDTURMA and T_STATUS = 'A'     
                    ) as 'Qtde. Alunos'
               
               FROM
                    tb_turmas as tbt
               INNER JOIN 
                    tb_professores as tbp on tbp.N_IDPROFESSOR = tbt.N_IDPROFESSOR
               INNER JOIN 
                    tb_horarios as tbh on tbh.N_IDHORARIO = tbt.N_IDHORARIO
                    
            ");

            dgv_turmas.DataSource = Banco.dql(queryTurmas);
        }

        private void dgv_turmas_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_turmas_DoubleClick(object sender, EventArgs e)
        {
             DataGridView dataGridView = (DataGridView)sender;
            int maxalunos = 0;
            int qtdalunos = 0;
            maxalunos = Int32.Parse(dataGridView.SelectedRows[0].Cells[4].Value.ToString());
            qtdalunos = Int32.Parse(dataGridView.SelectedRows[0].Cells[5].Value.ToString());
            if(qtdalunos >= maxalunos)
            {
                MessageBox.Show("NÃO A VAGAS NESTA TURMA");
            }
            else
            {
                formNovoAluno.txt_cargo.Text = dataGridView.Rows[dataGridView.SelectedRows[0].Index].Cells[1].Value.ToString();
                formNovoAluno.txt_cargo.Tag = dataGridView.Rows[dataGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Close();
            }
        }
    }
}
