using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagar
{
    abstract public class baseLista: Interfaces.ILista
    {
        protected BindingSource _bs;
        //
        public int GetCntItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        abstract public IEnumerable<object> GetItems { get; }
        public object GetDataSource { get { return _bs; } }
        //
        public baseLista()
        {
        }
        abstract public void Inicializa();
        abstract public void CargarData(IEnumerable<object> lst);
    }
}