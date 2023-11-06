using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoDoc.Handler
{
    public class ImpPagoDoc: Vista.IPagoDoc
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private ToolsDoc.Vista.IdataItemCtaPend _docPagar;
        private Vista.IHndData _hndData;
        private Utils.Componente.CajaMonto.Vista.IHnd _hndCaja;
        private MetodosPago.Principal.Vista.IMetPag _hndMetPag; 


        public Vista.IHndData HndData { get { return _hndData; } }
        public Utils.Componente.CajaMonto.Vista.IHnd HndCaja { get { return _hndCaja; } }
        public MetodosPago.Principal.Vista.IMetPag HndMetPag { get { return _hndMetPag; } }

        
        public ImpPagoDoc()
        {
            _docPagar = null;
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _hndData = new HndData();
            _hndCaja = new Utils.Componente.CajaMonto.Handler.Hnd();
            _hndMetPag = new MetodosPago.Principal.Handler.ImpMetPago();
        }

        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _hndData.Inicializa();
            _hndCaja.Inicializa();
            _hndMetPag.Inicializa();
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


        public void setDocumentoPagar(object doc)
        {
            _docPagar=(ToolsDoc.Vista.IdataItemCtaPend)doc;
        }
        public void ActualizarSaldoCaja()
        {
            _hndMetPag.setMontoPagarDiv(_hndData.Get_MontoPag);
            _hndCaja.setMontoPendDiv(_hndMetPag.Get_ImporteMovCaja);
            _hndCaja.setFactorCambio(_hndData.Get_TasaFactorCambio);
            _hndCaja.ActualizarSaldosPend();
        }

        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = false;
            if (_hndData.ProcesarIsOk())
            {
                if (_hndMetPag.ProcesarIsOk())
                {
                    if (_hndCaja.IsOk())
                    {
                        var rt = Helpers.Msg.Procesar();
                        if (rt)
                        {
                            procesarPago();
                        }
                    }
                }
            }
        }


        private bool cargarData()
        {
            try
            {
                var r00 = Sistema.MyData.FechaServidor();
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r00.Mensaje);
                }
                _hndData.setFechaServidor(r00.Entidad);
                var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r01.Mensaje);
                }
                _hndData.setTasaCambioActual(r01.Entidad);
                var r02 = Sistema.MyData.Transporte_CxpDoc_GetDocPend_ById(_docPagar.Id);
                _hndData.setDocPagar(r02.Entidad);
                //
                _hndCaja.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void procesarPago()
        {
            try
            {
                var _fichaSistDoc= new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "01",
                    TipoDoc = "CXP",
                };
                var _sistDocPag = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //

                var fichaOOB = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Ficha()
                {
                    Recibo = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataRecibo()
                    {
                        autoSistemaDoc = _sistDocPag.Entidad.autoId,
                        codSistemaDoc = _sistDocPag.Entidad.siglas,
                        importeDivisa = _hndData.Get_MontoPag,
                        importeMonAct = _hndData.Get_MontoPagMonAct,
                        montoRecibidoDivisa = _hndData.Get_MontoPag,
                        montoRecibidoMonAct = _hndData.Get_MontoPagMonAct,
                        nota = _hndData.Get_Motivo,
                        prvAuto = _hndData.GetFicha_DocPagar.autoProv,
                        prvCiRif = _hndData.GetFicha_DocPagar.ciRif,
                        prvCodigo = _hndData.GetFicha_DocPagar.codProv,
                        prvDirFiscal = _hndData.GetFicha_DocPagar.dirFiscalPrv,
                        prvNombre = _hndData.GetFicha_DocPagar.nombreRazonSocial,
                        prvTlf = _hndData.GetFicha_DocPagar.telefonoPrv,
                        tasaCambio = _hndData.Get_TasaFactorCambio,
                        usuarioAuto = Sistema.UsuarioP.autoUsu,
                        usuarioNombre = Sistema.UsuarioP.nombreUsu,
                    },
                };
                var lstDoc = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboDoc>();
                var ndoc = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboDoc()
                {
                    autoCxpDoc = _docPagar.Id,
                    codTipoDc = _hndData.GetFicha_DocPagar.tipoDoc,
                    importeDivisa = _hndData.Get_MontoPag,
                    numDoc = _hndData.GetFicha_DocPagar.docNro,
                };
                lstDoc.Add(ndoc);
                fichaOOB.Recibo.reciboDoc = lstDoc;
                //
                var r01 = Sistema.MyData.Transporte_CxpDoc_GestionPago_Agregar(fichaOOB);
                _procesarIsOK = true;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}