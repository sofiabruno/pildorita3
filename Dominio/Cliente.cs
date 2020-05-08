using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Rut { get; set; }
        [DataType(DataType.Date)]
        public DateTime Antiguedad { get; set; }
        
    }
}
