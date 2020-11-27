using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LojaRoupas.Dao;
using LojaRoupas.Control;

namespace LojaRoupas.Model
{
    class classProduto
    {
        private int idProduto;
        conexão con = new conexão();
        public int IdProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }

        private string nomeProduto;

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        private double precoProduto;

        public double PrecoProduto
        {
            get { return precoProduto; }
            set { precoProduto = value; }
        }

        private int codCategoria;

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        private int codFornecedor;

        public int CodFornecedor
        {
            get { return codFornecedor; }
            set { codFornecedor = value; }
        }

        private int qtdeEstoque;

        public int QtdeEstoque
        {
            get { return qtdeEstoque; }
            set { qtdeEstoque = value; }
        }

        public DataTable ListarProduto()
        {
            string str = "select * " +
                      "from tbProduto";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarProduto(String nome)
        {
            string str = "select * " +
                          "from tbProduto " +
                         "where nomeProduto like '" + nome + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;


        }

        public DataTable ListarProdutoCaixa(String nome)
        {
            string str = "select nomeProduto, precoProduto, qtdeEstoque " +
                          "from tbProduto " +
                         "where nomeProduto like '" + nome + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;


        }

        public void cadastrarpro(String nomeProduto, double precoProduto, int codCategoria, int codFornecedor, int qtd)
        {
            string str = "INSERT INTO tbProduto(nomeProduto, precoProduto, codCategoria, codFornecedor, qtdeEstoque)"
                + "VALUES ('" + nomeProduto + "', '" + precoProduto + "', '" + codCategoria + "', '" + codFornecedor + "', '" + qtd + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void excluirproduto(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbProduto WHERE codProduto = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void editarProduto(int id, String nomeProduto, double precoProduto, int codCategoria, int codFornecedor, int qtd)
        {
            con.conectar();

            string str = "UPDATE tbProduto  SET nomeProduto = '" + nomeProduto + "' WHERE codProduto = " + id;
            string str2 = "UPDATE tbProduto SET precoProduto =  '" + precoProduto + "' WHERE codProduto = " + id;
            string str3 = "UPDATE tbProduto SET codCategoria =  '" + codCategoria + "' WHERE codProduto = " + id;
            string str4 = "UPDATE tbProduto SET codFornecedor =  '" + codFornecedor + "' WHERE codProduto = " + id;
            string str5 = "UPDATE tbProduto SET qtdeEstoque ='" + qtd + "' WHERE codProduto = " + id;

            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(str2, con.con);
            int qtde2 = cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand(str3, con.con);
            int qtde3 = cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand(str4, con.con);
            int qtde4 = cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand(str5, con.con);
            int qtde5 = cmd5.ExecuteNonQuery();
            con.desconectar();
        }

        public int pegarQuantidade(string nome)
        {
            SqlCommand cmd = new SqlCommand("select qtdeEstoque from tbProduto " +
                "where nomeProduto LIKE '" + nome + "'", con.con);
            con.conectar();
            int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;


        }

        public void editarQuantidade(int qtde, String nomeProduto)
        {
            con.conectar();

            string str = "UPDATE tbProduto  SET qtdeEstoque = '" + qtde + "' WHERE nomeProduto =  '"+ nomeProduto+"'";
            

            SqlCommand cmd = new SqlCommand(str, con.con);
            int estoque = cmd.ExecuteNonQuery();

            
            con.desconectar();
        }


        public int pegarProduto(string nomeProduto)
        {
            SqlCommand cmd = new SqlCommand("select codProduto from tbProduto " +
                "where nomeProduto LIKE '" + nomeProduto + "' ", con.con);
            con.conectar();
            int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;


        }
    }
}
