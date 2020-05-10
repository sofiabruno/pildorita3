using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesArchivos;

namespace TestArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchivoDelimitado.GuardarUsuariosArchivo("#", "ArchivosTexto", "DatosUsuarios.txt");
            ArchivoDelimitado.GuardarClientesArchivo("#", "ArchivosTexto", "DatosClientes.txt");
            ArchivoDelimitado.GuardarProductosArchivo("#", "ArchivosTexto", "DatosProductos.txt");
            ArchivoDelimitado.GuardarImportacionesArchivo("#", "ArchivosTexto", "DatosImportaciones.txt");

        }
    }
}
