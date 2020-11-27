using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.Model
{
    class classItemVenda
    {
        private int idItemVenda;
        conexão con = new conexão();
        public int IdItemVenda
        {
            get { return idItemVenda; }
            set { idItemVenda = value; }
        }

        private int codVenda;

        public int CodVenda
        {
            get { return codVenda; }
            set { codVenda = value; }
        }

        private int codProduto;

        public int CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        private int qtdeItem;

        public int QtdeItem
        {
            get { return qtdeItem; }
            set { qtdeItem = value; }
        }

        private double subTotal;

        public double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public DataTable ListarItemVenda()
        {
            string str = "select * " +
                      "from tbItemVenda";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarItemVenda(int cod)
        {
            string str = "select * " +
                          "from tbItemVenda " +
                         "where codVenda  = '" + cod + "'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;

        }

        public DataTable ListarItemVendaProduto(int cod)
        {
            string str = "select * " +
                          "from tbItemVenda " +
                         "where codProduto  = '" + cod + "'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;

        }


        public void excluirItemVenda(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbItemVenda WHERE codItemVenda = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }


        public void cadastrarItemVenda(int codVenda, int codProduto, int qtdeItem, double subTotal)
        {
            string str = "INSERT INTO tbItemVenda(codVenda, codProduto, qtdeItem, subTotal)"
                + "VALUES ('" + codVenda + "', '" + codProduto + "', '" + qtdeItem + "', '" + subTotal + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }


        
    }
}
