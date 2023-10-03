using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Filtro.Vistas
{
    public class Enumerados
    {
        public enum EstatusDoc { SinDefinir = -1, Activo = 1, Anulado };
        public enum TipoMovCaja { SinDefinir = -1, Ingreso = 1, Egreso };
    }
    public interface IdataFiltrar
    {
        DateTime? Desde { get; set; }
        DateTime? Hasta { get; set; }
        Enumerados.EstatusDoc EstatusDoc { get; set; }
        Enumerados.TipoMovCaja TipoMovCaja { get; set; }
        int IdCaja { get; set; }
        int IdAliado { get; set; }

        void Inicializa();
    }
}