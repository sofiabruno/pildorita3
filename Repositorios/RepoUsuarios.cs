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
    public class RepoUsuarios : IRepositorio<Usuario>
    {
        public bool Alta(Usuario obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "insert into Usuarios(Ci, Password, Rol) values(@ci, @pwd, @rol);";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@ci", obj.Ci);
            cmd.Parameters.AddWithValue("@pwd", obj.Password);
            cmd.Parameters.AddWithValue("@rol", obj.Rol);

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

            string sql = "delete from Usuarios where Ci=@ci;";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@ci", id);

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

        public bool Modificacion(Usuario obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "update Usuarios set Password=@pwd where Ci=@ci;";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@pwd", obj.Password);
            cmd.Parameters.AddWithValue("@ci", obj.Ci);

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

        public List<Usuario> TraerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Usuarios;";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usr = new Usuario
                    {
                        Ci = reader.GetInt32(0),
                        Password = reader.GetString(1),
                        Rol = reader.GetString(2)
                    };

                    usuarios.Add(usr);
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

            return usuarios;
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usr = null;

            string strCon = "Data Source=(local); Initial Catalog=BasePortLog; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Usuarios where Ci=@ci";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@ci", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usr = new Usuario
                    {
                        Ci = reader.GetInt32(0),
                        Password = reader.GetString(1),
                        Rol = reader.GetString(2)
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

            return usr;
        }
    }
}
