using System;

namespace gestaoEmpresarial.org.BancoDados
{
    internal class Globais
    {
        public static string versao = "1.0";
        public static Boolean logado = false;
        public static int nivel = 0; 
        //0 = Básico
        //1 = Gerente
        //2 = Master
        public static string caminho = AppDomain.CurrentDomain.BaseDirectory.ToString();
        public static string nomeBanco = "bd_academia.db";
        public static string caminhoBanco = caminho + @"\banco\";
        public static string caminhoFoto = caminho + @"fotos\";
    }
}
