using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfServicioImportaciones
{
    [DataContract]
    public class DTOImportacion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime FechaIngreso { get; set; }

        [DataMember]
        public DateTime SalidaPrevista { get; set; }

        [DataMember]
        public int IdProducto { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public decimal PrecioUnitario { get; set; }

        [DataMember]
        public long Rut { get; set; }


    }
}