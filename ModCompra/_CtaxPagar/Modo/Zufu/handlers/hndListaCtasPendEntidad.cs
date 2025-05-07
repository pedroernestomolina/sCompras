using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagar.Modo.Zufu.handlers
{
    public class hndListaCtasPendEntidad: baseLista, Interfaces.IZufuLista
    {
        private BindingList<_CtaxPagar.Interfaces.IdataItemCtaPendEntidad> _bl;
        //
        public override IEnumerable<object> GetItems { get { return _bl.ToList(); } }
        //
        public hndListaCtasPendEntidad()
            :base()
        {
            _bl = new BindingList<_CtaxPagar.Interfaces.IdataItemCtaPendEntidad>();
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
                _bl.Add((dataItemCtaPendEntidad)rg);
            }

            _bs.CurrencyManager.Refresh();
        }
    }
}