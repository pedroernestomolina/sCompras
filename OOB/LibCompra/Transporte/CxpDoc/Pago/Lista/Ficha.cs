using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.Pago.Lista
{
    public class Ficha
    {
        public string idMov { get; set; }
        public string reciboNro { get; set; }
        public decimal importe { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public DateTime fecha { get; set; }
        public decimal tasaFactor { get; set; }
        public string nota { get; set; }
        public string estatusDoc { get; set; }
    }
}