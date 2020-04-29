using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public enum Rol
    {
        [Display(Name = "Administrador")]
        admin,
        [Display(Name = "Deposito")]
        deposito
    }
}
