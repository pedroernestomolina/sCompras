using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Cxp.PagoPorConceptos
{
    public class Ficha
    {
        public string recNro { get; set; }
        public DateTime recFecha { get; set; }
        public string entidadNombre { get; set; }
        public string entidadCiRif { get; set; }
        public decimal importeDiv { get; set; }
        public decimal tasaFactor { get; set; }
        public string siglasDoc { get; set; }
        public string numeroDoc { get; set; }
        public string conceptoDesc { get; set; }
        public string conceptoCod { get; set; }
    }
}