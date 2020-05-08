using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels
{
    public class ViewModelImportacion
    {
        [Required]
        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }


        //controlar q la fecha de salida no se menor q la de entrada
        [Required]
        [Display(Name = "Fecha de salida prevista")]
        [DataType(DataType.Date)]
       
        public DateTime SalidaPrevista { get; set; }

        [Display(Name = "Ingrese el código del producto a importar")]
        public String Codigo { get; set; }


        [Required]
        //corregir xa q sean solo numeros enteros
        //[RegularExpression(@"^[0-9]$", ErrorMessage = "Sólo números enteros")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Precio unitario")]
        
        //corregir
        //[RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "número con maximo dos decimales")]
        public decimal PrecioUnitario { get; set; }
    }
}