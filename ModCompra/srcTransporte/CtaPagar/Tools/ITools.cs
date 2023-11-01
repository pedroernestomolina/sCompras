using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools
{
    public interface ITools: HlpGestion.IGestion, HlpGestion.IAbandonar
    {
        IHndTool Hnd { get; }
        string TituloTools { get; }
    }
}