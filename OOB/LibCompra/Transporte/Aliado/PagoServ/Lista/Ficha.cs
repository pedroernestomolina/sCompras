using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.PagoServ.Lista
{
    public class Ficha
    {
        public int idMov { get; set; }
        public string nombreAliado { get; set; }
        public string cirifAliado { get; set; }
        public string numRecibo { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public decimal montoPagoSelMonDiv { get; set; }
        public string estatusAnulado { get; set; }
        public int cntServPag { get; set; }
    }
}