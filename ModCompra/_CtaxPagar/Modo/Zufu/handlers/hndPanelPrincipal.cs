using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.handlers
{
    public class hndPanelPrincipal: basePanelPrincipal, Zufu.Interfaces.IZufuPanelPrincipal
    {
        private Interfaces.IZufuLista _listaDocPend;
        private Interfaces.IZufuPanelEntidadDocPend _provCtasPend;
        private _CtaxPagarPago.Modo.Zufu.Interfaces.IZufuPanelPrincipal _gestionPago;
        // CASOS DE USO
        private usesCase.ICargarCtasPendientes _cargarCtsPendiente;
        private usesCase.IReporte_CtasPendiente_General _reporteCtasPendGeneral;
        private usesCase.IGetItemsDocPend _items;
        //
        public override string GetTituloPanel { get { return "TOOLS: Ctas Pendientes x Pagar"; } }
        public override object GetDataSource { get { return _listaDocPend.GetDataSource; } }
        public override decimal GetMontoPendiente { get { return montoPendiente(); } }
        public override int GetCntItems { get { return _listaDocPend.GetCntItems; } }
        public override object GetItemActual { get { return _listaDocPend.ItemActual; } }
        //
        public hndPanelPrincipal()
            :base()
        {
            _listaDocPend = new hndListaDocPend();
            //
            _cargarCtsPendiente = new usesCase.UC_CargarCtasPendientes();
            _reporteCtasPendGeneral = new usesCase.UC_Reporte_CtasPendiente_General();
            _items = new usesCase.UC_GetItemDocPend();
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _listaDocPend.Inicializa();
        }
        vistas.FrmPanelPrincipal frm;
        public override void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null)
                {
                    frm = new vistas.FrmPanelPrincipal();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public override void BuscarCtasPendientes()
        {
            var filtro = new OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro()
            {
                CadenaBusq = GetTextoBuscar,
            };
            _cargarCtsPendiente.setFiltro(filtro);
            _cargarCtsPendiente.setListaDestino(_listaDocPend);
            _cargarCtsPendiente.Execute();
            setTextoBuscar("");
        }
        public override void Proveedor_CtasPend()
        {
            if (GetItemActual != null)
            {
                var it = (dataItemDocPend)GetItemActual;
                if (_provCtasPend == null) 
                {
                    _provCtasPend = new HndPanelEntidadDocPend();
                }
                var _infoEntidad = "";
                _infoEntidad+= it.CiRifEntidad+Environment.NewLine;
                _infoEntidad+= it.NombreEntidad+Environment.NewLine;
                _provCtasPend.Inicializa();
                _provCtasPend.setIdEntidad(it.IdEntidad);
                _provCtasPend.setEntidadInfo(_infoEntidad);
                _provCtasPend.Inicia();
            }
        }
        public override void Reporte_CtasPendiente_General()
        {
            _reporteCtasPendGeneral.setData(_listaDocPend);
            _reporteCtasPendGeneral.Execute();
        }
        public override void GestionPago()
        {
            if (GetItemActual != null)
            {
                var it = (dataItemDocPend)GetItemActual;
                if (_provCtasPend == null)
                {
                    _provCtasPend = new HndPanelEntidadDocPend();
                }
                var _infoEntidad = "";
                _infoEntidad += it.CiRifEntidad + Environment.NewLine;
                _infoEntidad += it.NombreEntidad + Environment.NewLine;
                if (_gestionPago == null)
                {
                    _gestionPago = new _CtaxPagarPago.Modo.Zufu.handlers.hndPanelPrincipal();
                }
                _gestionPago.Inicializa();
                _gestionPago.setEntidadInfo(_infoEntidad);
                _gestionPago.setEntidadId(it.IdEntidad);
                _gestionPago.Inicia();
            }
        }
        //
        private bool cargarData()
        {
            return true;
        }
        private decimal montoPendiente()
        {
            if (_items == null) return 0m;
            _items.setData(_listaDocPend.GetItems);
            return _items.GetItems().Sum(s => s.MontoPendiente);
        }
    }
}