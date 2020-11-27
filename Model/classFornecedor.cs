using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
namespace LojaRoupas.Model
{
    class classFornecedor
    {
        private int idFornecedor;
        conexão con = new conexão();
        public int IdFornecedor
        {
            get { return idFornecedor; }
            set { idFornecedor = value; }
        }

        private string nomeFornecedor;

        public string NomeFornecedor
        {
            get { return nomeFornecedor; }
            set { nomeFornecedor = value; }
        }

        private string contatoFornecedor;

        public string ContatoFornecedor
        {
            get { return contatoFornecedor; }
            set { contatoFornecedor = value; }
        }

        private string foneForcedor;

        public string FoneForcedor
        {
            get { return foneForcedor; }
            set { foneForcedor = value; }
        }

        public void cadastrarFornecedor(String nomeFornecedor, String contatoFornecedor, String foneForcedor)
        {
            string str = "INSERT INTO tbFornecedor(nomeFornecedor, contatoFornecedor, foneForcedor)"
                + "VALUES ('" + nomeFornecedor + "', '" + contatoFornecedor + "', '" + foneForcedor + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
        }
        public DataTable preenchergrid() {
            string str = " select * " +
                          "from tbFornecedor";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }
        public DataTable preenchergrid(string nome)
        {
            string str = "select * from tbFornecedor " +
                         "where nomeFornecedor like '" + nome + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }
        public DataTable listarFornecedor()
        {
            return preenchergrid();
        }

        public DataTable listarFornecedorPesquisa(string nome)
        {
            return preenchergrid(nome);
        }

        public String[] carregarFornecedor()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codFornecedor) FROM tbFornecedor", con.con);
            con.conectar();
            int qtde = Convert.ToInt32(cmd.ExecuteScalar());
            String[] listaFornecedor = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT nomeFornecedor FROM tbFornecedor", con.con);
            var siglas = cmd2.ExecuteReader();

            int i = 0;
            while (siglas.Read())
            {
                listaFornecedor[i] = siglas["nomeFornecedor"].ToString();
                i++;
            }

            con.desconectar();
            return listaFornecedor;
        }

         public int pegarCodigoFornecedor (string nome){


             SqlCommand cmd = new SqlCommand("select codFornecedor from tbFornecedor " +
                "where nomeFornecedor LIKE '" + nome + "'", con.con);

             con.conectar();
             int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;
        
        }

         public void excluirFornecedor(int id)
         {
             con.conectar();
             string str = "DELETE FROM tbFornecedor WHERE codFornecedor = " + id;
             SqlCommand cmd = new SqlCommand(str, con.con);
             int qtde = cmd.ExecuteNonQuery();
             con.desconectar();
         }

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
             con.desconectar();
         }
    }
}
