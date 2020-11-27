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
    public partial class Vendas : Form
    {
        classVenda venda = new classVenda();
        conexão con = new conexão();
        SqlDataReader Leitor = null;
        int paginaAtual;
        Boolean data = false;
        Boolean codcliente = true;

        
        public Vendas()
        {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = venda.ListarVenda();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Enabled = true;
            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            label3.Enabled = true;
            button1.Enabled = true;
            textBox5.Text = "";

            button3.Enabled = false;
            textBox5.Enabled = false;
            label1.Enabled = false;
            data = true;
            codcliente = false;
           
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            label3.Enabled = false;
            button1.Enabled = false;
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";

            button3.Enabled = true;
            textBox5.Enabled = true;
            label1.Enabled = true;
            data = false;
            codcliente = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                int codCliente = Convert.ToInt16(textBox5.Text);
                dataGridView1.DataSource = venda.ListarVendaCaixa(codCliente);
            }
            else {
                dataGridView1.DataSource = venda.ListarVenda();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == true && maskedTextBox2.MaskCompleted == true)
            {

                string data1 = maskedTextBox1.Text;
                string data2 = maskedTextBox2.Text;
                dataGridView1.DataSource = venda.ListarVendaData2(data1, data2);
            }
            else
            {
                dataGridView1.DataSource = venda.ListarVenda();
            }
        }


        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == true && maskedTextBox2.MaskCompleted == true)
            {

                string data1 = maskedTextBox1.Text;
                string data2 = maskedTextBox2.Text;
                dataGridView1.DataSource = venda.ListarVendaData2(data1, data2);
            }
            else
            {
                dataGridView1.DataSource = venda.ListarVenda();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            //Image newImage = Image.FromFile("Image/logo.jpg");

            // tamanhos e posicionamento da imagem
            int x = 10;
            int y = 50;
            int width = 100;
            int height = 100;

            // Insere a imagem no relatório
            //e.Graphics.DrawImage(newImage, x, y, width, height);


            //Titulo
            e.Graphics.DrawString("Vendas PROGAMES", FonteTitulo, Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("Todas as Vendas - " +
System.DateTime.Now, FonteSubTitulo, Brushes.Black,
e.MarginBounds.Left + 320, 120, new StringFormat());

            //Campos a Serem Impressos
            e.Graphics.DrawString("campo 1", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 170, new StringFormat());
            e.Graphics.DrawString("campo 2", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 300, 170, new StringFormat());
            e.Graphics.DrawString("campo 3", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 480, 170, new StringFormat());
            e.Graphics.DrawString("campo 4", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 540, 170, new StringFormat());
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 190, e.MarginBounds.Right, 190);

            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina &&
Leitor.Read()))
            {
                //Ontém os Valores do DataReader
                DateTime dataVenda = Leitor.GetDateTime(0);
               
                int codUsuario = Leitor.GetInt32(2);
                int codCliente = Leitor.GetInt32(3);
                decimal  valorTotalVenda = Leitor.GetDecimal(1);


                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(dataVenda.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(valorTotalVenda.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 300, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(codUsuario.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 480, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(codUsuario.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 540, PosicaoDaLinha, new StringFormat());
                LinhaAtual += 1;
            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página :" + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }





        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            if(data == false && codcliente == true)
            {
                if (textBox5.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select dataVenda, valorTotalVenda, codUsuario, codCliente " +
                          "from tbVenda where codCliente = " + textBox5.Text + " ", con.con);
                    con.conectar();
                    Leitor = cmd.ExecuteReader();
                    paginaAtual = 1;
                }
                else {

                    SqlCommand cmd = new SqlCommand("select dataVenda, valorTotalVenda, codUsuario, codCliente " +
                              "from tbVenda  ", con.con);
                    con.conectar();
                    Leitor = cmd.ExecuteReader();
                    paginaAtual = 1;
                }
            }
            else
            if (data == true && codcliente == false)
            {

                if (maskedTextBox1.MaskCompleted == true && maskedTextBox2.MaskCompleted == true)
                {
                    SqlCommand cmd = new SqlCommand("select dataVenda, valorTotalVenda, codUsuario, codCliente " +
                           "from tbVenda where dataVenda BETWEEN '" + maskedTextBox1.Text + "' and '" + maskedTextBox2.Text + "' ", con.con);
                    con.conectar();
                    Leitor = cmd.ExecuteReader();
                    paginaAtual = 1;//Verificar esta linha
                }
                else {
                    SqlCommand cmd = new SqlCommand("select dataVenda, valorTotalVenda, codUsuario, codCliente " +
                                  "from tbVenda  ", con.con);
                    con.conectar();
                    Leitor = cmd.ExecuteReader();
                    paginaAtual = 1;
                
                }
            }
        }


        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            con.desconectar();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument1_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument1_EndPrint);

            PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
            try
            {
                //Define o formulário como Maximizado e com Zoom
                {
                    objPrintPreview.Document = pd;
                    objPrintPreview.WindowState = FormWindowState.Maximized;
                    objPrintPreview.PrintPreviewControl.Zoom = 1;
                    objPrintPreview.Text = "Relatorio Vendas";
                    objPrintPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
