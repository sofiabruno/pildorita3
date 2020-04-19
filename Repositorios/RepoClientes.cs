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
    public class RepoClientes : IRepositorio<Cliente>
    {
        public bool Alta(Cliente obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "insert into Clientes(Nombre, Rut, Antiguedad) values(@nom, @rut, @ant);";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@rut", obj.Rut);
            cmd.Parameters.AddWithValue("@ant", obj.Antiguedad);

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

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "delete from Clientes where Rut=@rut;";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@rut", id);

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

        public bool Modificacion(Cliente obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "update Clientes set Nombre=@nom where Rut=@rut;";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@rut", obj.Rut);

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

        public List<Cliente> TraerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente
                    {
                        Nombre = reader.GetString(0),
                        Rut = reader.GetInt32(1),
                        Antiguedad = reader.GetDateTime(2)
                    };

                    clientes.Add(cli);
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

            return clientes;
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente cli = null;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes where Rut=@rut";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@rut", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cli = new Cliente
                    {                  
                        Nombre = reader.GetString(0),
                        Rut = reader.GetInt32(1),
                        Antiguedad = reader.GetDateTime(2)
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

            return cli;
        }     
    }
}
