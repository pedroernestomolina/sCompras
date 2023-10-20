using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Vista
{
    public interface IHnd : HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {
        IFiltroActivar FiltroActivar { get; }
        Utils.FiltrosCB.ICtrlSinBusqueda Estatus { get; }
        Utils.FiltrosCB.ICtrlConBusqueda Aliado { get; }
        Vista.IFiltros Get_Filtros { get; }

        void setFiltrosCargar(IFiltroActivar filtroActivar);
    }
}