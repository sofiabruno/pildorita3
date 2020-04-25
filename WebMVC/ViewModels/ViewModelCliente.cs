using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels
{
    public class ViewModelCliente
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public long Rut { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Antiguedad { get; set; }
    }
}