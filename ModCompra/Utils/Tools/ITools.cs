using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Tools
{
    public interface ITools: HlpGestion.IGestion, HlpGestion.IAbandonar
    {
        IdataTools data { get; }
        string TituloTools { get; }
    }
}