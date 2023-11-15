using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.Pago.Lista
{
    public class Filtro
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string IdProveedor { get; set; }
        public enumerados.EstatusDoc EstatusDoc { get; set; }
    }
}