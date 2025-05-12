using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.__.Handlers
{
    abstract public class baseLista<T>: Interfaces.ILista<T>
    {
        protected List<T> _lst;
        protected BindingList<T> _bl;
        protected BindingSource _bs;
        //
        public object GetDataSource { get { return _bs; } }
        public T ItemActual { get { return (T)_bs.Current; } }
        public IEnumerable<T> Items { get { return _bl.ToList(); } }
        public int GetCntItems { get { return _bl.Count; } }
        //
        public baseLista()
        {
            _lst = new List<T>();
            _bl = new BindingList<T>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            actualizarFuente();
        }
        public void Inicializa()
        {
            _lst.Clear();
            actualizarFuente();
        }
        abstract public void CargarItems(IEnumerable<T> items);
        //
        protected void actualizarFuente()
        {
            _bs.CurrencyManager.Refresh();
        }
    }
}