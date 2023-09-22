using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago
{
    public class Ficha
    {
        public Movimiento movimiento { get; set; }
        public decimal MontoPorAnticipoUsado { get; set; }
        public decimal MontoPorRetAnticipoUsado { get; set; }
    }
}