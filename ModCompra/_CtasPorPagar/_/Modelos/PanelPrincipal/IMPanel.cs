using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal
{
    public interface IMPanel
    {
        string GetTextoBuscar { get; }
        int GetCntItems { get; }
        decimal GetMontoPendiente { get; }
        object GetDataSource { get; }
        IItemDesplegar GetItemActual { get; }
        IEnumerable<IItemDesplegar> GetItems { get; }
        IListaDesplegar ListaItemsDesplegar { get; } 
        //
        void Inicializa();
        //
        void setTextoBuscar(string texto);
        //
        void CargarCuentas();
        void ReporteGeneral();
    }
}
