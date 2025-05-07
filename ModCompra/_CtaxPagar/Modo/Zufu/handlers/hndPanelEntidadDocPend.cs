using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagar.Modo.Zufu.handlers
{
    public class HndPanelEntidadDocPend : Interfaces.IZufuPanelEntidadDocPend
    {
        private string _idEntidad;
        private string _infoEntidad;
        private Interfaces.IZufuLista _lista;
        //
        private usesCase.ICargarCtasPendienteEntidad _cargarCtasPendEntidad;
        private usesCase.IGetItemsCtaPendEntidad _itemsCtaPendEntidad;
        private usesCase.IReporte_CtasPendiente_Entidad _reporteCtasPendEntidad;
        private usesCase.IVisualizarDocumentoEntidad _visualizarDocEntidad;
        //
        public string GetTituloFrm { get { return "Documentos Pendientes Por Pagar"; } }
        public Object GetDataSource { get { return _lista.GetDataSource; } }
        public Object ItemActual { get { return _lista.ItemActual; } }
        public bool AbandonarIsOK { get { return true; } }
        public decimal GetMontoImporte { get { return _getMontoImporte(); } }
        public decimal GetMontoAcumulado { get { return _getMontoAcumulado(); } }
        public decimal GetMontoResta { get { return _getMontoResta(); } } 
        public int GetCantDoc { get { return _lista.GetCntItems; } }
        public string GetNotas { get { return _getNotas(); } }
        public string GetEntidadData{	get { return _infoEntidad; }}
        //
        public HndPanelEntidadDocPend()
        {
            _lista = new hndListaCtasPendEntidad();
            //
            _cargarCtasPendEntidad = new usesCase.UC_CargarCtasPendienteEntidad();
            _itemsCtaPendEntidad = new usesCase.UC_GetItemCtasPendEntidad();
            _reporteCtasPendEntidad = new usesCase.UC_Reporte_CtasPendiente_Entidad();
            _visualizarDocEntidad = new usesCase.UC_VisualizarDocumentoEntidad();
        }
        public void Inicializa()
        {
            _lista.Inicializa();
        }
        vistas.FrmPanelEntidadDocPend frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new vistas.FrmPanelEntidadDocPend();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        public void setIdEntidad(string id)
        {
            _idEntidad= id;
        }
        public void setEntidadInfo(string info)
        {
            _infoEntidad = info;
        }
        //
        public void ReporteDocPend()
        {
            if (_reporteCtasPendEntidad == null) return;
            _reporteCtasPendEntidad.setInfoEntidad(_infoEntidad);
            _reporteCtasPendEntidad.setData(_lista);
            _reporteCtasPendEntidad.Execute();
        }
        public void VisualizarDocumento()
        {
            if (ItemActual != null)
            {
                var _it = (dataItemCtaPendEntidad)ItemActual;
                if (_visualizarDocEntidad == null) return;
                _visualizarDocEntidad.setIdDocVisualizar(_it.Ficha.idDocOrigen);
                _visualizarDocEntidad.Execute();
            }
        }
        public void AbandonarFicha()
        {
        }
        //
        private bool CargarData()
        {
            try
            {
                _cargarCtasPendEntidad.setIdEntidad(_idEntidad);
                _cargarCtasPendEntidad.setListaDestino(_lista);
                _cargarCtasPendEntidad.Execute();
                return true;
            }
            catch (Exception ex)
            {
                Helpers.Msg.Error(ex.Message);
                return false;
            }
        }
        private decimal _getMontoImporte()
        {
            if (_itemsCtaPendEntidad == null) return 0m;
            _itemsCtaPendEntidad.setData(_lista.GetItems);
            return _itemsCtaPendEntidad.GetItems().Sum(s=>s.MontoDeuda);
        }
        private decimal _getMontoAcumulado()
        {
            if (_itemsCtaPendEntidad == null) return 0m;
            _itemsCtaPendEntidad.setData(_lista.GetItems);
            return _itemsCtaPendEntidad.GetItems().Sum(s => s.MontoAcumulado);
        }
        private decimal _getMontoResta()
        {
            if (_itemsCtaPendEntidad == null) return 0m;
            _itemsCtaPendEntidad.setData(_lista.GetItems);
            return _itemsCtaPendEntidad.GetItems().Sum(s => s.MontoPendiente);
        }
        private string _getNotas()
        {
            return  (ItemActual != null) ? ((dataItemCtaPendEntidad)ItemActual).Ficha.notasDoc : "";
        } 
    }
}