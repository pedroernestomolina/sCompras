using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.PagoServ.AnularPago
{
    public class detalleDoc
    {
        public int idAliadoDoc { get; set; }
        public int idAliadoDocServ { get; set; }
        public int idPagoServDet { get; set; }
        public decimal monto { get; set; }
    }
}