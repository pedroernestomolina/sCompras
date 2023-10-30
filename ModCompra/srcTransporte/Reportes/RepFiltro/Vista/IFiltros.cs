using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Vista
{
    public class enumerados
    {
        public enum EstatusDoc { SinDefinir = -1, Activo = 0, Inactivo = 1 };
        public enum TipoMovCaja { SinDefinir = -1, Ingreso= 0, Egreso= 1 };

    }
    public interface IFiltros
    {
        enumerados.TipoMovCaja TipoMovCaja { get; set; }
        enumerados.EstatusDoc EstatusDocumento { get; set; }
        int IdAliado { get; set; }
        string IdProveedor { get; set; }
        int IdCaja { get; set; }
        int IdConcepto { get; set; }
        int IdBeneficiario { get; set; }
        DateTime? Desde { get; set; }
        DateTime? Hasta { get; set; }
    }
}