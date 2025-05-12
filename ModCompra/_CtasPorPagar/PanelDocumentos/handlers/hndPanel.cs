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
        //
        public string GetTituloFrm { get { return "Documentos Pendientes Por Pagar"; } }
        public Object GetDataSource { get { return _mDocumentos.GetDataSource; } }
        public __.Modelos.PanelDocumentos.IItemDesplegar ItemActual { get { return _mDocumentos.ItemActual; } }
        public bool AbandonarIsOK { get { return true; } }
        public decimal GetMontoImporte { get { return _mDocumentos.GetMontoImporte; } }
        public decimal GetMontoAcumulado { get { return _mDocumentos.GetMontoAcumulado; } }
        public decimal GetMontoResta { get { return _mDocumentos.GetMontoResta; } }
        public int GetCantDoc { get { return _mDocumentos.GetCantDoc; } }
        public string GetNotasDocumento { get { return ItemActual.docNotas; } }
        public string GetEntidadInfo { get { return _mDocumentos.GetEntidadInfo; } }
        //
        public HndPanel()
        {
            _mDocumentos = new modelos.MDocumentos();
        }
        public void Inicializa()
        {
            _mDocumentos.Inicializa();
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
        }
        //
        public void ReporteDocumentos()
        {
            _mDocumentos.ReporteDocumentos();
        }
        public void VisualizarDocumento()
        {
            if (ItemActual != null)
            {
                _mDocumentos.VisualizarDocumento(ItemActual);
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