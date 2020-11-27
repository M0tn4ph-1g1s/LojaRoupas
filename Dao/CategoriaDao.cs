using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace LojaRoupas.Dao
{
    class CategoriaDao
    {
        conexão con = new conexão();
        public void editarCategoria(int id ,String desc) {
            con.conectar();
            string str = "UPDATE tbCategoria SET  = '" + desc + "' WHERE codCategoria = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
        }
        public void excluirCategria(int id) {
            con.conectar();
            string str2 = "DELETE FROM tbproduto WHERE codCategoria = " + id;
            SqlCommand cmd = new SqlCommand(str2, con.con);
            int qtde = cmd.ExecuteNonQuery();

            string str = "DELETE FROM tbCategoria WHERE codCategoria = " + id;
            SqlCommand cmd2 = new SqlCommand(str, con.con);
            int qtde2 = cmd2.ExecuteNonQuery();
        }
    }
}
