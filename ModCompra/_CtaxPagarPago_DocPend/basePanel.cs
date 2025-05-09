using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_DocPend
{
    abstract public class basePanel: Interfaces.IPanel
    {
        private object _idEntidad;
        private string _infoEntidad;
        private decimal _montoPendPorPagar;
        private decimal _montoEntradaPorAbonos;
        //
        abstract public int Get_DocSeleccionadosAPagar_Cnt { get; }
        abstract public decimal Get_DocSeleccionadosAPagar_Monto { get; }
        abstract public decimal Get_DocPendPorPagar_DeudaTotal { get; }
        abstract public decimal GetTotalMontoCtasPendientes { get; }
        //
        public basePanel()
        {
        }
        abstract public void Inicializa();
        public void setIdEntidad(object id)
        {
            _idEntidad=id;
        }
        public void setMontoEntradasPorAbono(decimal monto)
        {
            _montoEntradaPorAbonos = monto;
        }
        public void setEntidadInfo(string dat)
        {
            _infoEntidad = dat;
        }
        public void setMontoPendPorPagar(decimal monto)
        {
            _montoPendPorPagar = monto;
        }
        //
        abstract public void ListarCtasPagar();
        public void LimpiarData()
        {
            //_idCliente = "";
        }
    }
}