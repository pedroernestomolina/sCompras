using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelMetPagoLista.interfaces
{
    public interface IPanel: __.Interfaces.PanelMetPagoListar.IPanel
    {
        void setHndEditarMetodoPago(PanelMetPagoAgregar.interfaces.IPanelEditar hnd);
    }
}