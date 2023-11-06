using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.Pago.Agregar
{
    public class DataReciboDoc
    {
        public string codTipoDc { get; set; }
        public string numDoc { get; set; }
        public decimal importeDivisa { get; set; }
        public string autoCxpDoc { get; set; }
    }
}