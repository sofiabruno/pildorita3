using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Usuario
    {
        public int Ci { get; set; }

        [Required]
     
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,50}$", ErrorMessage = "La contraseña debe contar con al menos 6 caracteres, debe incluir al menos una mayúscula, una minúscula y un dígito")]


        public string Password { get; set; }
        public string Rol { get; set; }
    }

  
}
