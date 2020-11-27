using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaRoupas.Model;
using LojaRoupas.obj;


namespace LojaRoupas
{
    public partial class Caixa : Form
    {

        classCliente cliente = new classCliente();
        classProduto produto = new classProduto();
        classVenda venda = new classVenda();
        classUsuario Users = new classUsuario();
        classFormaPagamento pag = new classFormaPagamento();
        Boolean parcelado = false;
        double ValorTotal = 0;
        double ValorPago = 0;
        double troco = 0;
        string nomeCliente = null;
        string cpfCliente = null;
        string usuario;
        int parcela = 0;
        private void Usuario_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cliente.ListarClienteCaixa(textBox1.Text);
            dataGridView2.DataSource = produto.ListarProdutoCaixa(textBox2.Text);
            int codUsuario = Users.pegarCodigoUsuario(usuario);
            dataGridView5.DataSource = venda.ListarVendaCaixaUsuario(codUsuario);
            String[] listaPag = pag.carregarDescFormaPagamento();
            foreach (string formaPag in listaPag)
                comboBox1.Items.Add(formaPag);

        }
     

        public void desmarcar() {
            button1.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            button2.Enabled = false;
            ValorTotal = 0;
            ValorPago = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            label7.Text = "                   ";
            label8.Text = "                   ";
            label13.Text = "            ";
            label14.Text = "            ";
            label12.Text = "            ";
            label11.Visible = false;
            label12.Visible = false;
            label18.Visible = false;
            textBox5.Visible = false;
            int linhas = dataGridView3.Rows.Count;
            for (int i = 0; i < linhas; i++)
            {
                string Produto = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                int qtde = Convert.ToInt16(dataGridView3.CurrentRow.Cells[1].Value);
                int qtdeProduto = produto.pegarQuantidade(Produto);
                int novoEstoque = qtdeProduto + qtde;
                produto.editarQuantidade(novoEstoque, Produto);
                dataGridView2.DataSource = produto.ListarProdutoCaixa(textBox2.Text);

                int linha = dataGridView3.CurrentRow.Index;
                dataGridView3.Rows.RemoveAt(linha);

            }

             dataGridView3.Rows.Clear();
             dataGridView4.Rows.Clear();
             parcelado = false;
             parcela = 0;
             button9.Visible = false;
             button10.Visible = false;

            

        
        }



        public void desmarcar1()
        {
            button1.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            button2.Enabled = false;
            ValorTotal = 0;
            ValorPago = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            label7.Text = "                   ";
            label8.Text = "                   ";
            label13.Text = "            ";
            label14.Text = "            ";
            label12.Text = "            ";
            label11.Visible = false;
            label12.Visible = false;
            label18.Visible = false;
            textBox5.Visible = false;
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            parcelado = false;
            parcela = 0;
            button9.Visible = false;
            button10.Visible = false;




        }

        public Caixa(String Usuario)
        {
            InitializeComponent();
            usuario = Usuario;
            user.Text = usuario;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente f = new Cliente();
            f.ShowDialog();
        }

      

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.ShowDialog();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itmVenda vendas = new itmVenda();
            vendas.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios f = new Usuarios();
            f.ShowDialog();
        }

        

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria f = new Categoria();
            f.ShowDialog();
        }

        private void formaPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaPagamento f = new FormaPagamento();
            f.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            desmarcar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cliente.ListarClienteCaixa(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = produto.ListarProdutoCaixa(textBox2.Text);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

           
            label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label8.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            nomeCliente = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cpfCliente = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int linhas = dataGridView3.Rows.Count;
            if (ValorTotal <= 0)
            {
                MessageBox.Show("Selecione um Cliente  para prosseguir");


            }
            else if (nomeCliente == null || cpfCliente == null) {
                MessageBox.Show("Selecione um Cliente  para prosseguir");


            }
            else if (linhas <= 0)
            {
                MessageBox.Show("Tenha ao menos um produto no caixa para realizar a compra");


            }
            else if (ValorPago > 0)
            {
                MessageBox.Show("Tenha pago todos os produtos antes de prosseguir");


            }
            else {
                string data = DateTime.Now.ToShortDateString();
                int Cliente = cliente.pegarCodCliente(nomeCliente, cpfCliente);
                int codUsuario = Users.pegarCodigoUsuario(usuario);

                venda.cadastrarVenda(data, ValorTotal, codUsuario, Cliente);
                int codVenda = venda.pegarCodVenda();
              
                for (int i = 0; i < linhas; i++)
                 {
                     string Produto = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                     int qtde = Convert.ToInt16(dataGridView3.CurrentRow.Cells[1].Value);
                     double subTotal = Convert.ToDouble(dataGridView3.CurrentRow.Cells[2].Value);
                     int produtoInt = produto.pegarProduto(Produto);
                     classItemVenda itemVenda = new classItemVenda();
                     itemVenda.cadastrarItemVenda(codVenda, produtoInt, qtde, subTotal);
                     int linha = dataGridView3.CurrentRow.Index;
                     dataGridView3.Rows.RemoveAt(linha);
                 
                 
                 }
                dataGridView5.DataSource = venda.ListarVendaCaixa(codUsuario);
             
                if (parcelado == true) {

                    int subParcela = Convert.ToInt16(textBox5.Text);
                    parcela = subParcela;
                    if (parcela <= 1)
                    {
                        MessageBox.Show("Digite um numero de parcelas maior que 1");
                       
                    }
                    else
                    {
                        double valorParcela = ValorTotal;
                        int linhasPagamento = dataGridView4.RowCount;
                        
                        double subParcelaDouble = Convert.ToDouble(textBox5.Text);
                        valorParcela = valorParcela  / subParcelaDouble ;
                        String ValorParcela = valorParcela.ToString("C");
                        valorParcela = Math.Round(valorParcela, 2);
                        for (int i = 1; i <= Convert.ToInt16(subParcelaDouble); i++)
                        {
                            classParcela Parcela = new classParcela();
                            int pagi = pag.pesquisarCodFormaPagamento("Credito");
                            Parcela.cadastrarParcela(codVenda, pagi, valorParcela);

                        }
                    }

                
                
                }
                    desmarcar1();
            
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            label7.Text = "                   ";
            label8.Text = "                   ";
            nomeCliente = null;
           cpfCliente = null;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (textBox3.Text != "" )
            {
                int qtde = Convert.ToInt16(textBox3.Text);
                if (qtde > 0)
                {
                    string Produto = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    string preco = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    double precos = Convert.ToDouble(preco);

                    precos = precos * qtde;

                    int qtdeProduto = produto.pegarQuantidade(Produto);
                    if (qtde <= qtdeProduto)
                    {
                        string precosString = Convert.ToString(precos);
                        string qtdeString = Convert.ToString(qtde);
                        string[] caixa = { Produto, qtdeString, precosString };
                        dataGridView3.Rows.Add(caixa);
                        int novoEstoque = qtdeProduto - qtde;
                        produto.editarQuantidade(novoEstoque, Produto);
                        dataGridView2.DataSource = produto.ListarProdutoCaixa(textBox2.Text);

                        ValorTotal = ValorTotal + precos;
                        ValorPago = ValorPago + precos;
                        label13.Text = Convert.ToString(ValorTotal);
                        if (ValorPago >= 0)
                        {
                            label14.Text = Convert.ToString(ValorPago);
                        }
                        else
                        {
                            label14.Text = "0";
                        }



                    }
                    else if (qtde > qtdeProduto)
                    {

                        MessageBox.Show("Quantidade de produtos em estoque é insuficiente para esse pedido");
                    }

                }else if(qtde<= 0){
                    MessageBox.Show("Valor Invalido");
                
                }
            }
            else
            {
                MessageBox.Show("Para Adicionar um Produto deve definir uma Quantidade");
            }
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

       

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string preco = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            
            double precoDouble = Convert.ToDouble(preco);
           
            ValorTotal = ValorTotal - precoDouble;
            ValorPago = ValorPago - precoDouble;
            label13.Text = Convert.ToString(ValorTotal);
            if (ValorPago >= 0)
            {
                label14.Text = Convert.ToString(ValorPago);
            }
            else {
                label14.Text = "0";
            }

            string Produto = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            int qtde = Convert.ToInt16(dataGridView3.CurrentRow.Cells[1].Value);
            int qtdeProduto = produto.pegarQuantidade(Produto);
            int novoEstoque = qtdeProduto + qtde;
            produto.editarQuantidade(novoEstoque, Produto);
            dataGridView2.DataSource = produto.ListarProdutoCaixa(textBox2.Text);

            int linha = dataGridView3.CurrentRow.Index;
            dataGridView3.Rows.RemoveAt(linha);

        }

        private void button7_Click(object sender, EventArgs e)
        {
       
            
            double valor = Convert.ToInt16(textBox4.Text);
            if (ValorTotal > 0)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Selecione uma forma de pagamento para proseguir");

                }
                else if (textBox4.Text == "" || valor <= 0)
                {

                    MessageBox.Show("Digite um valor maior que 0 para prosseguir");
                }
                else
                {
                    string formPagamento = comboBox1.Text;
                    if (formPagamento == "Dinheiro")
                    {
                        string ValorGrid = Convert.ToString(valor);

                        if (ValorPago < valor)
                        {
                            troco = valor - ValorPago;
                            label12.Text = Convert.ToString(troco);
                            ValorPago = ValorPago - valor;
                            label14.Text = "0";
                            string[] pagamento = { formPagamento, ValorGrid };
                            dataGridView4.Rows.Add(pagamento);
                            label11.Visible = true;
                            label12.Visible = true;
                            if (ValorPago <= 0) {
                                button6.Visible = true;
                                button9.Visible = true;
                                button10.Visible = true;
                            }


                        }
                        else
                        {
                            ValorPago = ValorPago - valor;
                            label14.Text = Convert.ToString(ValorPago);
                            string[] pagamento = { formPagamento, ValorGrid };
                            dataGridView4.Rows.Add(pagamento);
                            if (ValorPago == 0)
                            {
                                button6.Visible = true;
                                button9.Visible = true;
                                button10.Visible = true;
                            }
                        }
                    }
                    else {
                        if (valor > ValorPago)
                        {
                            MessageBox.Show("Você não pode pagar mais doque o valor a pagar ao menos que pague em dinheiro");
                        }
                        else{
                            string ValorGrid = Convert.ToString(valor);
                            ValorPago = ValorPago - valor;
                            label14.Text = Convert.ToString(ValorPago);
                            string[] pagamento = { formPagamento, ValorGrid };
                            dataGridView4.Rows.Add(pagamento);
                            if (ValorPago == 0)
                            {
                                button6.Visible = true;
                                button9.Visible = true;
                                button10.Visible = true;
                            }
                        }
                    
                    
                    
                    }


                }
            }
            else {
                MessageBox.Show("Tenha ao menos um produto no caixa para prosseguir");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
             label18.Visible = true;
             textBox5.Visible = true;
             parcelado = true;
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            String tipo = Convert.ToString(dataGridView4.CurrentRow.Cells[0].Value);
            if(tipo != "Dinheiro"){
            double valor =  Convert.ToDouble(dataGridView4.CurrentRow.Cells[1].Value);
            ValorPago = ValorPago + valor;
            troco = troco - valor;
            if (troco <= 0) {
                troco = 0;
                button6.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label12.Text = "            ";
                button9.Visible = false;
                button10.Visible = false;
            
            }
            int linha = dataGridView3.CurrentRow.Index;
            dataGridView4.Rows.RemoveAt(linha);
            if (ValorPago > 0) {
                label12.Text = "            ";
                button6.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                
            }
            label14.Text = Convert.ToString(ValorPago);

            }
            else if (tipo == "Dinheiro") {
                double valor = Convert.ToDouble(dataGridView4.CurrentRow.Cells[1].Value);
                ValorPago = ValorPago + valor;
                troco = troco - valor;
                if (troco <= 0)
                {
                    troco = 0;
                    label12.Text = "            ";
                    button6.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;

                }

                if (ValorPago > 0) {
                    label12.Text = "            ";
                    button6.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    button9.Visible = false;
                 
                
                }
                int linha = dataGridView4.CurrentRow.Index;
                dataGridView4.Rows.RemoveAt(linha);
                if (ValorPago > 0)
                {
                    label12.Text = "            ";
                    button6.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    button6.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
              
                }
                label14.Text = Convert.ToString(ValorPago);
            
            
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            label18.Visible = false;
            textBox5.Visible = false;
            parcelado = false;
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendas f = new Vendas();
            f.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupTela b = new BackupTela();
            b.ShowDialog();
        }






    }
}
