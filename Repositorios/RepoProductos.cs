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
        //string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BasePortLog; Integrated Security=SSPI;";
        string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";



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

            string sql = "select * from productos p, clientes c where p.productoId = @id and c.ClienteID = p.ClienteID";


            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Cliente elcliente = new Cliente
                    {
                        Id = reader.GetInt32(4),
                        Rut = reader.GetInt64(6),
                        Nombre = reader.GetString(7),
                        Antiguedad = reader.GetDateTime(8)

                    };
                                       
                    prod = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Codigo = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Peso = reader.GetDecimal(3),
                        Cliente = elcliente


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
            throw new NotImplementedException();
        }

        public List<Producto> TraerTodos()
        {
            List<Producto> productos = new List<Producto>();

            //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from productos p, clientes c where c.ClienteID = p.ClienteID;";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cadaCliente = new Cliente
                    {
                        Id = reader.GetInt32(4),
                        Rut = reader.GetInt64(6),
                        Nombre = reader.GetString(7),
                        Antiguedad = reader.GetDateTime(8)

                    };


                    Producto prod = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Codigo = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Peso = reader.GetDecimal(3),
                        Cliente = cadaCliente


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

        public Producto BuscarPorCodigo(string codigo)
        {
            Producto prod = null;

            //string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from productos p, clientes c where p.codigo = @cod and c.ClienteID = p.ClienteID";


            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cod", codigo);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Cliente elcliente = new Cliente
                    {
                        Id = reader.GetInt32(4),
                        Rut = reader.GetInt64(6),
                        Nombre = reader.GetString(7),
                        Antiguedad = reader.GetDateTime(8)

                    };

                    prod = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Codigo = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Peso = reader.GetDecimal(3),
                        Cliente = elcliente


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
    }
}
