using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels
{
    public class ViewModelUsuario
    {
        [Required]
        public int Ci { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}