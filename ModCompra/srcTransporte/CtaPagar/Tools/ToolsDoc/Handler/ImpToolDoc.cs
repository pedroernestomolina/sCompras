using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Handler
{
    public class ImpToolDoc: Vista.IToolDoc 
    {
        private IHndTool _hnd;
        //
        public string TituloTools { get { return "TOOLS PAGO ( DOCUMENTOS )"; } }
        public IHndTool Hnd { get { return _hnd; } }
        public bool AbandonarIsOK { get { return true; } }
        public object CtaPendiente_Actual { get { return _hnd.CtasPendiente.Get_ItemActual; } }
        //
        public ImpToolDoc()
        {
            _hnd = new ImpHndToolDoc();
        }
        public void Inicializa()
        {
            _hnd.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void AbandonarFicha()
        {
        }
        private bool cargarData()
        {
            return true;
        }
        public void PagoPorRetencion()
        {
            if (CtaPendiente_Actual != null) 
            {
                var _ctaPendienteActual = (dataItemCtasPend)CtaPendiente_Actual;
                if (!string.IsNullOrEmpty(_ctaPendienteActual.Ficha.idDocOrigen)) 
                {
                    GenerarPagoPorRetencion(_ctaPendienteActual);
                }
            }
        }
        private PagoPorRetencion.IHnd _pagoPorRet;
        private void GenerarPagoPorRetencion(dataItemCtasPend _ctaPendienteActual)
        {
            if (_pagoPorRet == null) 
            {
                _pagoPorRet = new PagoPorRetencion.ImpHnd();
            }
            _pagoPorRet.Inicializa();
            _pagoPorRet.setDocCompraAplicarPagoPorRet(_ctaPendienteActual.Ficha.idDocOrigen);
            _pagoPorRet.Inicia();
            if (_pagoPorRet.PagoPorRetencionIsOK) 
            {
                _ctaPendienteActual.setActualizaAcumulado(_pagoPorRet.MontoPagoPorRetencion);
            }
        }
        public void VisualizarDoc()
        {
            if (CtaPendiente_Actual != null)
            {
                var _ctaPendienteActual = (dataItemCtasPend)CtaPendiente_Actual;
                var r00 = Sistema.MyData.Permiso_AdmDoc_Visualizar(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    Helpers.VisualizarDocumento.Visualizar(_ctaPendienteActual.Ficha.idDocOrigen);
                }
            }
        }
    }
}