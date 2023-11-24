using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Handler
{
    public class ImpHndToolDoc: Vista.IHndToolDoc 
    {
        private IHndCtasPend _ctasPend;
        private PagoDoc.Vista.IPagoDoc _gPago;


        public IHndCtasPend CtasPendiente { get { return _ctasPend; } }


        public ImpHndToolDoc()
        {
            _ctasPend = new ImpHndCtasPendDoc();
            _gPago = new PagoDoc.Handler.ImpPagoDoc();
        }
        public void Inicializa()
        {
            _ctasPend.Inicializa();
        }
        public void GestionPago()
        {
            if (_ctasPend.Get_ItemActual ==null)
            {
                return;
            }
            _gPago.Inicializa();
            _gPago.setDocumentoPagar(_ctasPend.Get_ItemActual);
            _gPago.Inicia();
        }
        private Administrador.Vistas.IAdm _adm;
        public void AdmDocPagos()
        {
            if (_adm == null) 
            {
                _adm = new Administrador.Handler.Imp();
            }
            _adm.Inicializa();
            _adm.Inicia();
        }
        public void ImprimirLista()
        {
            if (_ctasPend.Get_CntItem > 0)
            {
                var _items = _ctasPend.Get_Items;
                srcTransporte.Reportes.IRepListAdm _rep = new srcTransporte.Reportes.ListaAdm.ToolsPagoDoc.Imp();
                _rep.setFiltrosBusq("");
                _rep.setDataCargar(_items);
                _rep.Generar();
            }
        }
    }
}
