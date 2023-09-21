using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.Anticipo.Agregar
{
    public class AliadoCaja
    {
        public int idCaja { get; set; }
        public int idAliado { get; set; }
        public decimal monto { get; set; }
        public CajaMovimiento movimientoCaja { get; set; }
    }
}