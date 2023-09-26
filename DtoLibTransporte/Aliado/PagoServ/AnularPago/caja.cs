using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.PagoServ.AnularPago
{
    public class caja
    {
        public int idPagoServCaja { get; set; }
        public int idCaja { get; set; }
        public int idCajaMov { get; set; }
        public decimal monto { get; set; }
    }
}