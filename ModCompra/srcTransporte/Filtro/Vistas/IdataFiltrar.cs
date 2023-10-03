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
        public enum TipoRetencion { SinDefinir = -1, Iva = 1, ISLR };
    }
    public interface IdataFiltrar
    {
        DateTime? Desde { get; set; }
        DateTime? Hasta { get; set; }
        Enumerados.EstatusDoc EstatusDoc { get; set; }
        Enumerados.TipoMovCaja TipoMovCaja { get; set; }
        Enumerados.TipoRetencion TipoRetencion { get; set; }
        int IdCaja { get; set; }
        int IdAliado { get; set; }
        string IdProveedor { get; set; }

        void Inicializa();
    }
}