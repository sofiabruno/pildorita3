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
    public class RepoImportaciones : IRepositorio<Importacion>
    {
        string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BasePortLog; Integrated Security=SSPI;";


        public bool Alta(Importacion obj)
        {
            bool ret = false;

            //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "insert into Importaciones(FechaIngreso, SalidaPrevista, ProductoID, Cantidad, PrecioUnitario) values(@fchIng, @salPrev, @ProdId, @cant, @precio);";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@fchIng", obj.FechaIngreso);
            cmd.Parameters.AddWithValue("@salPrev", obj.SalidaPrevista);
            cmd.Parameters.AddWithValue("@ProdId", obj.Producto.Id);
            cmd.Parameters.AddWithValue("@cant", obj.Cantidad);
            cmd.Parameters.AddWithValue("@precio", obj.PrecioUnitario);
            


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
            bool ret = false;

            //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "delete from Clientes where ClienteID=@id;";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);

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

        public Importacion BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Importacion obj)
        {
            throw new NotImplementedException();
        }

        public List<Importacion> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
