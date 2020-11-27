using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.Model
{
    class classCategoria
    {
        private int idCategoria;
        conexão con = new conexão();
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        private string descCategoria;

        public string DescCategoria
        {
            get { return descCategoria; }
            set { descCategoria = value; }
        }


        public void cadastrarCategoria(String descCategoria)
        {
            string str = "INSERT INTO tbCategoria(descCategoria)"
                + "VALUES ('" + descCategoria + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
        }

        public DataTable ListarCategoria()
        {
            string str = "select * " +
                      "from tbCategoria";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarCategoria(String categoria)
        {
            string str = "select * " +
                          "from tbCategoria " +
                         "where descCategoria like '" + categoria + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;


        }

        public String[] carregarCategoria()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codCategoria) FROM tbCategoria", con.con);
            con.conectar();
            int qtde = Convert.ToInt32(cmd.ExecuteScalar());
            String[] listaCategoria = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT descCategoria FROM tbCategoria", con.con);
            var siglas = cmd2.ExecuteReader();

            int i = 0;
            while (siglas.Read())
            {
                listaCategoria[i] = siglas["descCategoria"].ToString();
                i++;
            }

            con.desconectar();
            return listaCategoria;
        }
        public int pegarCodigoCategoria(string nome)
        {
            SqlCommand cmd = new SqlCommand("select codCategoria from tbCategoria " +
                "where descCategoria LIKE '" + nome + "'", con.con);
            con.conectar();
            int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;
            

        }

        public void excluirCategoria(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbCategoria WHERE codCategoria = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void editarCategoriao(int id, String descCategoria)
        {
            con.conectar();
            string str = "UPDATE tbCategoria  SET descCategoria = '" + descCategoria + "' WHERE codCategoria = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();

            
        }

    }
}