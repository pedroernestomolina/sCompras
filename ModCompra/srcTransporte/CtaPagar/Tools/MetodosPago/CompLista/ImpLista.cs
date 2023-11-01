using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompLista
{
    public class ImpLista: ILista
    {
        private List<IitemLista> _lst;
        private BindingList<IitemLista> _bl;
        private BindingSource _bs;

        public BindingSource Get_Source { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }


        public ImpLista()
        {
            _lst = new List<IitemLista>();
            _bl = new BindingList<IitemLista>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _lst.Clear();
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
    }
}
