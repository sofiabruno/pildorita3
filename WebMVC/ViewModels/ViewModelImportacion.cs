using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Dominio;

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

        [Required]
        [Display(Name = "Código del producto a importar")]
        public string Codigo { get; set; }



        //corregir xa q sean solo numeros enteros
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Sólo números enteros")]
        //[RegularExpression(@"^\d*$", ErrorMessage = "Sólo números enteros positivos")]      
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "La cantidad debe ser un número entero positivo mayor a 0")]
        [Required]
        public int Cantidad { get; set; }



        //corregir
        //[RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "número con maximo dos decimales")]
        //[RegularExpression(@"^[0-9]+(\.[0-9] [0-9]?)?$", ErrorMessage = "número con maximo dos decimales")]         
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "El precio debe ser un número entero positivo mayor a 0")]
        [Required]
        [Display(Name = "Precio unitario")]
        public int PrecioUnitario { get; set; }



        [Required]
        [Display(Name = "Código del producto a importar")]
        public List<Producto> Productos { get; set; }


    }
}