using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace LojaRoupas.Control
{
    class ProdutoDao
    {
        conexão con = new conexão();
        public void editarProduto(int id, string nomeProduto, string precoProduto, string qtdeEstoque, string categoria, string fornecedor)
        {
            con.conectar();
            double valorDouble = Convert.ToDouble(precoProduto);
            int valor = Convert.ToInt32(qtdeEstoque);
            string codCategoria = "SELECT  codCategoria  from tbCategoria  where descCategoria  = '"+categoria+"'";
            string codFornecedor = "SELECT codFornecedor from tbFornecedor where nomeFornecedor = '"+fornecedor+"'";
            SqlCommand cmd1 = new SqlCommand(codCategoria, con.con);
            int qtde = cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(codFornecedor, con.con);
            int qtde2 = cmd2.ExecuteNonQuery();

            string str = "UPDATE tbProduto  SET nomeProduto ='" + nomeProduto + "' WHERE codProduto = " + id;
            string str2 = "UPDATE tbProduto SET precoProduto ='" + valorDouble + "' WHERE codProduto = " + id;
            string str3 = "UPDATE tbProduto SET qtdeEstoque ='" + valor + "' WHERE codProduto = " + id;
            
            SqlCommand cmd3 = new SqlCommand(str, con.con);
            int qtde3 = cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand(str2, con.con);
            int qtde4 = cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand(str3, con.con);
            int qtde5 = cmd5.ExecuteNonQuery();

            

        }
        public void excluirproduto(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbProduto WHERE codProduto = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
        }
        public void cadastrarpro(String nomeProduto, int precoProduto, int codCategoria, int codFornecedor, int qtd)
        {
            string str = "INSERT INTO tbProduto(nomeProduto, precoProduto, codCategoria, codFornecedor, qtdeEstoque)"
                + "VALUES ('" + nomeProduto + "', '" + precoProduto + "', '" + codCategoria + "', '" + codFornecedor + "', '" + qtd + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
        }

        
    }
}
