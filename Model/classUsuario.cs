using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.Model
{
    class classUsuario
    {
        private int idUsuario;
        conexão con = new conexão();
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private string nomeUsuario;

        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }

        private string loginUsuario;

        public string LoginUsuario
        {
            get { return loginUsuario; }
            set { loginUsuario = value; }
        }

        private string senhaUsuario;

        public string SenhaUsuario
        {
            get { return senhaUsuario; }
            set { senhaUsuario = value; }
        }
        public void cadastrarUsuario(String nomeUsuario, String loginUsuario, String senhaUsuario)
        {
            string str = "INSERT INTO tbUsuario(nomeUsuario, loginUsuario, senhaUsuario)"
                + "VALUES ('" + nomeUsuario + "', '" + loginUsuario + "', '" + senhaUsuario + "')";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();

            int qtde = cmd.ExecuteNonQuery();
        }


        public DataTable ListarUsuario()
        {
            string str = "select * " +
                      "from tbUsuario";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;
        }

        public DataTable ListarUsuario(String nome)
        {
            string str = "select * " +
                          "from tbUsuario " +
                         "where nomeUsuario like '" + nome + "%'";
            SqlCommand cmd = new SqlCommand(str, con.con);
            con.conectar();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.desconectar();
            return dt;


        }

        public void excluirUsuario(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbUsuario WHERE codUsuario = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void editarUsuario(int id, String nomeUsuario, String loginUsuario, String senhaUsuario)
        {
            con.conectar();

            string str = "UPDATE tbUsuario  SET nomeUsuario = '" + nomeUsuario + "' WHERE codUsuario = " + id;
            string str2 = "UPDATE tbUsuario SET loginUsuario =  '" + loginUsuario + "' WHERE codUsuario = " + id;
            string str3 = "UPDATE tbUsuario SET senhaUsuario ='" + senhaUsuario + "' WHERE codUsuario = " + id;

            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(str2, con.con);
            int qtde2 = cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand(str3, con.con);
            int qtde3 = cmd3.ExecuteNonQuery();
            con.desconectar();
        }


        public String[] carregarLogin()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codUsuario) FROM tbUsuario", con.con);
            con.conectar();
            int qtde = Convert.ToInt32(cmd.ExecuteScalar());
            String[] listaLogin = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT loginUsuario FROM tbUsuario", con.con);
            var siglas = cmd2.ExecuteReader();

            int i = 0;
            while (siglas.Read())
            {
                listaLogin[i] = siglas["loginUsuario"].ToString();
                i++;
            }

            con.desconectar();
            return listaLogin;
        }


        public String[] carregarSenha()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codUsuario) FROM tbUsuario", con.con);
            con.conectar();
            int qtde = Convert.ToInt32(cmd.ExecuteScalar());
            String[] listaSenha = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT senhaUsuario FROM tbUsuario", con.con);
            var siglas = cmd2.ExecuteReader();

            int i = 0;
            while (siglas.Read())
            {
                listaSenha[i] = siglas["senhaUsuario"].ToString();
                i++;
            }

            con.desconectar();
            return listaSenha;
        }

        public string pegarUsuario(string login, string senha)
        {
            SqlCommand cmd = new SqlCommand("select nomeUsuario from tbUsuario " +
                "where loginUsuario LIKE '" + login + "' and  senhaUsuario LIKE '" + senha + "'", con.con);
            con.conectar();
            string cod = Convert.ToString(cmd.ExecuteScalar());
            con.desconectar();
            return cod;


        }

        

        public int pegarCodigoUsuario(string nomeUsuario)
        {
            SqlCommand cmd = new SqlCommand("select codUsuario from tbUsuario " +
                "where nomeUsuario LIKE '" + nomeUsuario + "'", con.con);
            con.conectar();
            int cod = Convert.ToInt16(cmd.ExecuteScalar());
            con.desconectar();
            return cod;


        }


    }
}
