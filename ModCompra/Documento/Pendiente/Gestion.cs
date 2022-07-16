using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Pendiente
{
    
    public class Gestion
    {

        private data _itemSeleccionado;
        private bool _isItemSeleccionadoOk;
        private List<data> _list;
        private BindingSource _bs;


        public data ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool IsItemSeleccionadoOk { get { return _isItemSeleccionadoOk; } }
        public BindingSource Source { get { return _bs; } }
        public int TItems { get { return _bs.Count; } }


        public Gestion()
        {
            _isItemSeleccionadoOk = false;
            _itemSeleccionado = null;
            _list = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _list;
        }


        ListaFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }
        
        public void setLista(List<OOB.LibCompra.Documento.Pendiente.Lista.Ficha> xlist)
        {
            _list.Clear();
            foreach (var rg in xlist) 
            {
                _list.Add(new data(rg));
            }
            _bs.CurrencyManager.Refresh();
        }

        public void SeleccionarItem()
        {
            var it = (data)_bs.Current;
            if (it != null)
            {
                _itemSeleccionado = it;
                _isItemSeleccionadoOk = true;
            }
        }

        public void Inicializa()
        {
            _isItemSeleccionadoOk = false;
            _itemSeleccionado = null;
            _list.Clear();
        }

    }

}