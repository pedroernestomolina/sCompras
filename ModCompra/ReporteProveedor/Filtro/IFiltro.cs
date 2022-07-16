using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.ReporteProveedor.Filtro
{
    
    public interface IFiltro
    {

        bool ActivarGrupo{ get; }
        bool ActivarEstado { get; }
        bool ActivarEstatus { get; }

    }

}