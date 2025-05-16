using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelMetPagoAgregar.interfaces
{
    public interface IPanelEditar: __.Interfaces.PanelMetPagoAgregar.IPanelAgregarEditar
    {
        __.Modelos.PanelMetPagoAgregar.IItemAgregar GetItemActualizado { get; }
        void setItemEditar(__.Modelos.PanelMetPagoAgregar.IItemAgregar item);
    }
}