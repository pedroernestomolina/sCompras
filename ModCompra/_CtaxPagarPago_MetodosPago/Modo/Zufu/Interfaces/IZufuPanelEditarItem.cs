using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.Interfaces
{
    public interface IZufuPanelEditarItem: _CtaxPagarPago_MetodosPago.Interfaces.IPanelAgregarEditarItem
    {
        object GetItemActualizado { get; }
        void setItemEditar(object item);
    }
}