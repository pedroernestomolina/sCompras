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
        //
        public override string GetTituloFrm { get { return "Gestión (Pago/Deuda):"; } }
        public override int GetCntMetRecibido { get { return _panelMetPago.GetCntMetRecibido; } }
        public override decimal GetMontoRecibido { get { return _panelMetPago.GetMontoRecibido; } }
        //
        public hndPanelPrincipal()
            : base()
        {
            _panelMetPago = new _CtaxPagarPago_MetodosPago.Modo.Zufu.handlers.hndPanel();
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
        //
        private bool cargarData()
        {
            return true;
        }
    }
}