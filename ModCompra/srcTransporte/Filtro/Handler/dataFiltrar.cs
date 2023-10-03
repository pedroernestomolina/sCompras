using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Filtro.Handler
{
    public class dataFiltrar: Vistas.IdataFiltrar
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public Vistas.Enumerados.EstatusDoc EstatusDoc { get; set; }
        public Vistas.Enumerados.TipoMovCaja TipoMovCaja { get; set; }
        public int IdCaja { get; set; }
        public int IdAliado { get; set; }


        public dataFiltrar()
        {
            Desde = null;
            Hasta = null;
            EstatusDoc = Vistas.Enumerados.EstatusDoc.SinDefinir;
            TipoMovCaja = Vistas.Enumerados.TipoMovCaja.SinDefinir;
            IdCaja = -1;
            IdAliado = -1;
        }
        public void Inicializa()
        {
            Desde = null;
            Hasta = null;
            EstatusDoc = Vistas.Enumerados.EstatusDoc.SinDefinir;
            TipoMovCaja = Vistas.Enumerados.TipoMovCaja.SinDefinir;
            IdCaja = -1;
            IdAliado = -1;
        }
    }
}