using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data;


namespace Repositorios
{
    class RepoParametros : IRepositorio<Parametro>
    {
        public bool Alta(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Parametro BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public List<Parametro> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public Parametro Traer()
        {
            Parametro fila = null;

            //string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";

            SqlConnection con = new SqlConnection(strCon);

            string sql = "select*from Parametros;";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    fila = new Parametro
                    {
                        porcDiario = reader.GetDouble(0),
                        dtoAnti = reader.GetDouble(1),
                        antigMin = reader.GetInt32(2)
                    };
                }

                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }


            return fila;
        }

    }
}
