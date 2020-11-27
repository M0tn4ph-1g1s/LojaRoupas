using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaRoupas.Model;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace LojaRoupas
{
    public partial class itmVenda : Form
    {
        classItemVenda ItemVenda = new classItemVenda();
        conexão con = new conexão();
        
        
        public itmVenda()
        {
            InitializeComponent();
        }

        private void itmVenda_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ItemVenda.ListarItemVenda();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                int codProduto = Convert.ToInt16(textBox5.Text);
                dataGridView1.DataSource = ItemVenda.ListarItemVendaProduto(codProduto);
            }
            else
            {
                dataGridView1.DataSource = ItemVenda.ListarItemVenda();
            }
        }
    }
}
