﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels
{
    public class ViewModelProducto
    {
        [Display(Name = "Código del producto")]
        public string Codigo { get; set; }

        
        public string Nombre { get; set; }

       
        public int Stock { get; set; }

    }
}