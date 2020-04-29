using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Ci { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        //public bool ValidarContra(string pass)
        //{
        //    bool salida = false;
        //    if (pass.Length > 99)
        //    {
        //        salida= true;
        //    }
            
        //    return salida;
        //}




    }

  
}
