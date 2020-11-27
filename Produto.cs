using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaRoupas.Model;
using LojaRoupas.Dao;
using LojaRoupas.Control;
using System.Data.SqlClient;
using System.Drawing.Printing;
namespace LojaRoupas
{
    public partial class Produto : Form
    {

        classCategoria cat = new classCategoria();
        classFornecedor forn = new classFornecedor();
        classProduto produto = new classProduto();
        int id;
        SqlDataReader Leitor = null;
        int paginaAtual;

        public Produto()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           dataGridView1.DataSource = produto.ListarProduto(textBox5.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox5.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            button7.Enabled = false;
            button8.Enabled = false;
            textBox5.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                ProdutoDao fornDao = new ProdutoDao();
                string nomeProduto = textBox2.Text;
                string precoProduto = textBox3.Text;
                string qtdeEstoque = textBox4.Text;
                string fornecedor = comboBox1.Text;
                string categoria = comboBox2.Text;
                fornDao.editarProduto(id, nomeProduto, precoProduto, qtdeEstoque, categoria, fornecedor);
            }
            else
            {
                string nomeProduto = textBox2.Text;
                string precoProduto = textBox3.Text;
                string qtdeEstoque = textBox4.Text;
                string categoria = comboBox1.Text;
                string fornecedor = comboBox2.Text;
                int codFornecedor = forn.pegarCodigoFornecedor(fornecedor);
                int codCategoria = cat.pegarCodigoCategoria(categoria);
                int qtde = Convert.ToInt32(qtdeEstoque);
                Double preco = Convert.ToDouble(precoProduto);
                produto.cadastrarpro(nomeProduto, preco, codCategoria, codCategoria, qtde);
                groupBox1.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                textBox5.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Produto_Load(object sender, EventArgs e)
        {
            String[] listaCat = cat.carregarCategoria();
            foreach (string categoria in listaCat)
                comboBox2.Items.Add(categoria);

            String[] listaForn = forn.carregarFornecedor();
            foreach (string fornecedor in listaForn)
                comboBox1.Items.Add(fornecedor);
            dataGridView1.DataSource = produto.ListarProduto();
            dataGridView1.Columns[0].Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os eventos associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - definimos 3 eventos para tratar a 
            //Impressão:PrinPage,BeginPrint e EndPrint
            pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument1_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument1_EndPrint);
            //define o objeto para visualizar a impressão
            PrintPreviewDialog obj = new PrintPreviewDialog();
            try
            {
                {
                    obj.Document = pd;
                    obj.WindowState = FormWindowState.Maximized;
                    obj.Text = "RELATORIO PRODUTO";
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void printDocument1_BeginPrint(Object sender, EventArgs e)
        {
            conexão con = new conexão();
            con.conectar();

            SqlCommand cmd = new SqlCommand("SELECT nomeProduto,precoProduto,qtdeEstoque from tbproduto", con.con);
            Leitor = cmd.ExecuteReader();

            paginaAtual = 1;
        }
        public void printDocument1_PrintPage(Object sender, PrintPageEventArgs e)
        {
            //variaveis das linhas
            float linhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variavel para passar um traco
            Pen Risco = new Pen(Color.Black, 1);

            //Define as fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubtitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            //Titulo 
            e.Graphics.DrawString("RELATORIO CLIENTE ", FonteTitulo, Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());
            //Subtitulo 
            e.Graphics.DrawString("relatorio com os dados do cliente ", FonteTitulo, Brushes.Black, e.MarginBounds.Left + 320, 120, new StringFormat());
            //Campos a serem impressos
            e.Graphics.DrawString("campo 1", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 170, new StringFormat());
            e.Graphics.DrawString("campo 2", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 300, 170, new StringFormat());
            e.Graphics.DrawString("campo 2", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 480, 170, new StringFormat());
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 190, e.MarginBounds.Right, 190);

            //Linha por Página
            linhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < linhasPorPagina && Leitor.Read()))
            {
                //Contem os dados do DataReader
                String nomePro = Leitor.GetString(0);
                

                
               
                //inicia A Impressã0
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(nomePro.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
               
                LinhaAtual += 1;

                //Rodapé
                e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);
                e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

                LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
                LinhaAtual += 1;
                e.Graphics.DrawString("Página :" + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

                //Incrementa o Número da Pagina
                paginaAtual += 1;

                //Verifica se Continua Imprimindo
                if ((LinhaAtual > linhasPorPagina))
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }


            }




        }


        public void printDocument1_EndPrint(Object sender, EventArgs e)
        {
            conexão con = new conexão();
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            con.desconectar();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dataGridView1.Columns[0].Visible = false;
           
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            produto.excluirproduto(id);
            dataGridView1.DataSource = produto.ListarProduto();
            dataGridView1.Columns[0].Visible = false;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox5.Enabled = false;
            
        }
           
       }
   }

