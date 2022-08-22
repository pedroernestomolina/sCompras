using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.GeneralDocumentos
{
    
    public class Filtros : IFiltros
    {

        public bool ActivarProveedor { get { return true; } }
        public bool ActivarSucursal { get { return true; } }
        public bool ActivarDesde { get { return true; } }
        public bool ActivarHasta { get { return true; } }
        public bool ActivarEstatus { get { return true; } }
        public bool ActivarMesAnoRelacion { get { return false; } }

    }

}