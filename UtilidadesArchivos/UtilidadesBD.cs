using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UtilidadesArchivos
{
    class UtilidadesBD
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(strCon);
        }

        public static bool CerrarConexion(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                return true;
            }

            return false;
        }

        public static bool AbrirConexion(SqlConnection con)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                return true;
            }

            return false;
        }


    }
}
