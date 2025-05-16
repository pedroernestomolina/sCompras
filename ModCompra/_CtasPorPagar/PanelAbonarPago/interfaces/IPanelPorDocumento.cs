using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelAbonarPago.interfaces
{
    public interface IPanelPorDocumento: __.Interfaces.PanelAbonarPago.IPanel
    {
        void setMontoPorMetPagoRecibido(decimal monto);
        void setItemCargar(__.Modelos.GestionPagoDocumentos.IItemDesplegar item);
    }
}
