using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.PanelMetPagoLista.handlers
{
    public class hndPanel: interfaces.IPanel 
    {
        private interfaces.ILista _hndLista;
        private PanelMetPagoAgregar.interfaces.IPanelEditar _editarMetPag;
        //
        public IEnumerable<__.Modelos.PanelMetPagoAgregar.IItemAgregar> GetListaItems { get { return _hndLista.Items; } }
        public object GetDataSource { get { return _hndLista.GetDataSource; } }
        public __.Modelos.PanelMetPagoAgregar.IItemAgregar ItemActual { get { return _hndLista.ItemActual; } }
        public int GetCntItems { get { return _hndLista.GetCntItems; } }
        public decimal GetMontoRecibido { get { return getMontoRecibido(); } }
        public string GetMetodoPagoOp { get { return getMetodoPagoOp(); } }
        public decimal GetMontoOp { get { return getMontoOp(); } }
        public DateTime GetFechaOp { get { return getFechaOp(); } }
        public string GetDetalleOp { get { return getDetalleOp(); } }
        public string GetNroCtaOp { get { return getNroCtaOp(); } }
        public string GetRefOp { get { return getRefOp(); } }
        public string GetBancoOp { get { return getBancoOp(); } }
        public string GetAplicaFactorOp { get { return getAplicaFactorOp(); } }
        //
        public hndPanel()
        {
            _hndLista= new handlers.hndLista();
        }
        public void Inicializa()
        {
            _hndLista.Inicializa();
        }
        vistas.Frm frm;
        public void Inicia()
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
        public void EliminarItem()
        {
            if (ItemActual != null)
            {
                var prc = Helpers.Msg.Procesar("Eliminar Item ?");
                if (prc)
                {
                    _hndLista.EliminarItem(ItemActual);
                }
            }
        }
        public void EditarItem()
        {
            if (ItemActual != null)
            {
                _editarMetPag.Inicializa();
                _editarMetPag.setItemEditar(ItemActual);
                _editarMetPag.Inicia();
                if (_editarMetPag.ProcesarIsOK)
                {
                    _hndLista.EliminarItem(ItemActual);
                    _hndLista.AgregarItem(_editarMetPag.GetItemActualizado);
                }
            }
        }
        public void CargarMetodosPagoRegistrados(IEnumerable<__.Modelos.PanelMetPagoAgregar.IItemAgregar> lista)
        {
            _hndLista.CargarItems(lista);
        }
        public void setHndEditarMetodoPago(PanelMetPagoAgregar.interfaces.IPanelEditar hnd)
        {
            _editarMetPag = hnd;
        }
        //
        private bool cargarData()
        {
            return true;
        }
        private decimal getMontoRecibido()
        {
            var rt = 0m;
            var lst = GetListaItems;
            if (lst != null)
            {
                rt = lst.Sum(s => s.ImporteMonDiv);
                rt = Math.Round(rt, 3, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
        private string getMetodoPagoOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.DescMedioPago ;
            }
            return rt;
        }
        private decimal getMontoOp()
        {
            var rt = 0m;
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.Monto;
            }
            return rt;
        }
        private DateTime getFechaOp()
        {
            var rt = DateTime.Now.Date;
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.FechaOp;
            }
            return rt;
        }
        private string getDetalleOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.DetalleOp;
            }
            return rt;
        }
        private string getNroCtaOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.NroCta;
            }
            return rt;
        }
        private string getRefOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.CheqRefTranf;
            }
            return rt;
        }
        private string getBancoOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = ItemActual;
                rt = it.Banco;
            }
            return rt;
        }
        private string getAplicaFactorOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = ItemActual;
                if (it.AplicaFactor)
                {
                    rt += "Si Aplica, " + Environment.NewLine + "Tasa: " + it.FactorCambio.ToString("n3");
                }
                else
                {
                    rt += "No Aplica," + Environment.NewLine + "Monto en ($)";
                }
            }
            return rt;
        }
    }
}