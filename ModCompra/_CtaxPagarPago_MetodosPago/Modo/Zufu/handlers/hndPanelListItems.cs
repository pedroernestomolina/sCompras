using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class hndPanelListItems : Interfaces.IZufuPanelListaItems
    {
        private Interfaces.IZufuListaItems _listaItems;
        private Interfaces.IZufuPanelEditarItem _editarMetPag;
        private usesCase.IGetItems _getItems;
        //
        public IEnumerable<_CtaxPagarPago_MetodosPago.Interfaces.IItem> GetItems { get { return getItems(); } }
        public object GetDataSource { get { return _listaItems.GetDataSource; } }
        public object ItemActual { get { return _listaItems.ItemActual; } }
        public int GetCntItems { get { return _listaItems.GetCntItems; } }
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
        public hndPanelListItems()
        {
            _listaItems = new hndListaItems();
            _editarMetPag = new hndPanelEditarItem();
            _getItems = new usesCase.UC_GetItems();
        }
        public void Inicializa()
        {
            _listaItems.Inicializa();
        }
        vistas.FrmLista frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new vistas.FrmLista();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void AdicionarItem(object item)
        {
            _listaItems.AgregarItem(item);
        }
        public void EliminarItem()
        {
            if (ItemActual != null)
            {
                var prc = Helpers.Msg.Procesar("Eliminar Item ?");
                if (prc)
                {
                    _listaItems.EliminarItem(ItemActual);
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
                    _listaItems.EliminarItem(ItemActual);
                    _listaItems.AgregarItem(_editarMetPag.GetItemActualizado);
                }
            }
        }
        //
        private bool cargarData()
        {
            return true;
        }
        private string strToDec(decimal mont)
        {
            return mont.ToString("n2");
        }
        private string strToInt(int cnt)
        {
            return cnt.ToString();
        }
        //
        private IEnumerable<_CtaxPagarPago_MetodosPago.Interfaces.IItem> getItems()
        {
            _getItems.setLista(_listaItems.GetItems);
            return _getItems.Execute();
        }
        private decimal getMontoRecibido()
        {
            var rt = 0m;
            var lst = getItems();
            if (lst!=null)
            {
                rt =lst.Sum(s => s.ImporteMonDiv);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
        private string getMetodoPagoOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.MedioPago.desc;
            }
            return rt;
        }
        private decimal getMontoOp()
        {
            var rt = 0m;
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.Monto;
            }
            return rt;
        }
        private DateTime getFechaOp()
        {
            var rt = DateTime.Now.Date;
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.FechaOp;
            }
            return rt;
        }
        private string getDetalleOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.DetalleOp;
            }
            return rt;
        }
        private string getNroCtaOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.NroCta;
            }
            return rt;
        }
        private string getRefOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.CheqRefTranf;
            }
            return rt;
        }
        private string getBancoOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                rt = it.Banco;
            }
            return rt;
        }
        private string getAplicaFactorOp()
        {
            var rt = "";
            if (ItemActual != null)
            {
                var it = (item)ItemActual;
                if (it.AplicaFactor)
                {
                    rt += "Si Aplica, " + Environment.NewLine + "Tasa: " + it.FactorCambio.ToString("n2");
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