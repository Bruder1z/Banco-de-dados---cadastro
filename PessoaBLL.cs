using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastrodepessoas
{
    internal class PessoaBLL
    {
        public static void conecta()
        {
            PessoaDAL.conecta();
        }
        public static void desconecta()
        {
            PessoaDAL.desconecta();
        }

        public static void validaCodigo(Pessoa umaPessoa, char op)
        {
            Erro.setErro(false);
            if (umaPessoa.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (op == 'c')
                PessoaDAL.consultaUmaPessoa(umaPessoa);
            else
                PessoaDAL.excluiUmaPessoa(umaPessoa);
        }

        public static void validaDados(Pessoa umaPessoa, char op)
        {
            Erro.setErro(false);
            if (umaPessoa.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getNome().Equals(""))
            {
                Erro.setMsg("O Nome é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getSexo().Equals(""))
            {
                Erro.setMsg("O Sexo é de preenchimento obrigatório!");
                return;
            }
            if (umaPessoa.getIdade().Equals(""))
            {
                Erro.setMsg("A Idade é de preenchimento obrigatório!");
                return;
            }
            


            try
            {
                int.Parse(umaPessoa.getIdade());
            }
            catch (Exception)
            {
                Erro.setMsg("O valor da idade deve ser numérico!");
                return;
            }


            if (int.Parse(umaPessoa.getIdade()) <= 0)
            {
                Erro.setMsg("O valor da idade deve ser inteiro e maior que 0!");
                return;
            }
            if (op == 'i')
                PessoaDAL.inseriUmaPessoa(umaPessoa);
            else
                PessoaDAL.atualizaUmaPessoa(umaPessoa);
        }
    }
}
