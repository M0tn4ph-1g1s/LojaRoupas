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
using System.Data.SqlClient;
using System.Drawing.Printing;
namespace LojaRoupas
{
    public partial class Categoria : Form
    {
        int id;
        SqlDataReader Leitor = null;
        int paginaAtual;
        classCategoria categoria = new classCategoria();  
        public Categoria()
        {
            InitializeComponent();
            dataGridView1.DataSource = categoria.ListarCategoria();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id = 0;
            groupBox1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button3.Enabled = false;
            textBox1.Text = "";
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button3.Enabled = true;
            textBox1.Text = "";
            dataGridView1.DataSource = categoria.ListarCategoria();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(id > 0){
                String desc = textBox1.Text;
                CategoriaDao Form = new CategoriaDao();
                Form.editarCategoria(id,desc);
                groupBox1.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button3.Enabled = true;
                textBox1.Text = "";
                dataGridView1.DataSource = categoria.ListarCategoria();
                dataGridView1.Columns[0].Visible = false;
            
            }
            else if(id == 0)
            {
            String desc = textBox1.Text;
            classCategoria Form = new classCategoria();
            Form.cadastrarCategoria(desc);
            groupBox1.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button3.Enabled = true;
            textBox1.Text = "";
            dataGridView1.DataSource = categoria.ListarCategoria();
            dataGridView1.Columns[0].Visible = false;
            }
        }

        private void Categoria_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = categoria.ListarCategoria(textBox4.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button3.Enabled = false;
            id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CategoriaDao Form = new CategoriaDao();
            Form.excluirCategria(id);
            dataGridView1.DataSource = categoria.ListarCategoria();
            dataGridView1.Columns[0].Visible = false;
            groupBox1.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button3.Enabled = true;
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
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
                    obj.Text = "RELATORIO CLIENTE";
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
            SqlCommand cmd = new SqlCommand("SELECT descCategoria from tbCategoria", con.con);
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
                
                String nomeCliente = Leitor.GetString(0);
               
                //inicia A Impressã0
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(nomeCliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
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

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button3.Enabled = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
