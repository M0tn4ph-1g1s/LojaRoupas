using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.Model
{
    class classFormaPagamento
    {
        private int idFormaPagamento;
        conexão con = new conexão();
        public int IdFormaPagamento
        {
            get { return idFormaPagamento; }
            set { idFormaPagamento = value; }
        }

        private string descFormaPagamento;

        public string DescFormaPagamento
        {
            get { return descFormaPagamento; }
            set { descFormaPagamento = value; }
        }

        public void cadastrarFormaPagamento(String descFormaPagamento)
        {
            string str = "INSERT INTO tbFormaPagto(descFormaPagto)"
                + "VALUES ('" + descFormaPagamento + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
        }

        public DataTable ListarFormaDePagamento()
        {
            string str = "select * " +
                      "from tbFormaPagto";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarFormaDePagamento(String desc)
        {
            string str = "select * " +
                          "from tbFormaPagto " +
                         "where descFormaPagto like '" + desc + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;

        }

        public String[] carregarDescFormaPagamento()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codFormaPagto) FROM tbFormaPagto", con.con);
            con.conectar();
            int qtde = Convert.ToInt32(cmd.ExecuteScalar());
            String[] listaFormaPagamento = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT descFormaPagto FROM tbFormaPagto", con.con);
            var siglas = cmd2.ExecuteReader();

            int i = 0;
            while (siglas.Read())
            {
                listaFormaPagamento[i] = siglas["descFormaPagto"].ToString();
                i++;
            }

            con.desconectar();
            return listaFormaPagamento;
        }



        public int pesquisarDescFormaPagamento(string pag)
        {
            SqlCommand cmd = new SqlCommand("SELECT descFormaPagto FROM tbFormaPagto WHERE descFormaPagto = '" + pag + "'", con.con);
            con.conectar();
            int codUf = Convert.ToInt32(cmd.ExecuteScalar());
            con.desconectar();
            return codUf;
        }

        public void excluirFormaPagto(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbFormaPagto WHERE codFormaPagto = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void editarFormaPagto(int id, String descFormaPagto)
        {
            con.conectar();
            string str = "UPDATE tbFormaPagto  SET descFormaPagto = '" + descFormaPagto + "' WHERE codFormaPagto = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();


        }

        public int pesquisarCodFormaPagamento(string pag)
        {
            SqlCommand cmd = new SqlCommand("SELECT codFormaPagto FROM tbFormaPagto WHERE descFormaPagto = '" + pag + "'", con.con);
            con.conectar();
            int codUf = Convert.ToInt32(cmd.ExecuteScalar());
            con.desconectar();
            return codUf;
        }

    }
}