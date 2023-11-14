using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Cxp.PagosEmitidos
{
    public class Ficha
    {
        public string reciboNro { get; set; }
        public decimal importe { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public DateTime fecha { get; set; }
        public decimal tasaFactor { get; set; }
        public string nota { get; set; }
        public string estatus { get; set; }
    }
}