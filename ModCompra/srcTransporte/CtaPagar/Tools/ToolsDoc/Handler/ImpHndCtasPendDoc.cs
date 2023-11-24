using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Handler
{
    public class ImpHndCtasPendDoc: Vista.IHndCtasPendDoc
    {
        private List<Vista.IdataItemCtaPend> _lst;
        private BindingList<Vista.IdataItemCtaPend> _bl;
        private BindingSource _bs;


        public BindingSource Get_Source { get { return _bs; } }
        public int Get_CntItem { get { return _bs.Count; } }
        public decimal Get_MontoPendiente { get { return _bl.Sum(s=>s.Get_Pendiente); } }
        public object Get_ItemActual { get { return _bs.Current; } }
        public IEnumerable<object> Get_Items { get { return _bl.ToList(); } }


        public ImpHndCtasPendDoc()
        {
            _lst = new List<Vista.IdataItemCtaPend>();
            _bl = new BindingList<Vista.IdataItemCtaPend>(_lst);
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
        public void CargarCtas()
        {
            buscarCtas();
        }

        private void buscarCtas()
        {
            try
            {
                _lst.Clear();
                var r01 = Sistema.MyData.Transporte_CxpDoc_GetLista_DocPend();
                foreach (var rg in r01.Lista.OrderBy(o => o.fechaEmision).ToList()) 
                {
                    var rw= new dataItemCtasPend(rg);
                    _lst.Add(rw);
                }
                _bs.CurrencyManager.Refresh();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}