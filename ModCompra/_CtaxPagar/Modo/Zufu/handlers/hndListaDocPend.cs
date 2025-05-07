using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagar.Modo.Zufu.handlers
{
    public class hndListaDocPend: baseLista, Interfaces.IZufuLista
    {
        private BindingList<_CtaxPagar.Interfaces.IdataItemDocPend> _bl;
        //
        public override IEnumerable<object> GetItems { get { return _bl.ToList(); } }
        //
        public hndListaDocPend()
            :base()
        {
            _bl = new BindingList<_CtaxPagar.Interfaces.IdataItemDocPend>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }
        public override void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public override void CargarData(IEnumerable<object> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                _bl.Add((dataItemDocPend)rg);
            }

            _bs.CurrencyManager.Refresh();
        }
    }
}