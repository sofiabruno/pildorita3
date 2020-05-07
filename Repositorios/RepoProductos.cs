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
        string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BasePortLog; Integrated Security=SSPI;";


        public bool Alta(Producto obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Producto BuscarPorId(int id)
        {
            Producto prod = null;

            //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Productos where ProductoId=@id";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                                       
                    prod = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Codigo = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Peso = reader.GetDecimal(3),
                        //Cliente.Rut = reader.Get(4),
                        RUT = reader.GetInt64(4),
                        Stock = reader.GetInt32(5)


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

            return prod;
        }

        public bool Modificacion(Producto obj)
        {
                bool ret = false;

                //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
                SqlConnection con = new SqlConnection(strCon);

                string sql = "update Productos set Stock=@stock where ProductoId=@id;";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@stock", obj.Stock);
                cmd.Parameters.AddWithValue("@id", obj.Id);

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

        public List<Producto> TraerTodos()
        {
            List<Producto> productos = new List<Producto>();

            //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Productos;";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto prod = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Codigo = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Peso = reader.GetDecimal(3),
                        //Cliente.Rut = reader.Get(4),
                        RUT = reader.GetInt64(4),
                        Stock = reader.GetInt32(5)

                    };

                    productos.Add(prod);
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

            return productos;
        }
    }
}
