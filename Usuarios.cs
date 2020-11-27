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
    public partial class Usuarios : Form
    {
        classUsuario usuario = new classUsuario();
        int id;
        SqlDataReader Leitor = null;
        int paginaAtual;
        
        public Usuarios()
        {
            InitializeComponent();
            dataGridView1.DataSource = usuario.ListarUsuario();
            dataGridView1.Columns[0].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = usuario.ListarUsuario(textBox4.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            id = 0;
            groupBox1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button3.Enabled = false;
            label4.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button3.Enabled = true;
            label4.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            

          if(id > 0){
              String nome = textBox1.Text;
              String login = textBox2.Text;
              String senha = textBox3.Text;
              UsuarioDao Usuario = new UsuarioDao();
              Usuario.editarUsuario(id,nome, login, senha);
              groupBox1.Enabled = false;
              textBox1.Enabled = false;
              textBox2.Enabled = false;
              textBox3.Enabled = false;
              label1.Enabled = false;
              label2.Enabled = false;
              label3.Enabled = false;
              button7.Enabled = false;
              button8.Enabled = false;
              button3.Enabled = true;
              label4.Enabled = true;
              textBox4.Enabled = true;
              dataGridView1.DataSource = usuario.ListarUsuario();
              dataGridView1.Columns[0].Visible = false;
              textBox1.Text = "";
              textBox2.Text = "";
              textBox3.Text = "";
          }
          else if (id == 0){

              String nome = textBox1.Text;
              String login = textBox2.Text;
              String senha = textBox3.Text;
              classUsuario Usuario = new classUsuario();
              Usuario.cadastrarUsuario(nome, login, senha);
              groupBox1.Enabled = false;
              textBox1.Enabled = false;
              textBox2.Enabled = false;
              textBox3.Enabled = false;
              label1.Enabled = false;
              label2.Enabled = false;
              label3.Enabled = false;
              button7.Enabled = false;
              button8.Enabled = false;
              button3.Enabled = true;
              label4.Enabled = true;
              textBox4.Enabled = true;
              dataGridView1.DataSource = usuario.ListarUsuario();
              dataGridView1.Columns[0].Visible = false;
              textBox1.Text = "";
              textBox2.Text = "";
              textBox3.Text = "";
          }

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsuarioDao user = new UsuarioDao();
            user.excluirusuario(id);
            dataGridView1.DataSource = usuario.ListarUsuario();
            dataGridView1.Columns[0].Visible = false;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
           
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
            SqlCommand cmd = new SqlCommand("SELECT nomeUsuario,loginUsuario,senhaUsuario from tbUsuario", con.con);
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
                String cpfCliente = Leitor.GetString(1);
                String rgCliente = Leitor.GetString(2);
                
                //inicia A Impressã0
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(nomeCliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(cpfCliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 300, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(rgCliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 480, PosicaoDaLinha, new StringFormat());
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

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button3.Enabled = false;
            label4.Enabled = false;
            textBox4.Enabled = false;
            
        }
        
    }
}
