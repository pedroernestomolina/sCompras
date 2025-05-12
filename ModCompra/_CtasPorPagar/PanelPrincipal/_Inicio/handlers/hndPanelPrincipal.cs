using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.handlers
{
    public class hndPanelPrincipal: basePanelPrincipal, interfaces.IPanelPrincipal 
    {
        private PanelDocumentos.interfaces.IPanel _hndDocumentos;
        private GestionPago.interfaces.IPanel _hndGestionPago;
        //
        public override string GetTituloPanel { get { return "TOOLS: Ctas Pendientes x Pagar"; } }
        public override object GetDataSource { get { return MPanel.GetDataSource; } }
        public override decimal GetMontoPendiente { get { return MPanel.GetMontoPendiente; } }
        public override int GetCntItems { get { return MPanel.GetCntItems; } }
        public override IItemDesplegar GetItemActual { get { return MPanel.GetItemActual; } }
        //
        public hndPanelPrincipal()
            :base()
        {
            _mPanel = new modelos.MPanel();
        }
        public override void Inicializa()
        {
            base.Inicializa();
        }
        vistas.Frm frm;
        public override void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null)
                {
                    frm = new vistas.Frm ();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public override void BuscarCtasPendientes()
        {
            MPanel.CargarCuentas();
            setTextoBuscar("");
        }
        public override void Proveedor_CtasPend()
        {
            if (GetItemActual != null)
            {
                var it = (modelos.ItemDesplegar)GetItemActual;
                if (_hndDocumentos == null)
                {
                    _hndDocumentos = new PanelDocumentos.handlers.HndPanel();
                }
                _hndDocumentos.Inicializa();
                _hndDocumentos.setItemCargar(GetItemActual);
                _hndDocumentos.Inicia();
            }
        }
        public override void Reporte_CtasPendiente_General()
        {
            MPanel.ReporteGeneral();
        }
        public override void GestionPago()
        {
            if (GetItemActual != null)
            {
                //var it = (dataItemDocPend)GetItemActual;
                //if (_provCtasPend == null)
                //{
                //    _provCtasPend = new HndPanelEntidadDocPend();
                //}
                //var _infoEntidad = "";
                //_infoEntidad += it.CiRifEntidad + Environment.NewLine;
                //_infoEntidad += it.NombreEntidad + Environment.NewLine;
                if (_hndGestionPago == null)
                {
                    _hndGestionPago = new GestionPago.handlers.hndPanel();
                }
                _hndGestionPago.Inicializa();
                _hndGestionPago.setEntidadId("");
                _hndGestionPago.Inicia();
            }
        }
        //
        private bool cargarData()
        {
            return true;
        }
    }
}