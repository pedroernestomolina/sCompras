using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.PagoServ.AnularPago
{
    public class Ficha
    {
        public int idMovPago { get; set; }
        public int idAliado { get; set; }
        public decimal montoPorAnticipoUsado { get; set; }
        public decimal montoPorRetAnticipoUsado { get; set; }
        public List<detalleDoc> detalles { get; set; }
        public List<caja> cajas { get; set; }
    }
}