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
    public partial class FormaPagamento : Form
    {

        classFormaPagamento form = new classFormaPagamento();  
        public FormaPagamento()
        {
            InitializeComponent();
            dataGridView1.DataSource = form.ListarFormaDePagamento();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Enabled = true;
            label1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            label4.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            textBox1.Enabled = false;
            label1.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            label4.Enabled = true;
            textBox4.Enabled = true;
            label4.Enabled = true;
            textBox4.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String desc = textBox1.Text;
            classFormaPagamento Form = new classFormaPagamento();
            Form.cadastrarFormaPagamento(desc);
            groupBox1.Enabled = false;
            textBox1.Enabled = false;
            label1.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            label4.Enabled = true;
            textBox4.Enabled = true;
            label4.Enabled = true;
            textBox4.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = form.ListarFormaDePagamento(textBox4.Text);
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
