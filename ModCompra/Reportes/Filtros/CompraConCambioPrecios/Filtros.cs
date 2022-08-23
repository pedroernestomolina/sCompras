using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.CompraConCambioPrecios
{
    
    public class Filtros : IFiltros
    {

        public bool ActivarProveedor { get { return true; } }
        public bool ActivarSucursal { get { return true; } }
        public bool ActivarDesde { get { return true; } }
        public bool ActivarHasta { get { return true; } }
        public bool ActivarEstatus { get { return false; } }
        public bool ActivarMesAnoRelacion { get { return false; } }

    }

}