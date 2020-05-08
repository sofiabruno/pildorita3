using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio;
using Repositorios;

namespace WcfServicioImportaciones
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioImportacion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioImportacion.svc o ServicioImportacion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioImportacion : IServicioImportacion
    {
        public bool AltaImportacion(DTOImportacion importacion)
        {
            bool ret = false;

            RepoImportaciones repoImp = new RepoImportaciones();

            RepoProductos repoProd = new RepoProductos();
            Producto prod = repoProd.BuscarPorCodigo(importacion.CodigoProd);

            Importacion import = new Importacion()
            {
                FechaIngreso = importacion.FechaIngreso,
                SalidaPrevista = importacion.SalidaPrevista,
                Producto = prod,
                Cantidad = importacion.Cantidad,
                PrecioUnitario = importacion.PrecioUnitario
                

            };

            ret = repoImp.Alta(import);

            return ret;

        
        }
    }
}
