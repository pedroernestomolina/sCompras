using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class hndListaItems: _CtaxPagar.baseLista, Interfaces.IZufuListaItems
    {
        private BindingList<_CtaxPagarPago_MetodosPago.Interfaces.IItem> _bl;
        //
        public override IEnumerable<object> GetItems { get { return _bl.ToList(); } }
        //
        public hndListaItems()
            : base()
        {
            _bl = new BindingList<_CtaxPagarPago_MetodosPago.Interfaces.IItem>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }
        public override void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void AgregarItem(object item)
        {
            _bl.Add((_CtaxPagarPago_MetodosPago.Interfaces.IItem)item);
        }
        public void EliminarItem(object item)
        {
            if (ItemActual != null)
            {
                _bl.Remove((_CtaxPagarPago_MetodosPago.Interfaces.IItem) item);
                _bs.CurrencyManager.Refresh();
            }
        }
        public override void CargarData(IEnumerable<object> lst)
        {
        }
    }
}