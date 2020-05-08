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

            //verificar que el rut que se ingresa
            //en el form corresponda con objerto.producto.cliente.rut

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
            List<Importacion> lista = new List<Importacion>();

            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Importaciones i, Productos p, clientes ;";

            SqlCommand cmd = new SqlCommand(sql, con);

           
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente
                    {
                        Id = reader.GetInt32(11),
                        Rut = reader.GetInt64(12),
                        Nombre = reader.GetString(13),
                        Antiguedad = reader.GetDateTime(14)
                    };

                    Producto p = new Producto
                    {

                        Id = reader.GetInt32(6),
                        Codigo = reader.GetString(7),
                        Nombre = reader.GetString(8),
                        Peso = reader.GetDecimal(9),
                        Cliente = cli

                    };

                    Importacion import = new Importacion
                    {
                        Id = reader.GetInt32(0),
                        FechaIngreso = reader.GetDateTime(1),
                        SalidaPrevista = reader.GetDateTime(2),
                        Producto = p,
                        Cantidad = reader.GetInt32(4),
                        PrecioUnitario = reader.GetDecimal(5)

                    };

                    lista.Add(import);
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



            return lista;
        }

        public List<Importacion> TraerImportacionesPorProd(int idProd)
        {
            List<Importacion> lista = new List<Importacion>();

            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Importaciones i, Productos p, clientes c where i.ProductoID = p.ProductoID and p.ClienteID = c.ClienteID and i.ProductoID =@id;";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", idProd);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente
                    {
                        Id = reader.GetInt32(11),
                        Rut = reader.GetInt64(12),
                        Nombre = reader.GetString(13),
                        Antiguedad = reader.GetDateTime(14)
                    };

                    Producto p = new Producto
                    {
                        
                        Id = reader.GetInt32(6),
                        Codigo = reader.GetString(7),
                        Nombre = reader.GetString(8),
                        Peso = reader.GetDecimal(9),
                        Cliente = cli

                    };
                    
                    Importacion import = new Importacion
                    {
                      Id = reader.GetInt32(0),
                      FechaIngreso = reader.GetDateTime(1),
                      SalidaPrevista = reader.GetDateTime(2),
                      Producto = p,                      
                      Cantidad = reader.GetInt32(4),
                      PrecioUnitario = reader.GetDecimal(5)
                     
                    };

                    lista.Add(import);
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



            return lista;

        }

        public List<Importacion> TraerImportacionesPorCliente(long rut)
        {
            List<Importacion> lista = new List<Importacion>();

            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Importaciones i, Productos p, clientes c where i.ProductoID = p.ProductoID and p.ClienteID = c.ClienteID and c.Rut = @RUT;";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@RUT", rut);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente
                    {
                        Id = reader.GetInt32(11),
                        Rut = reader.GetInt64(12),
                        Nombre = reader.GetString(13),
                        Antiguedad = reader.GetDateTime(14)
                    };

                    Producto p = new Producto
                    {

                        Id = reader.GetInt32(6),
                        Codigo = reader.GetString(7),
                        Nombre = reader.GetString(8),
                        Peso = reader.GetDecimal(9),
                        Cliente = cli

                    };

                    Importacion import = new Importacion
                    {
                        Id = reader.GetInt32(0),
                        FechaIngreso = reader.GetDateTime(1),
                        SalidaPrevista = reader.GetDateTime(2),
                        Producto = p,
                        Cantidad = reader.GetInt32(4),
                        PrecioUnitario = reader.GetDecimal(5)

                    };

                    lista.Add(import);
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



            return lista;

        }

        public int CalcularStockDeUnProd (int idProd)
        {
            DateTime fchHoy = DateTime.Today;

            List<Importacion> listaProd = new List<Importacion>();

            listaProd = TraerImportacionesPorProd(idProd);

            int stock = 0;

            foreach (Importacion importacion  in listaProd)
            {
                
                if (importacion.FechaIngreso <= fchHoy && importacion.SalidaPrevista >= fchHoy)
                {
                    stock += importacion.Cantidad;
                }
            }

            return stock;



        }

    }
}
