using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.GetInfoEntidad
{
    public class DocPendiente
    {
        public string idCxP { get; set; }
        public string idDocOrigen { get; set; }
        public DateTime fechaEmision { get; set; }
        public int diasCredito { get; set; }
        public string tipoDoc { get; set; }
        public string docNro { get; set; }
        public int signoDoc { get; set; }
        public DateTime fechaVence { get; set; }
        public string ciRif { get; set; }
        public string nombreRazonSocial { get; set; }
        public decimal importeDiv { get; set; }
        public decimal acumuladoDiv { get; set; }
        public decimal restaDiv { get; set; }
        public decimal tasafactor { get; set; }
        public string idEntidad { get; set; }
        public int diasvencida { get; set; }
        public string notasDoc { get; set; }
    }
}
