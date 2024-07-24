using gestaoEmpresarial.org.BancoDados;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class CBLEmpregado : Form
    {
        static string origemCompleto = "";
        static string foto = "";
        static string pastaDestino = Globais.caminhoFoto;
        static string DestinoCompleto = "";
        public CBLEmpregado()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_telefone.Enabled = true;
            txt_cargo.Clear();
            txt_telefone.Clear();
            txt_nome.Clear();
            txt_nome.Focus();
            txt_rg.Clear();
            txt_cpf.Clear();
            txt_dataNascimento.Clear();
            txt_enderecoResidencia.Clear();
            txt_email.Clear();
            txt_cargo.Clear();
            txt_nacionalidade.Clear();
            btn_salvar.Enabled = true;
            btn_novo.Enabled = false;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (DestinoCompleto == "")
            {
                if (MessageBox.Show("Sem foto selecionada, deseja continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            if (DestinoCompleto != "")
            {

                System.IO.File.Copy(origemCompleto, DestinoCompleto, true);
                if (File.Exists(DestinoCompleto))
                {
                    pb_foto.ImageLocation = DestinoCompleto;
                }
                else
                {
                    if (MessageBox.Show("Erro ao localizar foto, deseja continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            string queryInsertAluno = string.Format(@"
                INSERT INTO tb_alunos
                (T_NOMEALUNO,T_TELEFONE,T_STATUS,N_IDTURMA,T_FOTO,T_CPF,T_RG,T_NASCIMENTO,T_SEXO,T_ESTADOCIVIL,T_NACIONALIDADE,T_ENDERECOEMAIL,T_ENDERECORESIDENCIA)
                VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
            ", txt_nome.Text, txt_telefone.Text, cb_status.SelectedItem, txt_cargo.Tag.ToString(), DestinoCompleto, txt_cpf.Text, txt_rg.Text, txt_dataNascimento.Text, cb_generoSexo.SelectedItem.ToString(), cb_estadoCivil.SelectedItem.ToString(), txt_nacionalidade.Text, txt_email.Text, txt_enderecoResidencia.Text);
            Banco.dml(queryInsertAluno);
            MessageBox.Show("NOVO EMPREGADO ADICIONADO");


            txt_nome.Enabled = false;
            txt_telefone.Enabled = false;
            btn_novo.Enabled = false;
            btn_salvar.Enabled = false;
            pb_foto.ImageLocation = DestinoCompleto;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = false;
            txt_telefone.Enabled = false;
            txt_cargo.Clear();
            txt_telefone.Clear();
            txt_nome.Clear();
            btn_salvar.Enabled = false;
            btn_novo.Enabled = false;
        }

        private void btn_adicionarFoto_Click(object sender, EventArgs e)
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

        private void cls_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_OpenCargo_Click(object sender, EventArgs e)
        {
            CBLSelecionarSetor selecionaTurma = new CBLSelecionarSetor(this);
            selecionaTurma.ShowDialog();
        }

        private void CBLEmpregado_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> status = new Dictionary<string, string>();

            status.Add("A", "Ativo");
            status.Add("B", "Bloqueado");
            status.Add("C", "Cancelado");

            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";
        }
    }
}
