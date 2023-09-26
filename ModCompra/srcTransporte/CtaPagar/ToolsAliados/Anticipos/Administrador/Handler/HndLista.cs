using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Administrador.Handler
{
    public class HndLista: Vistas.IListaAnticipo
    {
        private List<dataItem> _lst;
        private BindingList<dataItem> _bl;
        private BindingSource _bs;


        public BindingSource Get_Source { get { return _bs; } }
        public int Get_CntItem { get { return _bs.Count; } }


        public HndLista()
        {
            _lst = new List<dataItem>();
            _bl = new BindingList<dataItem>(_lst);
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
    }
}