using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas
{
    class conexão
    {
        public SqlConnection con = new SqlConnection(@"Server=(Local); Database=BDloja; Integrated Security=SSPI;");
        //public SqlConnection con = new SqlConnection(@"Server= DESKTOP-VJ7EFHS\SQLEXPRESS; Database=BDloja; Integrated Security=SSPI;");

                                                       
         public string conectar(){
            try
            {
                con.Open();
                return ("Conexão realizada com sucesso.");
            }
            catch(SqlException e) {
                return (e.ToString());
            
            }
        }

        public string desconectar()
        {
            try
            {
                con.Close();
                return ("Conexão encerrada");
            }
            catch (SqlException e)
            {
                return (e.ToString());

            }
        }
    }
}
