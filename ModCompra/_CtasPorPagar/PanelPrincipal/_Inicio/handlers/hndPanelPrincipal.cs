using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using ModCompra._CtasPorPagar.PanelPrincipal._Inicio.modelos;
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
        private interfaces.IListaItemsDesplegar _hndListaItemsDesplegar;
        // USESCASE
        private __.UsesCase.PanelPrincipal.ICargarCuentas _cargarCuentas;
        private __.UsesCase.PanelPrincipal.IReporteGeneral _reporteGeneral;
        //
        public override string GetTituloPanel { get { return "TOOLS: Ctas Pendientes x Pagar"; } }
        public override decimal GetMontoPendiente { get { return MPanel.GetMontoPendiente; } }
        public override int GetCntItems { get { return MPanel.GetCntItems; } }
        public interfaces.IListaItemsDesplegar HndListaItemsDesplegar { get { return _hndListaItemsDesplegar; } }
        public override object GetDataSource { get { return _hndListaItemsDesplegar.GetDataSource; } }
        public override IItemDesplegar GetItemActual { get { return _hndListaItemsDesplegar.ItemActual; } }
        //
        public hndPanelPrincipal()
            :base()
        {
            _mPanel = new modelos.MPanel();
            _hndListaItemsDesplegar = new hndListaDesplegar();
            _cargarCuentas = new usesCase.uc_CargarCtas();
            _reporteGeneral = new usesCase.uc_ReporteGeneral();
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _hndListaItemsDesplegar.Inicializa();
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
            var _filtro = new FiltroBusqueda()
            {
                TextoBuscar = GetTextoBuscar,
            };
            _cargarCuentas.setFiltro(_filtro);
            MPanel.CargarCuentas(_cargarCuentas.Execute());
            _hndListaItemsDesplegar.CargarItems(MPanel.GetItems);
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
            _reporteGeneral.setData(MPanel.GetItems);
            _reporteGeneral.Execute();
        }
        public override void GestionPago()
        {
            if (GetItemActual != null)
            {
                if (_hndGestionPago == null)
                {
                    _hndGestionPago = new GestionPago.handlers.hndPanel();
                }
                _hndGestionPago.Inicializa();
                _hndGestionPago.setItemCargar(GetItemActual);
                _hndGestionPago.Inicia();
            }
        }
        //
        private bool cargarData()
        {
            return true;
        }


        private ModCompra.srcTransporte.CtaPagar.Tools.Administrador.Vistas.IAdm _adm;
        public void AdmDocPagos()
        {
            if (_adm == null)
            {
                _adm = new ModCompra.srcTransporte.CtaPagar.Tools.Administrador.Handler.Imp();
            }
            _adm.Inicializa();
            _adm.Inicia();
        }
    }
}