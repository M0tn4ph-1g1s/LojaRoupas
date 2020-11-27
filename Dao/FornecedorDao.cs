using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace LojaRoupas.Dao
{
    class FornecedorDao
    {
        conexão con = new conexão();
        public void editarFornecedor(int id, String nomeFornecedor, String contatoFornecedor, String foneForcedor)
        {
            con.conectar();
            string str = "UPDATE tbFornecedor  SET nomeFornecedor = '" + nomeFornecedor + "' WHERE codFornecedor = " + id;
            string str2 = "UPDATE tbFornecedor SET contatoFornecedor =  '" + contatoFornecedor + "' WHERE codFornecedor = " + id;
            string str3 = "UPDATE tbFornecedor SET foneForcedor ='" + foneForcedor + "' WHERE codFornecedor = " + id;

            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(str2, con.con);
            int qtde2 = cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand(str3, con.con);
            int qtde3 = cmd3.ExecuteNonQuery();
        }
        public void excluirFornecedor(int id)
        {
            con.conectar();

            string str2 = "DELETE FROM tbproduto WHERE codFornecedor = " + id;
            SqlCommand cmd = new SqlCommand(str2, con.con);
            int qtde = cmd.ExecuteNonQuery();
            string str = "DELETE FROM tbFornecedor WHERE codFornecedor = " + id;
            SqlCommand cmd2 = new SqlCommand(str, con.con);
            int qtde2 = cmd2.ExecuteNonQuery();
            

        }
    }
}
