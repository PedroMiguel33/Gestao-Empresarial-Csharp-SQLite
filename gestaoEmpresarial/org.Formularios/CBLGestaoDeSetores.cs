using gestaoEmpresarial.org.BancoDados;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace gestaoEmpresarial.org.Formularios
{
    public partial class CBLGestaoDeSetores : Form
    {
        string idSelecionado;
        int modo = 0; //0=Padrão, 1=Edição, 2=Inserção
        string vqueryDGV;
        public CBLGestaoDeSetores()
        {
            InitializeComponent();
        }

        private void CBLGestaoDeSetores_Load(object sender, EventArgs e)
        {
            vqueryDGV = @"
                SELECT 
                tbt.N_IDTURMA as 'ID',
                tbt.T_DSCTURMA as 'Turma',
                tbh.T_DSCHORARIO as 'Horário'
            FROM
                tb_turmas as tbt
            INNER JOIN
                tb_horarios as tbh on tbh.N_IDHORARIO = tbt.N_IDHORARIO
            ";
            dgv_turmas.DataSource = Banco.dql(vqueryDGV);
            dgv_turmas.Columns[0].Width = 40;
            dgv_turmas.Columns[1].Width = 120;
            dgv_turmas.Columns[2].Width = 85;


            //Popular ComboBox Professores
            string vqueryProfessores = @"
                SELECT 
                    N_IDPROFESSOR,
                    T_NOMEPROFESSOR
                FROM
                    tb_professores
                ORDER BY
                    N_IDPROFESSOR
            ";

            cb_superiorSetor.Items.Clear();
            cb_superiorSetor.DataSource = Banco.dql(vqueryProfessores);
            cb_superiorSetor.DisplayMember = "T_NOMEPROFESSOR";
            cb_superiorSetor.ValueMember = "N_IDPROFESSOR";

            //Popular ComboBox Status (Ativa = A, Paralisada = P, Cancelada = C)
            Dictionary<string, string> st = new Dictionary<string, string>();

            st.Add("A", "Ativa");
            st.Add("P", "Paralisada");
            st.Add("C", "Cancelada");

            cb_status.Items.Clear();
            cb_status.DataSource = new BindingSource(st, null);
            cb_status.DisplayMember = "Values";
            cb_status.ValueMember = "Key";

            //Popular ComboBox Horários
            string vqueryHorarios = @"
                SELECT 
                    *
                FROM
                    tb_horarios
                ORDER BY
                    T_DSCHORARIO
            ";
            cb_horario.Items.Clear();
            cb_horario.DataSource = Banco.dql(vqueryHorarios);
            cb_horario.DisplayMember = "T_DSCHORARIO";
            cb_horario.ValueMember = "N_IDHORARIO";

        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            txt_nomeSetor.Clear();
            cb_superiorSetor.SelectedIndex = -1;
            n_maxEmpregados.Value = 0;
            cb_status.SelectedIndex = -1;
            cb_horario.SelectedIndex = -1;
            txt_nomeSetor.Focus();
            modo = 2;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
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
                    tb_turmas
                        SET
                    T_DSCTURMA = '{0}',
                    N_IDPROFESSOR = {1},
                    N_IDHORARIO = {2},
                    N_MAXIMOALUNO = {3},
                    T_STATUS = '{4}'
                       WHERE
                      N_IDTURMA = {5}", txt_nomeSetor.Text, cb_superiorSetor.SelectedValue, cb_horario.SelectedValue, Int32.Parse(Math.Round(n_maxEmpregados.Value, 0).ToString()), cb_status.SelectedValue, idSelecionado);
                }
                else
                {
                    msg = "Nova turma inserida";
                    queryTurma = String.Format(@"
                        INSERT INTO tb_turmas
                        (T_DSCTURMA, N_IDPROFESSOR, N_IDHORARIO, N_MAXIMOALUNO, T_STATUS) 
                        VALUES('{0}',{1},{2},{3},'{4}')", txt_nomeSetor.Text, cb_superiorSetor.SelectedValue, cb_horario.SelectedValue, Int32.Parse(Math.Round(n_maxEmpregados.Value, 0).ToString()), cb_status.SelectedValue);
                }

                int linha = dgv_turmas.SelectedRows[0].Index;

                Banco.dml(queryTurma);

                if (modo == 1)
                {
                    dgv_turmas[1, linha].Value = txt_nomeSetor.Text;
                    dgv_turmas[2, linha].Value = cb_horario.Text;
                }
                else
                {
                    dgv_turmas.DataSource = Banco.dql(vqueryDGV);
                }
                MessageBox.Show(msg);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma exclução?".ToUpper(), "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                string queryExcluirTurma = String.Format(@"
                    DELETE
                    FROM
                       tb_turmas
                    WHERE
                        N_IDTURMA = {0}", idSelecionado);
                Banco.dml(queryExcluirTurma);
                dgv_turmas.Rows.Remove(dgv_turmas.CurrentRow);
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string nomedoArquivo = Globais.caminho + @"\turmaas.pdf";
            FileStream arquivoPDF = new FileStream(nomedoArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);


            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Globais.caminho + @"\logocbl.png");
            logo.ScaleToFit(140f, 120f);
            //logo.Alignment = Element.ALIGN_CENTER;
            logo.SetAbsolutePosition(100f, 700f); //X And Y



            doc.Open();
            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 20, (int)System.Drawing.FontStyle.Bold));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("CBL\n");

            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic);
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("CBL C#\n");

            string texto = "CBL MODS";
            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12, (int)System.Drawing.FontStyle.Italic);
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add(texto + "\n");

            PdfPTable tabela = new PdfPTable(3);
            tabela.DefaultCell.FixedHeight = 20;

            PdfPCell celula = new PdfPCell(new Phrase("tabela de Preços"));
            celula.Colspan = 3;
            celula.Rotation = 90;
            tabela.AddCell(celula);

            tabela.AddCell("Código");
            tabela.AddCell("Produto");
            tabela.AddCell("Preço");

            tabela.AddCell("01");
            tabela.AddCell("Mouse");
            tabela.AddCell("25,00");

            tabela.AddCell("02");
            tabela.AddCell("Teclado");
            tabela.AddCell("65,00");


            celula.Phrase.Add("tabela de Preços");
            celula.Colspan = 3;
            celula.FixedHeight = 40;
            celula.HorizontalAlignment = Element.ALIGN_CENTER;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            tabela.AddCell(celula);


            doc.Add(paragrafo);
            doc.Close();
            doc.Add(logo);
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_turmas_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if (contLinhas > 0)
            {
                modo = 0;
                idSelecionado = dgv_turmas.Rows[dgv_turmas.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCampos = @"
                    SELECT 
                        T_DSCTURMA,
                        N_IDPROFESSOR,
                        N_IDHORARIO,
                        N_MAXIMOALUNO,
                        T_STATUS
                    FROM
                        tb_turmas
                    WHERE 
                        N_IDTURMA=" + idSelecionado;
                DataTable dt = Banco.dql(vqueryCampos);
                cb_superiorSetor.SelectedValue = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString();
                n_maxEmpregados.Value = dt.Rows[0].Field<Int64>("N_MAXIMOALUNO");
                cb_status.SelectedValue = dt.Rows[0].Field<string>("T_STATUS");
                cb_horario.SelectedValue = dt.Rows[0].Field<Int64>("N_IDHORARIO");
                txt_nomeSetor.Text = dt.Rows[0].Field<string>("T_DSCTURMA");

                //Cálculo de Vagas

                txt_vagas.Text = calvagas();
            }
        }

        private string calvagas()
        {

            string vqueryVagas = String.Format(@"
                    SELECT
                         count(N_IDALUNO) as 'contVagas'
                    FROM
                         tb_alunos
                    WHERE 
                        T_STATUS = 'A' and N_IDTURMA={0}", idSelecionado);
            DataTable dt = Banco.dql(vqueryVagas);
            dt = Banco.dql(vqueryVagas);
            int vagas = Int32.Parse(Math.Round(n_maxEmpregados.Value, 0).ToString());
            vagas -= Int32.Parse(dt.Rows[0].Field<Int64>("contVagas").ToString());
            txt_vagas.Text = vagas.ToString();
            return vagas.ToString();
        }

        private void txt_nomeSetor_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }


        private void cb_horario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void n_maxAlunos_ValueChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
            calvagas();
        }

        private void cb_superiorSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }
    }
}
