using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Dominio;

namespace WebMVC.ViewModels
{
    public class ViewModelUsuario
    {
        [Required]
        [RegularExpression(@"^[0-9]{7,8}$", ErrorMessage = "La CI debe tener 7 u 8 dígitos")]
        public int Ci { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,50}$", ErrorMessage = "La contraseña debe contar con al menos 6 caracteres, debe incluir al menos una mayúscula, una minúscula y un dígito")]
        public string Password { get; set; }
        [Required]
        public Rol Rol { get; set; }
    }
}