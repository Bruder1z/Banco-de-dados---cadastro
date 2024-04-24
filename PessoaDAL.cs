using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace cadastrodepessoas
{
    internal class PessoaDAL
    {
        private static String strConexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BDAulas.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }

        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void inseriUmaPessoa(Pessoa umaPessoa)
        {
            String aux = "insert into TabPessoa(codigo,nome,sexo,idade) values ('" + umaPessoa.getCodigo() + "','" + umaPessoa.getNome() + "','" + umaPessoa.getSexo() + "','" + umaPessoa.getIdade() + "')";

            strSQL = new OleDbCommand(aux, conn);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Erro.setMsg("A inserção não foi possivel, chave duplicada");
            }
        }

        public static void consultaUmaPessoa(Pessoa umaPessoa)
        {
            String aux = "select * from TabPessoa where codigo = '" + umaPessoa.getCodigo() + "'";
            strSQL = new OleDbCommand(aux, conn);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                umaPessoa.setNome(result.GetString(1));
                umaPessoa.setSexo(result.GetString(2));
                umaPessoa.setIdade(result.GetString(3));
            }
            else
                Erro.setMsg("Pessoa não cadastrada.");
        }

        public static void atualizaUmaPessoa(Pessoa umaPessoa)
        {
            String aux = "update TabPessoa set nome=@nome, sexo=@sexo, idade=@idade where codigo =@codigo";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@nome", OleDbType.VarChar).Value = umaPessoa.getNome();
            strSQL.Parameters.Add("@sexo", OleDbType.VarChar).Value = umaPessoa.getSexo();
            strSQL.Parameters.Add("@idade", OleDbType.VarChar).Value = umaPessoa.getIdade();
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = umaPessoa.getCodigo();
            strSQL.ExecuteNonQuery();
        }
        public static void excluiUmaPessoa(Pessoa umapessoa)
        {
            String aux = "delete from TabPessoa where codigo = @codigo";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = umapessoa.getCodigo();
            strSQL.ExecuteNonQuery();
        }
    }
}
