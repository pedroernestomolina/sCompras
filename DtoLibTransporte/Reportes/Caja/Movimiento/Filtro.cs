using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Caja.Movimiento
{
    public class Filtro: baseFiltro
    {
        public enumerados.TipoMovCaja  TipoMov { get; set; }
        public enumerados.EstatusDoc EstatusDoc { get; set; }
        public int IdCaja { get; set; }
    }
}