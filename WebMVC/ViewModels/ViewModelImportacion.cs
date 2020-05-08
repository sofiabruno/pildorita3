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

        [Required]
        [Display(Name = "Fecha de salida prevista")]
        [DataType(DataType.Date)]
        public DateTime SalidaPrevista { get; set; }

       
        public int IdProducto { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]$", ErrorMessage = "Sólo números enteros")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Precio unitario")]
        [RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "número con maximo dos decimales")]
        public decimal PrecioUnitario { get; set; }
    }
}