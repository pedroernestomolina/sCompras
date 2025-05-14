using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.modelos
{
    public class MPanel: IMPanel
    {
        private List<IItemDesplegar> _items;
        //
        public IEnumerable<IItemDesplegar> GetItems { get { return _items.AsEnumerable(); } }
        public int GetCntItems { get { return GetItems.Count(); } }
        public decimal GetMontoPendiente { get { return GetItems.Sum(s => s.MontoPendiente); } }
        //
        public MPanel()
        {
            _items = new List<IItemDesplegar>();
        }
        public void Inicializa()
        {
            _items.Clear();
        }
        public void CargarCuentas(IEnumerable<IItemDesplegar> items)
        {
            _items = items.ToList();
        }
    }
}
