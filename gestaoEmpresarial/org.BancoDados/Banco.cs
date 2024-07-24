using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestaoEmpresarial.org.BancoDados
{
     class Banco
    {
        private static SQLiteConnection conexao;

        //Funções Genéricas
        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source =" + Globais.caminhoBanco + Globais.nomeBanco);
            conexao.Open();
            return conexao;
        }

        public static DataTable dql(string sql)//Data Query Language
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

        public static void dml(string q, string msgOk = null, string msgErro = null)//Data manipulation language (INSERT, DELET, UPDATE)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = q;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
                if (msgOk != null)
                {
                    MessageBox.Show(msgOk);
                }
            }
            catch (Exception ex)
            {
                if (msgErro != null)
                {
                    MessageBox.Show(msgErro + "\n" + ex.Message);
                }
                throw ex;
            }
        }


        public static DataTable ObterTodosOsUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = ConexaoBanco().CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                da.Fill(dt);
                ConexaoBanco().Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Função do FORM GESTÃO DE USUÁRIOS

        public static DataTable ObterOsUsuariosIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT N_IDUSUARIO as 'ID Usuário', T_NOMEUSUARIO as 'Nome Usuário' FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                da.Fill(dt);
                ConexaoBanco().Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable ObterDadosUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios WHERE N_IDUSUARIO =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //FIM Função do FORM GESTÃO DE USUÁRIOS

        //FUNÇÃO DO FORM USUÁRIO

        public static void NovoUsuario(Usuario u)
        {
            if (existeUsername(u))
            {
                MessageBox.Show("USERNAME JÁ EXISTENTE", "CBL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios (T_NOMEUSUARIO, T_USERNAME, T_SENHAUSUARIO, T_STATUSUSUARIO, N_NIVELUSUARIO) VALUES (@nome,@username,@senha,@status,@nivel)";
                cmd.Parameters.AddWithValue(@"nome", u.nome);
                cmd.Parameters.AddWithValue(@"username", u.username);
                cmd.Parameters.AddWithValue(@"senha", u.password);
                cmd.Parameters.AddWithValue(@"status", u.status);
                cmd.Parameters.AddWithValue(@"nivel", u.nivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("NOVO USUÁRIO INSERIDO");
                vcon.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO GRAVAR USUÁRIO", "CBL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //FIM FUNÇÃO FORM USUÁRIO



        ////ROTINAS GERAIS

        public static bool existeUsername(Usuario u)
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT T_USERNAME FROM tb_usuarios WHERE T_USERNAME = '" + u.username + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            vcon.Close();
            return res;
        }
    }
}

