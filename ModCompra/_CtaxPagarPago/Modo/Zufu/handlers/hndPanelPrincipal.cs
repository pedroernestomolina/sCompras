using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago.Modo.Zufu.handlers
{
    public class hndPanelPrincipal: basePanelPrincipal, Interfaces.IZufuPanelPrincipal
    {
        private _CtaxPagarPago_MetodosPago.Interfaces.IPanel _panelMetPago;
        private _CtaxPagarPago_DocPend.Interfaces.IPanel _panelDocPend;
        //
        public override string GetTituloFrm { get { return "Gestión (Pago/Deuda):"; } }
        //
        public hndPanelPrincipal()
            : base()
        {
            _panelMetPago = new _CtaxPagarPago_MetodosPago.Modo.Zufu.handlers.hndPanel();
            _panelDocPend = new _CtaxPagarPago_DocPend.Modo.Zufu.handlers.hndPanel();
        }
        public override void Inicializa()
        {
            _panelMetPago.Inicializa();
        }
        vistas.FrmPago frm;
        public override void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new vistas.FrmPago();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        // PANEL METODOS DE PAGO
        public override int GetCntMetRecibido { get { return _panelMetPago.GetCntMetRecibido; } }
        public override decimal GetMontoRecibido { get { return _panelMetPago.GetMontoRecibido; } }
        public override void AgregarMetPago()
        {
            _panelMetPago.AgregarMetPago(); 
        }
        public override void ListarMetPago()
        {
            _panelMetPago.ListarMetPago();
        }

        // PANEL DOCUMENTOS PENDIENTES
        public override int Get_DocSeleccionadosAPagar_Cnt { get { return _panelDocPend.Get_DocSeleccionadosAPagar_Cnt; } }
        public override decimal Get_DocSeleccionadosAPagar_Monto { get { return _panelDocPend.Get_DocSeleccionadosAPagar_Monto; } }
        public override decimal Get_DocPendPorPagar_DeudaTotal { get { return _panelDocPend.Get_DocPendPorPagar_DeudaTotal; } }


        //
        private bool cargarData()
        {
            return true;
        }
    }
}