using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;
using Dominio;


namespace PortLog
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Usuario

            //Console.WriteLine(FachadaPortLog.AltaUsuario(11112222, "Depo02", "deposito"));

            //Console.WriteLine(FachadaPortLog.BajaUsuario(11112222));

            //Console.WriteLine(FachadaPortLog.ModificacionUsuario(48435881,"fede","admin")); 

            //List<Usuario> usuarios = FachadaPortLog.TraerTodosLosUsuarios() as List<Usuario>;
            //if (usuarios == null)
            //{
            //    Console.WriteLine("No existen usuarios");
            //}
            //else
            //{
            //    foreach (Usuario u in usuarios)
            //    {
            //        Console.WriteLine("CI: " + u.Ci + "  Rol: " + u.Rol);
            //    }
            //}

            //Usuario u = FachadaPortLog.BuscarUsuarioPorId(1) as Usuario;
            //if (u == null)
            //{
            //    Console.WriteLine("No existe usuario solicitado");
            //}
            //else
            //{
            //    Console.WriteLine("CI: " + u.Ci + "  Rol: " + u.Rol);
            //}
            #endregion

            #region Cliente
            //DateTime fecha = new DateTime(2020, 04, 19);
            //Console.WriteLine(FachadaPortLog.AltaCliente("PruebaNoche", 111, fecha));

            //Console.WriteLine(FachadaPortLog.BajaCliente(111));

            //Console.WriteLine(FachadaPortLog.ModificacionCliente("Test1", 111, fecha));

            //List<Cliente> clientes = FachadaPortLog.TraerTodosLosClientes() as List<Cliente>;
            //if (clientes == null)
            //{
            //    Console.WriteLine("No existen clientes");
            //}
            //else
            //{
            //    foreach (Cliente c in clientes)
            //    {
            //        Console.WriteLine("Nombre: " + c.Nombre + "  RUT: " + c.Rut + "  Antiguedad: " + c.Antiguedad);
            //    }
            //}

            //Cliente c = FachadaPortLog.BuscarClientePorId(111) as Cliente;
            //if (c == null)
            //{
            //    Console.WriteLine("No existe usuario solicitado");
            //}
            //else
            //{
            //    Console.WriteLine("Nombre: " + c.Nombre + "  RUT: " + c.Rut + "  Antiguedad: " + c.Antiguedad);
            //}
            #endregion

            #region Producto

            // Console.WriteLine(FachadaPortLog.ModificacionProducto(2,5));
            //Console.WriteLine(FachadaPortLog.BuscarProductoPorId(2));

            #endregion

            #region Importacion


            //DateTime fchIngreso = new DateTime(2020, 05, 01);
            //DateTime fchSalida = new DateTime(2020, 10, 17);


            //Console.WriteLine(FachadaPortLog.AltaImportacion(
            //    fchIngreso, fchSalida, 1, 655,
            //200, 234567890123));


            #endregion





            Console.ReadLine();
        }
    }
}
