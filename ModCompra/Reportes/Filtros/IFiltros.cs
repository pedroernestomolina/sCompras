using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros
{
    
    public interface IFiltros
    {

        bool ActivarProveedor { get; }
        bool ActivarSucursal { get; }
        bool ActivarDesde { get; }
        bool ActivarHasta { get; }
        bool ActivarEstatus { get; }
        bool ActivarMesAnoRelacion { get; }

    }

}