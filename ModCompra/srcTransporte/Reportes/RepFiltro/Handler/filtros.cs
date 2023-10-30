using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Handler
{
    public class Filtros: Vista.IFiltros
    {
        public Vista.enumerados.TipoMovCaja TipoMovCaja {get;set;}
        public Vista.enumerados.EstatusDoc EstatusDocumento { get; set; }
        public int IdAliado { get; set; }
        public string IdProveedor { get; set; }
        public int IdCaja { get; set; }
        public int IdConcepto { get; set; }
        public int IdBeneficiario { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public Filtros()
        {
            TipoMovCaja = Vista.enumerados.TipoMovCaja.SinDefinir;
            EstatusDocumento = Vista.enumerados.EstatusDoc.SinDefinir;
            IdAliado = -1;
            IdProveedor = "";
            IdCaja = -1;
            IdConcepto = -1;
            IdBeneficiario = -1;
            Desde = null;
            Hasta = null;
        }
    }
}