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
        private List<CompAgregarEditarMet.Vista.IHndData> _lst;
        private BindingList<CompAgregarEditarMet.Vista.IHndData> _bl;
        private BindingSource _bs;


        public BindingSource Get_Source { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }
        public decimal Get_Importe { get { return _bl.Sum(s => s.TitImporte); } }
        public decimal Get_ImporteMovCaja { get { return _bl.Where(w => w.Get_AplicaMovCaja).Sum(s => s.TitImporte); } }
        public int Get_CntItems { get { return _bs.Count; } }
        public IEnumerable<object> Get_Lista { get { return _bl.ToList(); } }


        public ImpLista()
        {
            _lst = new List<CompAgregarEditarMet.Vista.IHndData>();
            _bl = new BindingList<CompAgregarEditarMet.Vista.IHndData>(_lst);
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
        public void Agregar(object data)
        {
            var it = (CompAgregarEditarMet.Vista.IHndData)data;
            _bl.Add(it);

        }
        public void EliminarItemActual()
        {
            var it = (CompAgregarEditarMet.Vista.IHndData)_bs.Current;
            _bl.Remove(it);
        }
        public void EliminarItem(object it)
        {
            var _it = (CompAgregarEditarMet.Vista.IHndData)it;
            _bl.Remove(_it);
        }
    }
}