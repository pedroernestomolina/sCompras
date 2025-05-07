using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class hndPanel: basePanel, Interfaces.IZufuPanel
    {
        private Interfaces.IZufuPanelAgregarItem _panAgregarItem;
        private Interfaces.IZufuPanelListaItems _panLista;
        //
        public override decimal GetMontoRecibido { get { return _panLista.GetMontoRecibido; } }
        public override int GetCntMetRecibido { get { return _panLista.GetCntItems; } }
        public override IEnumerable<object> GetListaMetPago { get { return null; } }
        public hndPanel()
            : base()
        {
            _panAgregarItem = new hndPanelAgregarItem();
            _panLista = new hndPanelListItems();
        }
        public override void Inicializa()
        {
            _panLista.Inicializa();
        }
        public override void AgregarMetPago()
        {
            _panAgregarItem.Inicializa();
            _panAgregarItem.Inicia();
            if (_panAgregarItem.ProcesarIsOK) 
            {
                _panLista.AdicionarItem(_panAgregarItem.GetItemAgregar);
            }
        }
        public override void ListarMetPago()
        {
            _panLista.Inicia();
        }
        public override void setFactorDivisa(decimal fact)
        {
        }
    }
}