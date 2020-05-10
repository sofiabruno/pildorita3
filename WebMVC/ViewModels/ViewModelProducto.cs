using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Dominio;

namespace WebMVC.ViewModels
{
    public class ViewModelProducto : IComparable<ViewModelProducto>
    {
        [Display(Name = "Código del producto")]
        public string Codigo { get; set; }

        
        public string Nombre { get; set; }

       
        public int Stock { get; set; }



        public int CompareTo(ViewModelProducto other)
        {
            return Codigo.CompareTo(other.Codigo) * (1);
        }

    }
}