using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio;
using Repositorios;

namespace WcfServicioProductos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioProductos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioProductos.svc o ServicioProductos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioProductos : IServicioProductos
    {
      
        public List<DTOproducto> TraerTodo()
        {
            List<DTOproducto> listProd = new List<DTOproducto>();

            RepoProductos repo = new RepoProductos();

            List<Producto> lista = repo.TraerTodos();

            foreach (Producto producto in lista)
            {
                DTOproducto produ = new DTOproducto
                {
                    Codigo = producto.Codigo,
                    Nombre = producto.Nombre,
                    Stock = producto.Stock
                    
                };
                listProd.Add(produ);

            }
            return listProd;


        }
    }
}
