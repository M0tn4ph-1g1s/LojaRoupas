using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace LojaRoupas
{
    class Backup2
    {
        public static string Backup()
        {
            conexão con = new conexão();
            string NomedoSistema = "LojaGames";
            try
            {
                SqlCommand cmdBackup = new SqlCommand("BACKUP DATABASE BDLoja TO DISK = " + "'C:\\Arquivos de Programas\\Microsoft SQL Server\\MSSQL14.MSSQLSERVER\\MSSQL\\Backup\\" + NomedoSistema + "-" + DateTime.Today.Day.ToString() + "_" + DateTime.Today.Month.ToString() + "_" + DateTime.Today.Year.ToString() + ".bak' WITH INIT"
                    , con.con);
                con.conectar();
                cmdBackup.ExecuteNonQuery();
                con.desconectar();

                return "Backup realizado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static string restore(string nomeArquivo)
        {
            conexão con = new conexão();
            try
            {
                SqlCommand cmdRestore = new System.Data.SqlClient.SqlCommand(
                    "USE MASTER RESTORE DATABASE [BDLoja] FROM DISK = '"
                    + nomeArquivo + "' WITH REPLACE", con.con);
                con.conectar();
                cmdRestore.ExecuteNonQuery();
                con.desconectar();
                return "Restauração realizada com sucesso!";
            }
            catch (Exception erro)
            {
                return erro.ToString();
            }
        }
    }
}
