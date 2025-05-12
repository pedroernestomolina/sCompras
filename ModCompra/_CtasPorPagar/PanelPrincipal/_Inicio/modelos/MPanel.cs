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
        private string _textoBuscar;
        private IListaDesplegar _listaItemsDesplegar;
        // USESCASE
        private __.UsesCase.PanelPrincipal.ICargarCuentas _cargarCuentas;
        private __.UsesCase.PanelPrincipal.IReporteGeneral _reporteGeneral;
        //
        public string GetTextoBuscar { get { return _textoBuscar; } }
        public IListaDesplegar ListaItemsDesplegar { get { return _listaItemsDesplegar; } }
        public object GetDataSource { get { return _listaItemsDesplegar.GetDataSource; } }
        public IEnumerable<IItemDesplegar> GetItems { get { return _listaItemsDesplegar.Items; } }
        public IItemDesplegar GetItemActual { get { return _listaItemsDesplegar.ItemActual; } }
        public int GetCntItems { get { return GetItems.Count(); } }
        public decimal GetMontoPendiente { get { return GetItems.Sum(s => s.MontoPendiente); } }
        //
        public MPanel()
        {
            _textoBuscar = "";
            _listaItemsDesplegar = new ListaDesplegar(); 
            _cargarCuentas = new usesCase.uc_CargarCtas();
            _reporteGeneral = new usesCase.uc_ReporteGeneral();
        }
        public void Inicializa()
        {
            _textoBuscar = "";
            _listaItemsDesplegar.Inicializa();
        }
        //
        public void setTextoBuscar(string texto)
        {
            _textoBuscar = texto.Trim().ToUpper();
        }
        //
        public void CargarCuentas()
        {
            var _filtro = new FiltroBusqueda()
            {
                 TextoBuscar= GetTextoBuscar,
            };
            _cargarCuentas.setFiltro(_filtro);
            _listaItemsDesplegar.CargarItems(_cargarCuentas.Execute().AsEnumerable());
        }
        public void ReporteGeneral()
        {
            _reporteGeneral.setData(GetItems);
            _reporteGeneral.Execute();
        }
    }
}
