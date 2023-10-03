using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Filtro.Vistas
{
    public interface IFiltro: HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {
        IHndFiltro HndFiltro { get; }
        void Limpiar();
    }
}