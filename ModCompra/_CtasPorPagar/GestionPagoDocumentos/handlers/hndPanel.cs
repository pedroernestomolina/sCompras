using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.GestionPagoDocumentos.handlers
{
    public class HndPanel: interfaces.IPanel
    {
        private string _tituloPanel;
        private __.Modelos.GestionPagoDocumentos.IModelo _modelo;
        private __.Interfaces.PanelGestionPagoDocumentos.IListaDesplegar _hndListaDesplegar;
        private __.Interfaces.PanelAbonarPago.IPanel _hndAbonarPago;
        // USES CASE
        private __.UsesCase.PanelDocumentos.IVisualizarDoc _visualizarDoc;
        //
        public __.Interfaces.PanelGestionPagoDocumentos.IListaDesplegar ListaDesplegar { get { return _hndListaDesplegar; } }
        public string GetTituloFrm { get { return _tituloPanel; } }
        public bool AbandonarIsOK { get { return true; } }
        public int GetCntDocPendiente { get { return _modelo.GetCantDocPend; } }
        public decimal GetMontoPendiente { get { return _modelo.GetMontoPend; } }
        public decimal GetMontoAbonado { get { return _modelo.GetMontoAbonado; } }
        public int GetCntDocAbonado { get { return _modelo.GetCantDocAbonado; } }
        public string GetNotasAbono { get { return ItemActual != null ? ItemActual.NotasDelAbono : ""; } }
        public string GetEntidadInfo { get { return _modelo.GetEntidadInfo; } }
        public Object GetDataSource { get { return _hndListaDesplegar.GetDataSource; } } 
        public __.Modelos.GestionPagoDocumentos.IItemDesplegar ItemActual { get { return _hndListaDesplegar.ItemActual; } } 
        //
        public HndPanel()
        {
            _modelo = new modelos.Modelo();
            _hndListaDesplegar = new hndListaIDesplegar();
            _visualizarDoc = new PanelDocumentos.usesCase.uc_VisualizarDoc();
        }
        public void Inicializa()
        {
            _modelo.Inicializa();
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
        public void setTituloPanel(string titulo)
        {
            _tituloPanel = titulo;
        }
        public void setDataCargar(string p, IEnumerable<__.Modelos.GestionPago.IDoc> doc)
        {
            _modelo.setDataCargar(p, doc);
            _hndListaDesplegar.CargarItems(_modelo.GetItems);
        }
        //
        public void AbonarCta()
        {
            if (_hndAbonarPago == null)
            {
                _hndAbonarPago = new PanelAbonarPago.handlers.hndPanel();
            }
            _hndAbonarPago.Inicializa();
            _hndAbonarPago.setItemCargar(ItemActual);
            _hndAbonarPago.Inicia();
            _hndListaDesplegar.ActualizarFuente();
        }
        public void VisualizarDocumento()
        {
            if (ItemActual != null)
            {
                _visualizarDoc.setIdDocVisualizar(ItemActual.docId);
                _visualizarDoc.Execute();
            }
        }
        public void LimpiarAbonos()
        {
            if (Helpers.Msg.Procesar("Eliminar/Limpiar Abonos Realizados ?"))
            {
                _modelo.LimpiarAbonos();
            }
            _hndListaDesplegar.ActualizarFuente();
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