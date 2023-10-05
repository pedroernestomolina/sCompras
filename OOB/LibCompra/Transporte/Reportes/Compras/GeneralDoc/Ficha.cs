using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc
{
    public class Ficha
    {
        public string idDoc { get; set; }
        public DateTime fechaDoc { get; set; }
        public string prvNombre { get; set; }
        public string prvCiRif { get; set; }
        public decimal netoDoc { get; set; }
        public decimal totalDoc { get; set; }
        public string siglasDoc { get; set; }
        public decimal montoDiv { get; set; }
        public string estatusDoc { get; set; }
        public int signoDoc { get; set; }
        public DateTime fechaReg { get; set; }
        public string mesRel { get; set; }
        public string anoRel { get; set; }
        public string desConcepto { get; set; }
        public string numeroDoc { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoImpuesto { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoIgtf { get; set; }
    }
}