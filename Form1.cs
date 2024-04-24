using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastrodepessoas
{
    public partial class Form1 : Form
    {
        Pessoa umaPessoa = new Pessoa();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            umaPessoa.setCodigo(textBox1.Text);
            umaPessoa.setNome(textBox2.Text);
            umaPessoa.setSexo(comboBox1.Text);
            umaPessoa.setIdade(maskedTextBox1.Text);

            PessoaBLL.validaDados(umaPessoa, 'i');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            umaPessoa.setCodigo(textBox1.Text);
            PessoaBLL.validaCodigo(umaPessoa, 'c');



            if (Erro.getErro())
            {
                MessageBox.Show("Código obrigatório.");
            }
            else
            {
                textBox1.Text = umaPessoa.getCodigo();
                textBox2.Text = umaPessoa.getNome();
                comboBox1.Text = umaPessoa.getSexo();
                maskedTextBox1.Text = umaPessoa.getIdade();
            }
                
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PessoaBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PessoaBLL.desconecta();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            umaPessoa.setCodigo(textBox1.Text);

            PessoaBLL.validaCodigo(umaPessoa, 'e');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Pessoa Excluído!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            umaPessoa.setCodigo(textBox1.Text);
            umaPessoa.setNome(textBox2.Text);
            umaPessoa.setIdade(maskedTextBox1.Text);
            umaPessoa.setSexo(comboBox1.Text);

            PessoaBLL.validaDados(umaPessoa, 'a');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados alterados com sucesso!");
        }
    }
}
