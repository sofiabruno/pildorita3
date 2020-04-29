using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dominio
{
    public static class Validaciones
    {
        public static bool ValidarCiUsuario(int ci)
        {
            bool ret = false;

            // Opcion clasica
            //if (ci.ToString().Length == 7 || ci.ToString().Length == 8)
            //{
            //    ret = true;
            //}

            // Opcion con expresion regular
            ret = Regex.IsMatch(ci.ToString(), @"^[0-9]{7,8}$");

            return ret;
        }

        public static bool ValidarPassword(string pass)
        {
            bool ret = false;

            ret = Regex.IsMatch(pass, @"^(?=(?:.*\d){1})(?=(?:.*[A-Z]){1})(?=(?:.*[a-z]){2})\S{6,50}$");

            return ret;
        }











    }
}
