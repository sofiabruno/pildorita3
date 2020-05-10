using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Importacion : IComparable<Importacion>
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [Required]
        [Display(Name = "Fecha de Salida Prevista")]
        [DataType(DataType.Date)]
        public DateTime SalidaPrevista { get; set; }
        [Required]
        public Producto Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "Precio Unitario")]
        public int PrecioUnitario { get; set; }




        public int CompareTo(Importacion other)
        {
            return Producto.Codigo.CompareTo(other.Producto.Codigo) * (1);
        }



    }
}
