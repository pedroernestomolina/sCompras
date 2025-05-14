using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.PanelDocumentos.handlers
{
    public class HndPanel: interfaces.IPanel
    {
        private __.Modelos.PanelDocumentos.IMDocumentos _mDocumentos;
        private __.Interfaces.PanelDocumentos.IListaDesplegar _hndListaDesplegar;
        // USES CASE
        private __.UsesCase.PanelDocumentos.IReporteDoc _repDoc;
        private __.UsesCase.PanelDocumentos.IVisualizarDoc _visualizarDoc;
        //
        public __.Interfaces.PanelDocumentos.IListaDesplegar ListaDesplegar { get { return _hndListaDesplegar; } }
        public string GetTituloFrm { get { return "Documentos Pendientes Por Pagar"; } }
        public bool AbandonarIsOK { get { return true; } }
        public decimal GetMontoImporte { get { return _mDocumentos.GetMontoImporte; } }
        public decimal GetMontoAcumulado { get { return _mDocumentos.GetMontoAcumulado; } }
        public decimal GetMontoResta { get { return _mDocumentos.GetMontoResta; } }
        public int GetCantDoc { get { return _mDocumentos.GetCantDoc; } }
        public string GetNotasDocumento { get { return ItemActual.docNotas; } }
        public string GetEntidadInfo { get { return _mDocumentos.GetEntidadInfo; } }
        public Object GetDataSource { get { return _hndListaDesplegar.GetDataSource; } } 
        public __.Modelos.PanelDocumentos.IItemDesplegar ItemActual { get { return _hndListaDesplegar.ItemActual; } } 
        //
        public HndPanel()
        {
            _mDocumentos = new modelos.MDocumentos();
            _hndListaDesplegar = new hndListaIDesplegar();
            _repDoc = new usesCase.uc_ReporteDoc();
            _visualizarDoc = new usesCase.uc_VisualizarDoc();
        }
        public void Inicializa()
        {
            _mDocumentos.Inicializa();
            _hndListaDesplegar.Inicializa();
        }
        vistas.Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        public void setItemCargar(IItemDesplegar item)
        {
            _mDocumentos.setItemCargar(item);
            _hndListaDesplegar.CargarItems(_mDocumentos.GetItems);
        }
        //
        public void ReporteDocumentos()
        {
            _repDoc.setInfoEntidad(_mDocumentos.GetEntidadInfo);
            _repDoc.setData(_mDocumentos.GetItems);
            _repDoc.Execute();
        }
        public void VisualizarDocumento()
        {
            if (ItemActual != null)
            {
                _visualizarDoc.setIdDocVisualizar(ItemActual.docId);
                _visualizarDoc.Execute();
            }
        }
        public void AbandonarFicha()
        {
        }
        //
        private bool CargarData()
        {
            return true;
        }
    }
}