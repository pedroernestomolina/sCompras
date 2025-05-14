using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio
{
    abstract public class basePanelPrincipal: _CtasPorPagar.__.Interfaces.PanelPrincipal.IPanel
    {
        private string _textoBuscar;
        protected IMPanel _mPanel;
        //
        public abstract string GetTituloPanel { get; }
        public abstract IItemDesplegar GetItemActual { get; }
        public abstract object GetDataSource { get; } 
        public abstract decimal GetMontoPendiente { get; }
        public abstract  int GetCntItems { get; }
        public bool AbandonarFichaIsOK { get { return true; } }
        public string GetTextoBuscar { get { return _textoBuscar; } }
        public IMPanel MPanel { get { return _mPanel; } }
        //
        public basePanelPrincipal()
        {
        }
        public virtual void Inicializa()
        {
            _textoBuscar = "";
            _mPanel.Inicializa();
        }
        public abstract void Inicia();
        public void AbandonarFicha()
        {
        }
        public void setTextoBuscar(string texto)
        {
            _textoBuscar = texto;
            //MPanel.setTextoBuscar(texto);
        }
        abstract public void BuscarCtasPendientes();
        abstract public void Proveedor_CtasPend();
        abstract public void Reporte_CtasPendiente_General();
        abstract public void GestionPago();
    }
}