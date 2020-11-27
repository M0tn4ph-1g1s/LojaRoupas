using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.Model
{
    class ClassItemVendaCaixa
    {
       
        conexão con = new conexão();
        public string produto;
        public int qtde;
        public double subTotal;




        public double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public string Produto
        {
            get { return produto; }
            set { produto = value; }
        }


        public int Quantidade
        {
            get { return qtde; }
            set { qtde = value; }
        }


    }
}
