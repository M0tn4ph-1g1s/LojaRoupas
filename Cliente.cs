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
    public partial class Cliente : Form
    {
        classCliente cliente = new classCliente();
        public string nomeCliente;
        int id;
        SqlDataReader Leitor = null;
        int paginaAtual;
        public Cliente()
        {
            InitializeComponent();
            dataGridView1.DataSource = cliente.ListarCliente();
            dataGridView1.Columns[0].Visible = false;
            
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedIndex);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            classCliente cliente = new classCliente();

            if (id > 0)
            {
                ClienteDao dao = new ClienteDao();
                String nomeCliente = textBox1.Text;
                String cpfCliente = maskedTextBox1.Text;
                String rgCliente = textBox2.Text;
                String logradouroCliente = textBox3.Text;
                String numCliente = textBox4.Text;
                String compCliente = textBox7.Text;
                String bairroCliente = textBox6.Text;
                String cepCliente = maskedTextBox2.Text;
                String cidadeCliente = textBox5.Text;
                String ufCliente = comboBox1.Text;
                dao.editarcliente(id, nomeCliente, cpfCliente, rgCliente, logradouroCliente, numCliente, compCliente, bairroCliente, cepCliente, cidadeCliente);
                dataGridView1.DataSource = cliente.ListarCliente();
                dataGridView1.Columns[0].Visible = false;
           
            }
            else {
                String nomeCliente = textBox1.Text;
                String cpfCliente = maskedTextBox1.Text;
                String rgCliente = textBox2.Text;
                String logradouroCliente = textBox3.Text;
                String numCliente = textBox4.Text;
                String compCliente = textBox7.Text;
                String bairroCliente = textBox6.Text;
                String cepCliente = maskedTextBox2.Text;
                String cidadeCliente = textBox5.Text;
                String ufCliente = comboBox1.Text;

                foreach (string fone in listBox1.Items)
                {

                    cliente.ListFones.Add(fone);
                }
                cliente.cadastrarCliente(nomeCliente, cpfCliente, rgCliente, logradouroCliente, numCliente, compCliente, bairroCliente, cepCliente, cidadeCliente, ufCliente, cliente.ListFones);
                groupBox1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                maskedTextBox1.Enabled = false;
                maskedTextBox2.Enabled = false;
                maskedTextBox3.Enabled = false;
                textBox8.Enabled = true;
                button7.Enabled = false;
                button8.Enabled = false;
                dataGridView1.DataSource = cliente.ListarCliente();
                dataGridView1.Columns[0].Visible = false;
            
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id = 0;
            groupBox1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            comboBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            maskedTextBox3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox8.Enabled = false;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SP");
            comboBox1.Items.Add("TO");
            comboBox1.Items.Add("AC");
            comboBox1.Items.Add("AL");
            comboBox1.Items.Add("AM");
            comboBox1.Items.Add("AP");
            comboBox1.Items.Add("BA");
            comboBox1.Items.Add("CE");
            comboBox1.Items.Add("DF");
            comboBox1.Items.Add("ES");
            comboBox1.Items.Add("GO");
            comboBox1.Items.Add("MA");
            comboBox1.Items.Add("MG");
            comboBox1.Items.Add("MS");
            comboBox1.Items.Add("MT");
            comboBox1.Items.Add("PA");
            comboBox1.Items.Add("PB");
            comboBox1.Items.Add("PE");
            comboBox1.Items.Add("PI");
            comboBox1.Items.Add("PR");
            comboBox1.Items.Add("RJ");
            comboBox1.Items.Add("RN");
            comboBox1.Items.Add("RO");
            comboBox1.Items.Add("RR");
            comboBox1.Items.Add("RS");
            comboBox1.Items.Add("SC");
            comboBox1.Items.Add("SE");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             String Num = maskedTextBox3.Text;
             listBox1.Items.Add(Num);
             maskedTextBox3.Text = null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            textBox8.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            listBox1.Items.Clear();

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cliente.ListarCliente(textBox8.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
           
        }

       
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClienteDao dao = new ClienteDao();
            dao.excluircliente(id);
            dataGridView1.DataSource = cliente.ListarCliente();
            dataGridView1.Columns[0].Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            listBox1.Items.Clear();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        //gerar Relatorio
        private void button6_Click(object sender, EventArgs e)
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
            catch (Exception ex) {
                MessageBox.Show("Erro"+ex,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void printDocument1_BeginPrint(Object sender, EventArgs e)
        {
            conexão con = new conexão();
            con.conectar();
            SqlCommand cmd = new SqlCommand( "SELECT nomeCliente,cpfCliente,rgCliente,logradouroCliente ,numCliente ,compCliente ,bairroCliente ,cepCliente ,cidadeCliente ,ufCliente from tbCliente",con.con);
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
            Pen Risco = new Pen(Color.Black,1);

            //Define as fontes
            Font FonteNegrito = new Font("Arial",9,FontStyle.Bold);
            Font FonteTitulo = new Font("Arial",15,FontStyle.Bold);
            Font FonteSubtitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco,e.MarginBounds.Left,60,e.MarginBounds.Right,60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            //Titulo 
            e.Graphics.DrawString("RELATORIO CLIENTE ",FonteTitulo,Brushes.Black,e.MarginBounds.Left+10,80,new StringFormat());
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
            while ((LinhaAtual < linhasPorPagina && Leitor.Read())) {
                //Contem os dados do DataReader
                String nomeCliente = Leitor.GetString(0);
                String cpfCliente = Leitor.GetString(1);
                String rgCliente = Leitor.GetString(2);
                String logradouroCliente = Leitor.GetString(3);
                String numCliente = Leitor.GetString(4);
                String compCliente = Leitor.GetString(5);
                String bairroCliente = Leitor.GetString(6);
                String cepCliente = Leitor.GetString(7);
                String cidadeCliente = Leitor.GetString(8);
                String ufCliente = Leitor.GetString(9);
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

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            comboBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            maskedTextBox3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox8.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }  
}
