using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Buscar.Proveedor.Handler
{
    public class ImpLista: Vistas.ILista
    {
        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private bool _itemSeleccionadoIsOk;


        public BindingSource Get_Data { get { return _bs; } }
        public int Get_CntItem { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        public object ItemSeleccionado { get { return (data)_bs.Current; } }


        public ImpLista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
            _itemSeleccionadoIsOk=false;
        }
        public void setDataCargar(IEnumerable<object> lst)
        {
            _lst.Clear();
            _bl.Clear();
            foreach (var rg in ((List<OOB.LibCompra.Proveedor.Data.Ficha>)lst).OrderBy(o=>o.nombreRazonSocial).ToList()) 
            {
                _lst.Add(new data(rg));
            }
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _lst.Clear();
            _bl.Clear();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
            _itemSeleccionadoIsOk=false;
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool cargarData()
        {
            return true;
        }
        public void SeleccionarItem()
        {
            _itemSeleccionadoIsOk=false;
            if (ItemActual != null) 
            {
                var item  = (data)ItemActual;
                if (!item.Ficha.IsActivo) 
                {
                    Helpers.Msg.Alerta("PROVEEDOR [ ESTATUS ] INCORRECTO");
                }
                _itemSeleccionadoIsOk = true;
            }
        }
    }
}
