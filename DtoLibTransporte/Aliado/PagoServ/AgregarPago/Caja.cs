using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.PagoServ.AgregarPago
{
    public class Caja
    {
        public int idCaja { get; set; }
        public string descCaja { get; set; }
        public bool esDivisa { get; set; }
        public decimal montoUsado { get; set; }
        public decimal montoUsadoMonAct { get; set; }
        public decimal montoUsadoMonDiv { get; set; }
    }
}