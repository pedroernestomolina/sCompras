using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Handler
{
    public class Filtros: Vista.IFiltros
    {
        public Vista.enumerados.EstatusDoc EstatusDocumento { get; set; }
        public int IdAliado { get; set; }
        public Filtros()
        {
            EstatusDocumento = Vista.enumerados.EstatusDoc.SinDefinir;
            IdAliado = -1;
        }
    }
}
