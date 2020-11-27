using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace LojaRoupas.Dao
{
    class UsuarioDao
    {
        conexão con = new conexão();
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
        }
        public void excluirusuario(int id)
        {
            con.conectar();
            string str = "DELETE FROM tbUsuario WHERE codUsuario = " + id;
            SqlCommand cmd = new SqlCommand(str, con.con);
            int qtde = cmd.ExecuteNonQuery();

        }
    }
}
