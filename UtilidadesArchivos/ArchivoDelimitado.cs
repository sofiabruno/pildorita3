using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace UtilidadesArchivos
{
    public class ArchivoDelimitado
    {
        #region txtUsuario
        public static void GuardarUsuariosArchivo(string delimitador, string carpeta, string nombreArchivo)
        {
            string usuariosDelimitados = ArmarStringUsuarios(delimitador);

            try
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, nombreArchivo);

                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine(usuariosDelimitados);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string ArmarStringUsuarios(string delimitador)
        {
            SqlConnection con = UtilidadesBD.CrearConexion();

            string sql = "select * from Usuarios;";
            SqlCommand cmd = new SqlCommand(sql, con);

            StringBuilder contenidoArchivo = new StringBuilder();

            try
            {
                UtilidadesBD.AbrirConexion(con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string linea = ArmarFilaDelimitadaUsuarios(reader, delimitador);
                    if (!string.IsNullOrEmpty(linea))
                    {
                        contenidoArchivo.AppendLine(linea);
                    }
                }
                return contenidoArchivo.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UtilidadesBD.CerrarConexion(con);
            }

        }

        public static string ArmarFilaDelimitadaUsuarios(IDataRecord fila, string delimitador)
        {
            string linea = "";
            if (fila != null && delimitador != null)
            {
                linea += fila["Ci"].ToString() + delimitador +
                    fila["Password"].ToString() + delimitador +
                    fila["Rol"].ToString();
            }
            return linea;
        }
        #endregion

        #region txtCliente
        public static void GuardarClientesArchivo(string delimitador, string carpeta, string nombreArchivo)
        {
            string clientesDelimitados = ArmarStringClientes(delimitador);

            try
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, nombreArchivo);

                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine(clientesDelimitados);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string ArmarStringClientes(string delimitador)
        {
            SqlConnection con = UtilidadesBD.CrearConexion();

            string sql = "select * from Clientes;";
            SqlCommand cmd = new SqlCommand(sql, con);

            StringBuilder contenidoArchivo = new StringBuilder();

            try
            {
                UtilidadesBD.AbrirConexion(con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string linea = ArmarFilaDelimitadaClientes(reader, delimitador);
                    if (!string.IsNullOrEmpty(linea))
                    {
                        contenidoArchivo.AppendLine(linea);
                    }
                }
                return contenidoArchivo.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UtilidadesBD.CerrarConexion(con);
            }

        }

        public static string ArmarFilaDelimitadaClientes(IDataRecord fila, string delimitador)
        {
            string linea = "";
            if (fila != null && delimitador != null)
            {
                linea += fila["ClienteID"].ToString() + delimitador +
                    fila["Rut"].ToString() + delimitador +
                    fila["Nombre"].ToString() + delimitador +
                    fila["Antiguedad"].ToString();
            }
            return linea;
        }
        #endregion

        #region txtProductos
        public static void GuardarProductosArchivo(string delimitador, string carpeta, string nombreArchivo)
        {
            string productosDelimitados = ArmarStringProductos(delimitador);

            try
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, nombreArchivo);

                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine(productosDelimitados);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string ArmarStringProductos(string delimitador)
        {
            SqlConnection con = UtilidadesBD.CrearConexion();

            string sql = "select * from Productos;";
            SqlCommand cmd = new SqlCommand(sql, con);

            StringBuilder contenidoArchivo = new StringBuilder();

            try
            {
                UtilidadesBD.AbrirConexion(con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string linea = ArmarFilaDelimitadaProductos(reader, delimitador);
                    if (!string.IsNullOrEmpty(linea))
                    {
                        contenidoArchivo.AppendLine(linea);
                    }
                }
                return contenidoArchivo.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UtilidadesBD.CerrarConexion(con);
            }

        }

        public static string ArmarFilaDelimitadaProductos(IDataRecord fila, string delimitador)
        {
            string linea = "";
            if (fila != null && delimitador != null)
            {
                linea += fila["ProductoID"].ToString() + delimitador +
                    fila["Codigo"].ToString() + delimitador +
                    fila["Nombre"].ToString() + delimitador +
                    fila["Peso"].ToString() + delimitador +
                    fila["ClienteID"].ToString();
            }
            return linea;
        }
        #endregion

        #region txtImportaciones
        public static void GuardarImportacionesArchivo(string delimitador, string carpeta, string nombreArchivo)
        {
            string importacionesDelimitados = ArmarStringImportaciones(delimitador);

            try
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, nombreArchivo);

                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine(importacionesDelimitados);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string ArmarStringImportaciones(string delimitador)
        {
            SqlConnection con = UtilidadesBD.CrearConexion();

            string sql = "select * from Importaciones;";
            SqlCommand cmd = new SqlCommand(sql, con);

            StringBuilder contenidoArchivo = new StringBuilder();

            try
            {
                UtilidadesBD.AbrirConexion(con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string linea = ArmarFilaDelimitadaImportaciones(reader, delimitador);
                    if (!string.IsNullOrEmpty(linea))
                    {
                        contenidoArchivo.AppendLine(linea);
                    }
                }
                return contenidoArchivo.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UtilidadesBD.CerrarConexion(con);
            }

        }

        public static string ArmarFilaDelimitadaImportaciones(IDataRecord fila, string delimitador)
        {
            string linea = "";
            if (fila != null && delimitador != null)
            {
                linea += fila["ImportacionID"].ToString() + delimitador +
                    fila["FechaIngreso"].ToString() + delimitador +
                    fila["SalidaPrevista"].ToString() + delimitador +
                    fila["ProductoID"].ToString() + delimitador +
                    fila["Cantidad"].ToString() + delimitador +
                    fila["PrecioUnitario"].ToString();
            }
            return linea;
        }
        #endregion

    }
}
