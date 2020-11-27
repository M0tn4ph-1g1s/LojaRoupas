using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaRoupas.Model;

namespace LojaRoupas
{
    public partial class Form1 : Form
    {

        classUsuario user = new classUsuario();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String senha = textBox2.Text;
            string[] Login = user.carregarLogin();
            string[] Senha = user.carregarSenha();
            int i = 0;
            Boolean logado = false;
            foreach (string Logar in Login)
            {
                if (login == Login[i] && senha == Senha[i])
                {

                    string users =   user.pegarUsuario(login, senha);
                    this.Hide();
                    Caixa newUsuario = new Caixa(users);
                    newUsuario.Show();
                    logado = true;

                }
                else
                {
                    i++;
                    
                }
            }
            if (logado == false)
            {
                MessageBox.Show("Login ou Senha está incorreto");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
