using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.handlers
{
    public class hndPanel: basePanel, interfaces.IPanel
    {
        //private _CtaxPagarPago_MetodosPago.Interfaces.IPanel _panelMetPago;
        //private _CtaxPagarPago_DocPend.Interfaces.IPanel _panelDocPend;
        //
        public override string GetInfoEntidad { get { return ""; } }
        public override string GetTituloFrm { get { return "Gestión (Pago/Deuda):"; } }
        //
        public hndPanel()
            : base()
        {
            //_panelMetPago = new _CtaxPagarPago_MetodosPago.Modo.Zufu.handlers.hndPanel();
            //_panelDocPend = new _CtaxPagarPago_DocPend.Modo.Zufu.handlers.hndPanel();
        }
        public override void Inicializa()
        {
            //_panelMetPago.Inicializa();
        }
        vistas.Frm frm;
        public override void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        // PANEL METODOS DE PAGO
        public override int GetCntMetRecibido { get { return 0; } }
        public override decimal GetMontoRecibido { get { return 0m; } }
        public override void AgregarMetPago()
        {
            //_panelMetPago.AgregarMetPago(); 
        }
        public override void ListarMetPago()
        {
            //_panelMetPago.ListarMetPago();
        }

        // PANEL DOCUMENTOS PENDIENTES
        public override int Get_DocSeleccionadosAPagar_Cnt { get { return 0; } }
        public override decimal Get_DocSeleccionadosAPagar_Monto { get { return 0m; } }
        public override decimal Get_DocPendPorPagar_DeudaTotal { get { return 0m; } }


        //
        private bool cargarData()
        {
            return true;
        }
    }
}