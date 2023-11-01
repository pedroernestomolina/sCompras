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
        public void AdmDocPagos()
        {
            Helpers.Msg.Alerta("ADM DE DOC DE PAGO");
        }
    }
}
