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

namespace LojaRoupas.Model
{
    class classVenda
    {
        private int idVenda;
        conexão con = new conexão();
        public int IdVenda
        {
            get { return idVenda; }
            set { idVenda = value; }
        }

        private DateTime dataVenda;

        public DateTime DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }

        private double valorTotalVenda;

        public double ValorTotalVenda
        {
            get { return valorTotalVenda; }
            set { valorTotalVenda = value; }
        }

        private int codUsuario;

        public int CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; }
        }

        private int codCliente;

        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }

        public DataTable ListarVenda()
        {
            string str = "select * " +
                      "from tbVenda";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarVendaCaixaUsuario(int codUsuario)
        {
            string str = "select * " +
                      "from tbVenda where codUsuario = '" + codUsuario + "' ";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public void cadastrarVenda(String dataVenda, double valorTotalVenda, int codUsuario, int codCliente)
        {
            string str = "insert into tbVenda(dataVenda, valorTotalVenda, codUsuario, codCliente)"
                + "VALUES ('" + dataVenda + "', '" + valorTotalVenda + "', '" + codUsuario + "', '" + codCliente + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public int pegarCodVenda()
        {
            SqlCommand cmd = new SqlCommand("select Max(codVenda) from tbVenda ", con.con);
            con.conectar();
            int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;


        }

        public DataTable ListarVendaCaixa(int codCliente)
        {
            string str = "select * " +
                      "from tbVenda where codCliente = '" + codCliente + "' ";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarVendaData1(string dataVenda)
        {
            string str = "select * " +
                      "from tbVenda where dataVenda = '" + dataVenda + "' ";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }


        public DataTable ListarVendaData2(string dataVenda1, string dataVenda2)
        {
            string str = "select * " +
                      "from tbVenda where dataVenda BETWEEN '" + dataVenda1 + "' and '"+ dataVenda2 + "' ";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

    }
}
