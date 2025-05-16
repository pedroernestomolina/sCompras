using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelMetPagoAgregar.interfaces
{
    public interface IPanelAgregar: __.Interfaces.PanelMetPagoAgregar.IPanelAgregarEditar
    {
        __.Modelos.PanelMetPagoAgregar.IItemAgregar ItemAgregar { get; }
    }
}