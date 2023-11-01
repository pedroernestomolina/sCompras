using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Vista
{
    public interface IAgregarEditar: HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar 
    {
        string Get_TituloFicha { get; }
        decimal Get_MontoResta { get; }

        IHndData HndData { get; }
    }
}