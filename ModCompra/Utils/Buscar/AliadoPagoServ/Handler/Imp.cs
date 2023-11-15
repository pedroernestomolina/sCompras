using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Buscar.AliadoPagoServ.Handler
{
    public class Imp : Vista.IHnd
    {
        private List<Vista.Idata> _lst;
        private BindingList<Vista.Idata> _bl;
        private BindingSource _bs;
        private bool _itemSeleccionadoIsOk;
        private data _itemSeleccionado;


        public BindingSource Get_Data { get { return _bs; } }
        public int Get_CntItem { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        public object ItemSeleccionado { get { return _itemSeleccionado; } }


        public Imp()
        {
            _lst = new List<Vista.Idata>();
            _bl = new BindingList<Vista.Idata>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
        }
        public void Inicializa()
        {
            _lst.Clear();
            _bl.Clear();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setDataCargar(IEnumerable<object> lst)
        {
            _lst.Clear();
            _bl.Clear();
            foreach (var rg in ((List<OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha>)lst).OrderBy(o => o.idMov).ToList())
            {
                _lst.Add(new data(rg));
            }
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }
        public void SeleccionarItem()
        {
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
            if (ItemActual != null)
            {
                _itemSeleccionado = (data)ItemActual;
                _itemSeleccionadoIsOk = true;
            }
        }

        public bool AbandonarIsOK { get { return true; } }
        public void AbandonarFicha()
        {
        }


        private bool cargarData()
        {
            return true;
        }
    }
}