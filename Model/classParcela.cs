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
    class classParcela
    {
        private int idParcela;
        conexão con = new conexão();
        public int IdParcela
        {
            get { return idParcela; }
            set { idParcela = value; }
        }

        private int codVenda;

        public int CodVenda
        {
            get { return codVenda; }
            set { codVenda = value; }
        }

        private int codFormaPagto;

        public int CodFormaPagto
        {
            get { return codFormaPagto; }
            set { codFormaPagto = value; }
        }

        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public void cadastrarParcela(int codVenda, int codFormaPagto,  double valor)
        {
            string str = "INSERT INTO tbParcela(codVenda, codFormaPagto, valor)"
                + "VALUES ('" + codVenda + "', '" + codFormaPagto + "', '" + valor + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
            }
    }
}
