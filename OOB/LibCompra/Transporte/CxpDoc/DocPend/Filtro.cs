using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.DocPend
{
    public class Filtro
    {
        public string CadenaBusq { get; set; }
        public string IdEntidad { get; set; }
        public Filtro()
        {
            CadenaBusq = "";
            IdEntidad = "";
        }
    }
}
