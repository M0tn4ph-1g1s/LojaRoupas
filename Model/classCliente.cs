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
    class classCliente
    {
        public int idCliente;
        conexão con = new conexão();
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private string nomeCliente;

        public string NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        private string cpfCliente;

        public string CpfCliente
        {
            get { return cpfCliente; }
            set { cpfCliente = value; }
        }

        private string rgCliente;

        public string RgCliente
        {
            get { return rgCliente; }
            set { rgCliente = value; }
        }

        private string logradouroCliente;

        public string LogradouroCliente
        {
            get { return logradouroCliente; }
            set { logradouroCliente = value; }
        }

        private string numCliente;

        public string NumCliente
        {
            get { return numCliente; }
            set { numCliente = value; }
        }

        private string compCliente;

        public string CompCliente
        {
            get { return compCliente; }
            set { compCliente = value; }
        }

        private string bairroCliente;

        public string BairroCliente
        {
            get { return bairroCliente; }
            set { bairroCliente = value; }
        }


        private string cepCliente;

        public string CepCliente
        {
            get { return cepCliente; }
            set { cepCliente = value; }
        }

        private string cidadeCliente;

        public string CidadeCliente
        {
            get { return cidadeCliente; }
            set { cidadeCliente = value; }
        }

        private string ufCliente;

        public string UfCliente
        {
            get { return ufCliente; }
            set { ufCliente = value; }
        }

        public List<String> listFones = new List<String>();

        public List<String> ListFones
        {
            get { return listFones; }
            set { listFones = value; }
        }
        public void cadastrarCliente(String nomeCliente, String cpfCliente, String rgCliente, String logradouroCliente, String numCliente, String compCliente, String bairroCliente, String  cepCliente, String cidadeCliente, String ufCliente, List<String>numTelefone){
              string str = "INSERT INTO tbCliente(nomeCliente, cpfCliente, rgCliente, logradouroCliente, numCliente, compCliente, bairroCliente, cepCliente, cidadeCliente, ufCliente)" 
                  + "VALUES ('"+nomeCliente+"', '"+cpfCliente+"', '"+rgCliente+"', '"+logradouroCliente+"', '"+numCliente+"', '"+compCliente+"', '"+bairroCliente+"', '"+cepCliente+"', '"+cidadeCliente+"', '"+ ufCliente+"')";
              SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            classCliente Cliente = new classCliente();
            int qtde = cmd.ExecuteNonQuery();
            str = "SELECT MAX(codCliente) FROM tbcliente";
            SqlCommand cmdFone = new SqlCommand(str, con.con);
            Cliente.idCliente = Convert.ToInt16(cmdFone.ExecuteScalar());
            int qtd2 = 0;
            for (int i = 0; i < numTelefone.Count; i++)
            {
                MessageBox.Show(""+numTelefone.Count);
                MessageBox.Show(numTelefone[i]);
                SqlCommand cmd3 = new SqlCommand("INSERT INTO tbFoneCliente(foneCliente,codCliente) VALUES ('" + numTelefone[i] + "','" + Cliente.idCliente + "')", con.con);
                qtd2 = cmd3.ExecuteNonQuery();
            }

            con.desconectar();
        }
        public DataTable ListarCliente()
        {
            string str = "select * " +
                      "from tbCliente";
         SqlCommand cmd = new SqlCommand(str, con.con);
         con.conectar();
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         sda.Fill(dt);
         con.desconectar();
         return dt;
        }

        public DataTable ListarCliente(String nome){
            string str = "select * " +
                          "from tbCliente " +
                         "where nomeCliente like '" + nome + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        
        
        }

        public DataTable ListarClienteCaixa(String nome)
        {
            string str = "select nomeCliente, cpfCliente " +
                          "from tbCliente " +
                         "where nomeCliente like '" + nome + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;


        }

        public int pegarCodCliente(string nomeCliente, string cpfCliente)
        {
            SqlCommand cmd = new SqlCommand("select codCliente from tbCliente " +
                "where nomeCliente LIKE '" + nomeCliente + "' and  cpfCliente LIKE '" + cpfCliente + "'", con.con);
            con.conectar();
            int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;


        }


    }
}
