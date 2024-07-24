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

namespace gestaoEmpresarial.org.Formularios.org.Formilarios.Configuracoes
{
    public partial class CBLGestaoDeEmpregados : Form
    {
        static string vqueryDGV = "";
        static string setorAtual = "";
        static string idSelecionado = "";
        static string setor = "";
        int linha = 0;
        static string origemCompleto = "";
        static string foto = "";
        static string pastaDestino = Globais.caminhoFoto;
        static string DestinoCompleto = "";
        public CBLGestaoDeEmpregados()
        {
            InitializeComponent();
        }

        private void CBLGestaoDeEmpregados_Load(object sender, EventArgs e)
        {
            vqueryDGV = @"
                SELECT 
                    N_IDALUNO as 'ID',
                    T_NOMEALUNO as 'Aluno'
                FROM
                    tb_alunos
            ";
            dgv_alunos.DataSource = Banco.dql(vqueryDGV);
            dgv_alunos.Columns[0].Width = 40;
            dgv_alunos.Columns[1].Width = 120;

            try
            {
                txt_nome.Text = dgv_alunos.Rows[dgv_alunos.Rows[0].Index].Cells[1].Value.ToString();
            }catch(Exception ex) { MessageBox.Show("NÃO HÁ EMPREGADOS."); }
            //Popular ComboBox Turmas

            string vqueryTurmas = @"
                SELECT 
                    N_IDTURMA,
                    ('Vagas: '|| ( 
                                    (N_MAXIMOALUNO)-(
                                                      SELECT
                                                            count(tba.N_IDALUNO)
                                                      FROM
                                                            tb_alunos as tba
                                                      WHERE 
                                                            tba.T_STATUS = 'A' and tba.N_IDTURMA=N_IDTURMA
                                                    )
                                )   || ' / Turma: ' || T_DSCTURMA
                    ) as 'Turma'
                FROM
                    tb_turmas
                ORDER BY 
                    N_IDTURMA
            ";

            cb_setor.Items.Clear();
            cb_setor.DataSource = Banco.dql(vqueryTurmas);
            cb_setor.DisplayMember = "Turma";
            cb_setor.ValueMember = "N_IDTURMA";


            //Popular ComboBox Status(Ativo = A, Bloqueado = B, Cancelado = C);
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("A", "Ativo");
            status.Add("B", "Bloqueado");
            status.Add("V", "Cancelado");
            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";

            setor = cb_setor.Text;
            setorAtual = cb_setor.Text;
            try
            {
                idSelecionado = dgv_alunos.Rows[0].Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("NÃO HÁ EMPREGADOS.");
            }
        }

        private void dgv_alunos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv_alunos.Rows[0].Cells.ToString();
                txt_nome.Text = dgv_alunos.Rows[dgv_alunos.SelectedRows[0].Index].Cells[1].Value.ToString();
                idSelecionado = dgv.Rows[dgv_alunos.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCampos = String.Format(@"
                    SELECT 
                        N_IDALUNO,
                        T_NOMEALUNO,
                        T_TELEFONE,
                        T_STATUS,
                        N_IDTURMA,
                        T_FOTO,
                        T_CPF,
                        T_RG,
                        T_NASCIMENTO
                    FROM
                        tb_alunos
                    WHERE N_IDALUNO = {0}
                ", idSelecionado);
                DataTable dt = Banco.dql(vqueryCampos);
                txt_nome.Text = dt.Rows[0].Field<string>("T_NOMEALUNO");
                txt_telefone.Text = dt.Rows[0].Field<string>("T_TELEFONE");
                cb_status.SelectedItem = dt.Rows[0].Field<string>("T_STATUS");
                cb_setor.SelectedItem = dt.Rows[0].Field<Int64>("N_IDTURMA");
                txt_cpf.Text = dt.Rows[0].Field<string>("T_CPF");
                txt_rg.Text = dt.Rows[0].Field<string>("T_RG");
                txt_dataNascimento.Text = dt.Rows[0].Field<string>("T_NASCIMENTO");
                setorAtual = cb_setor.Text;
                pb_foto.ImageLocation = dt.Rows[0].Field<string>("T_FOTO");
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            setor = cb_setor.Text;
            if (setorAtual != setor)
            {
                string[] t = setor.Split(' ');
                int vagas = int.Parse(t[1]);
                if (vagas < 1)
                {
                    MessageBox.Show("Não há vagas na turma selecionada, selecione outra turma");
                    cb_setor.Focus();
                    return;
                }
                linha = dgv_alunos.SelectedRows[0].Index;
                string queryAtualizarAluno = String.Format(@"
                    UPDATE
                       tb_alunos
                     SET
                        T_NOMEALUNO='{0}',
                         T_TELEFONE = '{1}',
                          T_STATUS = '{2}',
                           N_IDTURMA = '{3}',
                            T_CPF = '{4}',
                             T_RG = '{5}',
                              T_NASCIMENTO = '{6}',
                               T_FOTO = '{7}'
                      WHERE       
                        N_IDALUNO = {8}
                    ", txt_nome.Text, txt_telefone.Text,cb_status.SelectedItem, txt_cpf.Text, txt_rg.Text, txt_dataNascimento.Text, DestinoCompleto, idSelecionado);
                Banco.dml(queryAtualizarAluno);
                dgv_alunos[1, linha].Value = txt_nome.Text;
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclução?".ToUpper(), "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (File.Exists(pb_foto.ImageLocation))
                {
                    File.Delete(pb_foto.ImageLocation);
                }
                string vqueryExcluirAluno = String.Format(@"
                    DELETE FROM
                        tb_alunos
                    WHERE
                        N_IDALUNO = {0}  
                ", idSelecionado);
                Banco.dml(vqueryExcluirAluno);
                dgv_alunos.Rows.Remove(dgv_alunos.CurrentRow);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pb_foto_Click(object sender, EventArgs e)
        {
            origemCompleto = "";
            foto = "";
            pastaDestino = Globais.caminhoFoto;
            DestinoCompleto = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                origemCompleto = openFileDialog1.FileName;
                foto = openFileDialog1.SafeFileName;
                DestinoCompleto = pastaDestino + foto;
            }

            if (File.Exists(DestinoCompleto))
            {
                if (MessageBox.Show("Arquivo já existe, deseja substituir?", "Substituir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            pb_foto.ImageLocation = origemCompleto;
        }
    }
}
