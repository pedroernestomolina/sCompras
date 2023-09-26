using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla
{
    public class Serv
    {
        public string docNumero { get; set; }
        public DateTime docFecha { get; set; }
        public string docCodigo { get; set; }
        public string docNombre { get; set; }
        public decimal montoPago { get; set; }
        public string cliNombre { get; set; }
        public string cliCiRif { get; set; }
        public string codServ { get; set; }
        public string descServ { get; set; }
        public string detServ { get; set; }
    }
}
