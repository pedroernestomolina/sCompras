using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago
{
    public class Detalle
    {
        public int idAliadoDoc { get; set; }
        public int idAliadoDocServ { get; set; }
        public decimal motnoDocSerMonDiv { get; set; }
    }
}