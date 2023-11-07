using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Caja
{
    public class enumerados
    {
        public enum TipoMovCaja { SinDefinir = -1, Ingreso = 1, Egreso };
        public enum EstatusDoc { SinDefinir = -1, Activo = 1, Anulado };
    }
}