using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Reportes.CompraporDepartamento
{
    
    public class Ficha
    {

        public string autoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public decimal total { get; set; }
        public decimal totalDivisa { get; set; }
        public int signoDoc { get; set; }
        public string tipoDoc { get; set; }
        public string nombreDoc { get; set; }
        public string serieDoc { get; set; }

    }

}