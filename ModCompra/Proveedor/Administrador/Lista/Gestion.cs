using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Administrador.Lista
{
    
    public class Gestion
    {
        
        public event EventHandler ItemChanged;


        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private data _item;


        public BindingSource Source { get { return _bs; } }
        public int Items { get { return _bs.Count; } }
        public data Item { get { return _item; } }
        public string Proveedor 
        {
            get 
            {
                var rt="";
                if (_item != null)
                    rt = _item.Encabezado;
                return rt;
            }
        }


        public Gestion()
        {
            _item = null;
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.CurrentChanged +=_bs_CurrentChanged;   
            _bs.DataSource = _bl;
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            _item = (data)_bs.Current;
            if (_item != null)
            {
                EventHandler hnd = ItemChanged;
                if (hnd != null)
                {
                    hnd(this, null);
                }
            }
        }

        public void setLista(List<OOB.LibCompra.Proveedor.Data.Ficha> list)
        {
            Inicializa();
            foreach (var rg in list.OrderBy(o=>o.nombreRazonSocial).ToList())
            {
                _bl.Add(new data(rg));
            }
        }

        public void LimpiarLista()
        {
            _item = null;
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void AgregarFicha(OOB.LibCompra.Proveedor.Data.Ficha ficha)
        {
            _bl.Add(new data(ficha));
        }

        public void EliminarItem(string autoId)
        {
            var it = _bl.FirstOrDefault(f => f.id == autoId);
            if (it != null) 
            {
                _bl.Remove(it);
            }
        }

        public void Inicializa()
        { 	
            _item = null;
            _bl.Clear();
        }

        public void ActualizarItem(string id, OOB.LibCompra.Proveedor.Data.Ficha ficha)
        {
            var it = _bl.FirstOrDefault(f => f.id == id);
            var idx = _bl.IndexOf(it);
            if (it != null) 
            {
                _bl.Remove(it);
            }
            _bl.Insert(idx,new data(ficha));
        }

    }

}