using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorios;

namespace Repositorios
{
    public static class FachadaPortLog
    {
        #region FachadaUsuario
        public static bool AltaUsuario(int ci, string password, string rol)
        {
            bool ret = false;

            Usuario usr = new Usuario()
            {
                Ci = ci,
                Password = password,
                Rol = rol
            };

            RepoUsuarios repoUsr = new RepoUsuarios();
            ret = repoUsr.Alta(usr);

            return ret;
        }

        public static bool BajaUsuario(int ci)
        {
            bool ret = false;

            RepoUsuarios repoUsr = new RepoUsuarios();
            ret = repoUsr.Baja(ci);

            return ret;
        }

        public static bool ModificacionUsuario(int ci, string password, string rol)
        {
            bool ret = false;

            Usuario usrMod = null;
            RepoUsuarios repoUsr = new RepoUsuarios();
            List<Usuario> usuarios = repoUsr.TraerTodos();

            foreach (Usuario u in usuarios)
            {
                if (u.Ci == ci)
                {
                    u.Password = password;
                    usrMod = u;
                }
            }

            ret = repoUsr.Modificacion(usrMod);

            return ret;
        }

        //public static List<Usuario> TraerTodosLosUsuarios()
        //{
        //    List<Usuario> usuarios = new List<Usuario>();

        //    RepoUsuarios repoUsr = new RepoUsuarios();
        //    usuarios = repoUsr.TraerTodos();

        //    return usuarios;
        //}

        public static List<Usuario> TraerTodosLosUsuarios()
        {
            RepoUsuarios repoUsr = new RepoUsuarios();

            return repoUsr.TraerTodos();
        }

        public static Usuario BuscarUsuarioPorId(int ci)
        {
            RepoUsuarios repoUsr = new RepoUsuarios();
            return repoUsr.BuscarPorId(ci);
        }
        #endregion

        #region FachadaCliente
        public static bool AltaCliente(string nombre, int rut, DateTime antiguedad)
        {
            bool ret = false;

            Cliente cli = new Cliente()
            {
                Nombre = nombre,
                Rut = rut,
                Antiguedad = antiguedad
            };

            RepoClientes repoCli = new RepoClientes();
            ret = repoCli.Alta(cli);

            return ret;
        }

        public static bool BajaCliente(int rut)
        {
            bool ret = false;

            RepoClientes repoCli = new RepoClientes();
            ret = repoCli.Baja(rut);

            return ret;
        }

        public static bool ModificacionCliente(string nombre, int rut, DateTime antiguedad)
        {
            bool ret = false;

            Cliente cliMod = null;
            RepoClientes repoCli = new RepoClientes();
            List<Cliente> clientes = repoCli.TraerTodos();

            foreach (Cliente c in clientes)
            {
                if (c.Rut == rut)
                {
                    c.Nombre = nombre;
                    cliMod = c;
                }
            }

            ret = repoCli.Modificacion(cliMod);

            return ret;
        }

        public static List<Cliente> TraerTodosLosClientes()
        {
            RepoClientes repoCli = new RepoClientes();

            return repoCli.TraerTodos();
        }

        public static Cliente BuscarClientePorId(int rut)
        {
            RepoClientes repoCli = new RepoClientes();
            return repoCli.BuscarPorId(rut);
        }
        #endregion

        #region FachadaProducto



        #endregion

        #region Fachada Importacion



        #endregion

    }
}
