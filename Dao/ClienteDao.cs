using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaRoupas.Model;
using System.Data.SqlClient;
namespace LojaRoupas.Dao
{
    class ClienteDao
    {
        conexão con = new conexão();
        public void editarcliente(int id,String nomeCliente,String cpfCliente,String rgCliente,String logradouroCliente,String numCliente,String compCliente,String bairroCliente,String cepCliente,String cidadeCliente)
        {
            con.conectar();

            string str  = "UPDATE tbcliente SET nomeCliente = '" + nomeCliente+ "' WHERE codCliente = " + id;
            string str2 = "UPDATE tbcliente SET cpfCliente =  '" + cpfCliente + "' WHERE codCliente = " + id;
            string str3 = "UPDATE tbcliente SET rgCliente ='" + rgCliente + "' WHERE codCliente = " + id;
            string str4 = "UPDATE tbcliente SET logradouroCliente = '" + logradouroCliente + "' WHERE codCliente = " + id;
            string str5 = "UPDATE tbcliente SET numCliente ='" + numCliente + "' WHERE codCliente = " + id;
            string str6 = "UPDATE tbcliente SET compCliente= '" + compCliente + "' WHERE codCliente = " + id;
            string str7 = "UPDATE tbcliente SET bairroCliente= '" + bairroCliente + "' WHERE codCliente = " + id;
            string str8 = "UPDATE tbcliente SET cepCliente= '" + cepCliente + "' WHERE codCliente = " + id;
            string str9 = "UPDATE tbcliente SET cidadeCliente= '" + cidadeCliente + "' WHERE codCliente = " + id;


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

            SqlCommand cmd6 = new SqlCommand(str6, con.con);
            int qtde6 = cmd6.ExecuteNonQuery();

            SqlCommand cmd7 = new SqlCommand(str7, con.con);
            int qtde7 = cmd7.ExecuteNonQuery();

            SqlCommand cmd8 = new SqlCommand(str8, con.con);
            int qtde8 = cmd8.ExecuteNonQuery();

            SqlCommand cmd9 = new SqlCommand(str9, con.con);
            int qtde9 = cmd9.ExecuteNonQuery();
            
        }
        public void excluircliente(int id) {
            con.conectar();
            string str = "DELETE FROM tbcliente WHERE codCliente = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();

        }

    }
}
