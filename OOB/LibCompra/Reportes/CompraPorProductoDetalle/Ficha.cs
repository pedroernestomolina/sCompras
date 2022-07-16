using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Reportes.CompraPorProductoDetalle
{
    
    public class Ficha
    {

        public string autoPrd { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public decimal cantUnd { get; set; }
        public decimal costoUnd { get; set; }
        public int signoDoc { get; set; }
        public string documento { get; set; }
        public DateTime fecha { get; set; }
        public string tipoDoc { get; set; }
        public string serieDoc { get; set; }
        public string nombreDoc { get; set; }
        public decimal factor { get; set; }
        public decimal total { get; set; }
        public decimal totalDivisa { get; set; }

    }

}