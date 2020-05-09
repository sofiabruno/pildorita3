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
        #region Usuario ----------------------------------------------------------------------------------- 
        public static bool AltaUsuario(int ci, string password, string rol)
        {
            bool ret = false;

            Usuario existe = BuscarUsuarioPorId(ci);

            if (existe == null) 
            {
                if (Validaciones.ValidarCiUsuario(ci) && Validaciones.ValidarPassword(password))
                {
                    Usuario usr = new Usuario()
                    {
                        Ci = ci,
                        Password = password,
                        Rol = rol
                    };

                    RepoUsuarios repoUsr = new RepoUsuarios();
                    ret = repoUsr.Alta(usr);
                }
            }           

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

        #region Cliente ----------------------------------------------------------------------------------- 
        public static bool AltaCliente(string nombre, long rut, DateTime antiguedad)
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

        public static bool BajaCliente(int id)
        {
            bool ret = false;

            RepoClientes repoCli = new RepoClientes();
            ret = repoCli.Baja(id);

            return ret;
        }

        public static bool ModificacionCliente(int id, string nombre, long rut, DateTime antiguedad)
        {
            bool ret = false;

            Cliente cliMod = null;
            RepoClientes repoCli = new RepoClientes();
            List<Cliente> clientes = repoCli.TraerTodos();

            foreach (Cliente c in clientes)
            {
                if (c.Id == id)
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

        public static Cliente BuscarClientePorId(int id)
        {
            RepoClientes repoCli = new RepoClientes();
            return repoCli.BuscarPorId(id);
        }

        public static Cliente BuscarClientePorRut(long rut)
        {
            RepoClientes repoCli = new RepoClientes();
            return repoCli.BuscarPorRut(rut);
        }
        #endregion

        #region Producto ----------------------------------------------------------------------------------

        public static List<Producto> TraerTodosLosProductos()
        {
            RepoProductos repoProds = new RepoProductos();

            return repoProds.TraerTodos();
        }

        
        public static Producto BuscarProductoPorId(int id)
        {
            RepoProductos repoProds = new RepoProductos();
            return repoProds.BuscarPorId(id);
        }

        public static Producto BuscarProductoPorCod(string codigo)
        {
            RepoProductos repoProds = new RepoProductos();
            return repoProds.BuscarPorCodigo(codigo);
        }


        #endregion

        #region Importacion -------------------------------------------------------------------------------

        public static List<Importacion> TraerTodasLasImportaciones()
        {
            RepoImportaciones repo = new RepoImportaciones();

            return repo.TraerTodos();
        }

        #endregion

    }
}
