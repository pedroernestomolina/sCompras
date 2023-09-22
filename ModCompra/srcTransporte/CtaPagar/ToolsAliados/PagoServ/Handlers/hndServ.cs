using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Handlers
{
    public class hndServ: Vistas.IServ
    {
        private List<Vistas.IdataServ> _lst;
        private BindingList<Vistas.IdataServ> _bl;
        private BindingSource _bs;


        public int Get_CntItem { get { return _bl.Count; } }
        public decimal Get_MontoPendiente { get { return _bl.Sum(s => s.pendiente); } }
        public BindingSource Get_Source { get { return _bs; } }
        public decimal Get_MontoSeleccionadoPagar { get { return _bl.Where(w => w.isSelected).Sum(s => s.pendiente); } }
        public string Get_DescripcionServicioActual { get { return _bs.Current == null ? "" : ((Vistas.IdataServ)_bs.Current).servicio; } }
        public int Get_CntItemSeleccionados { get { return _bl.Where(w => w.isSelected).Count(); } }
        public IEnumerable<object> Get_ListaItemsSeleccionados { get { return _bl.Where(w => w.isSelected).ToList(); } }


        public hndServ()
        {
            _lst = new List<Vistas.IdataServ>();
            _bl = new BindingList<Vistas.IdataServ>(_lst);
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
        public void CargarData()
        {
        }
        public void setDataCargar(List<Vistas.IdataServ> lst)
        {
            _lst.Clear();
            foreach (var rg in lst)
            {
                _lst.Add(rg);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void SeleccionarItem()
        {
            if (_bs.Current != null) 
            {
                var _item = (dataServ)_bs.Current;
                _item.isSelected = !_item.isSelected;
            }
        }
    }
}