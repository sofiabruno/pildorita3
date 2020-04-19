using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepoProductos : IRepositorio<Producto>
    {
        public bool Alta(Producto obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "insert into Productos(Codigo, Nombre, Peso, Rut) values (@cod, @nom, @pes, @rut)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cod", obj.Codigo);
            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@tas", obj.Peso);
            cmd.Parameters.AddWithValue("@rut", obj.Cliente.Rut);

            // El rut es FK, como se trae?

            try
            {
                con.Open();
                int afectadas = cmd.ExecuteNonQuery();
                con.Close();

                ret = afectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ret;
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Producto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Producto obj)
        {
            throw new NotImplementedException();
        }

        public List<Producto> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
