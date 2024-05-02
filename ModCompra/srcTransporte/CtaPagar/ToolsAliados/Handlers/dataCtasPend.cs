using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Handlers
{
    public class dataCtasPend: Vistas.IdataCtasPend
    {
        private List<Vistas.IdataAliado> _lst;
        private BindingList<Vistas.IdataAliado> _bl;
        private BindingSource _bs;
        private string _textoBuscar;
        //
        public BindingSource GetSource { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }
        public decimal Get_MontoPendiente { get { return _bl.Sum(s=>s.montoResta); } }
        public int Get_CntItem { get { return _bs.Count; } }
        public IEnumerable<object> Get_Items { get { return _bl.ToList(); } }
        public string Get_TextoBuscar { get { return _textoBuscar; } }
        //
        public dataCtasPend()
        {
            _textoBuscar = "";
            _lst = new List<Vistas.IdataAliado>();
            _bl = new BindingList<Vistas.IdataAliado>(_lst);
            _bs = new BindingSource();
            _bs.DataSource=_bl;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _textoBuscar = "";
            _lst.Clear();
            _bl.Clear();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }
        public void setTextoBuscar(string textBuscar)
        {
            _textoBuscar = textBuscar;
        }
        public void CargarCtas()
        {
            _lst.Clear();
            try
            {
                var r01 = Sistema.MyData.Transporte_Aliado_Pediente_GetLista();
                var lst = r01.Lista.OrderBy(o => o.aliadoNombre).ToList();
                if (_textoBuscar.Trim() != "") 
                {
                    lst = lst.Where(w => w.aliadoNombre.Contains(_textoBuscar)).ToList();
                }
                foreach (var rg in lst)
                {
                    var _rg = new dataAliado(rg);
                    _lst.Add(_rg);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
            _bs.CurrencyManager.Refresh();
            _textoBuscar = "";
        }
        public void ActualizarSaldo(Vistas.IdataAliado aliadoCta)
        {
            var item = _lst.FirstOrDefault(f => f.Id == aliadoCta.Id);
            if (item != null) 
            {
                var _ind = _lst.IndexOf(item);
                _lst.Remove(item);
                _lst.Insert(_ind, aliadoCta);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}