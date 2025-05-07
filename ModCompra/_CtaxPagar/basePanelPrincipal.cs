using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar
{
    abstract public class basePanelPrincipal: Interfaces.IPanelPrincipal
    {
        private string _textoBuscar;
        //
        public abstract string GetTituloPanel { get; }
        abstract public object GetItemActual { get; }
        public abstract object GetDataSource { get; } 
        public bool AbandonarFichaIsOK { get { return true; } }
        public abstract decimal GetMontoPendiente { get; }
        abstract public int GetCntItems { get; } 
        public string GetTextoBuscar { get { return _textoBuscar; } }
        //
        public basePanelPrincipal()
        {
            _textoBuscar = "";
        }
        public virtual void Inicializa()
        {
            _textoBuscar = "";
        }
        public abstract void Inicia();
        public void AbandonarFicha()
        {
        }
        public void setTextoBuscar(string texto)
        {
            _textoBuscar = texto;
        }
        abstract public void BuscarCtasPendientes();
        abstract public void Proveedor_CtasPend();
        abstract public void Reporte_CtasPendiente_General();
        abstract public void GestionPago();
    }
}