using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_DocPend.Interfaces
{
    public interface IPanel
    {
        int Get_DocSeleccionadosAPagar_Cnt { get; }
        decimal Get_DocSeleccionadosAPagar_Monto { get; }
        decimal Get_DocPendPorPagar_DeudaTotal { get; }
        decimal GetTotalMontoCtasPendientes { get; }
       // IEnumerable<PanelPrincipal.Pago.IItemCtaPend> GetListaDocPagar { get; }
        //
        void Inicializa();
        void setIdEntidad(object id);
        void setEntidadInfo(string dat);
        void setMontoEntradasPorAbono(decimal monto);
        void setMontoPendPorPagar(decimal monto);
        //
        void ListarCtasPagar();
        void LimpiarData();
    }
}