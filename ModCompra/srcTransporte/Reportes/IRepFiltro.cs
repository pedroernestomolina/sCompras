using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes
{
    public interface IRepFiltro: IRep
    {
        void setFiltros(object filtros);
    }
}