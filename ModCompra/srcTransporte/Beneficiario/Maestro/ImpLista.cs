using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Beneficiario.Maestro
{
    public class ImpLista: Utils.Maestro.ILista
    {
        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource DataSource_Get { get { return _bs; } }
        public Utils.Maestro.Idata ItemActual { get { return (data)_bs.Current; } }
        public int CntItems_Get { get { return _bs.Count; } }


        public ImpLista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _lst.Clear();
            _bl.Clear();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }

        public void setDataCargar(IEnumerable<Utils.Maestro.Idata> lst)
        {
            _lst.Clear();
            _bl.Clear();
            foreach (var rg in lst)
            {
                _bl.Add((data)rg);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void AgregarItem(Utils.Maestro.Idata ficha)
        {
            _bl.Add((data)ficha);
            _bs.CurrencyManager.Refresh();
        }
        public void RemoverItemBy(Utils.Maestro.Idata ficha)
        {
            var _id = ((data)ficha).Ficha.id;
            var _item = _lst.FirstOrDefault(b => b.Ficha.id == _id);
            if (_item != null)
            {
                _bl.Remove(_item);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}