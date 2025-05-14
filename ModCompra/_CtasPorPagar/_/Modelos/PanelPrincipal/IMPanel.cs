using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal
{
    public interface IMPanel
    {
        int GetCntItems { get; }
        decimal GetMontoPendiente { get; }
        IEnumerable<IItemDesplegar> GetItems { get; }
        //
        void Inicializa();
        //
        void CargarCuentas(IEnumerable<IItemDesplegar> items);
    }
}