using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelAbonarPago.interfaces
{
    public interface IPanelPorMonto: __.Interfaces.PanelAbonarPago.IPanel
    {
        void setMontoDisponible(decimal monto);
    }
}
