using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.PanelDocumentos
{
    public interface IMDocumentos
    {
        int GetCantDoc { get; }
        decimal GetMontoResta { get; }
        decimal GetMontoAcumulado { get; }
        decimal GetMontoImporte { get; }
        string GetEntidadInfo { get; }
        IEnumerable<IItemDesplegar> GetItems { get; }
        //
        void Inicializa();
        void setItemCargar(__.Modelos.PanelPrincipal.IItemDesplegar item);
    }
}
