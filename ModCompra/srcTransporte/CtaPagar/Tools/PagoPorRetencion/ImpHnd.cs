using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoPorRetencion
{
    public class ImpHnd : IHnd
    {
        private Utils.Control.Boton.Abandonar.IAbandonar _btAbandonar;
        private Utils.Control.Boton.Procesar.IProcesar _btProcesar;
        private string _idDocCompra;
        private OOB.LibCompra.Documento.GetData.AplicarRetencion.Ficha _docOrigen;
        private OOB.LibCompra.SistemaDocumento.Entidad.Ficha _sistemaDoc_Iva;
        private OOB.LibCompra.SistemaDocumento.Entidad.Ficha _sistemaDoc_Islr;
        //
        public Utils.Control.Boton.Abandonar.IAbandonar BtAbandonar { get { return _btAbandonar; } }
        public Utils.Control.Boton.Procesar.IProcesar BtProcesar { get { return _btProcesar; } }
        //
        public ImpHnd()
        {
            _idDocCompra = "";
            _docOrigen = null;
            _sistemaDoc_Islr = null;
            _sistemaDoc_Iva = null;
            _btAbandonar = new Utils.Control.Boton.Abandonar.Imp();
            _btProcesar = new Utils.Control.Boton.Procesar.Imp();
        }
        public void Inicializa()
        {
            _idDocCompra = "";
            _docOrigen = null;
            _sistemaDoc_Islr = null;
            _sistemaDoc_Iva = null;
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
        }
        public void Inicia()
        {
            if (cargarData())
            {
                procesarPagoPorRetencion();
            }
        }
        public void setDocCompraAplicarPagoPorRet(string idDocCompra)
        {
            _idDocCompra = idDocCompra;
        }
        //
        private bool cargarData()
        {
            try
            {
                if (_idDocCompra.Trim() == "") { throw new Exception("ID DOCUMENTO DE COMPRA NO SELECCIONADO"); }
                var rt = Sistema.MyData.Compra_GetData_AplicarRetencion(_idDocCompra);
                if (rt.Entidad == null)
                {
                    throw new Exception("DOCUMENTO NO APLICA PARA EL LIBRO DE SENIAT");
                }
                _docOrigen = rt.Entidad;
                if (!_docOrigen.AplicaLibroSeniat)
                {
                    throw new Exception("DOCUMENTO NO APLICA PARA EL LIBRO DE SENIAT");
                }
                if (
                    _docOrigen.GetTipoDocumentoCompra == OOB.LibCompra.Documento.GetData.AplicarRetencion.TipoDocumentoCompra.SinDefinir ||
                    _docOrigen.GetTipoDocumentoCompra == OOB.LibCompra.Documento.GetData.AplicarRetencion.TipoDocumentoCompra.Otro
                    )
                {
                    throw new Exception("TIPO DOCUMENTO INCORRECTO");
                }
                if (
                    _docOrigen.AplicaRetencionIva ||
                    _docOrigen.AplicaRetencionISLR)
                {
                    throw new Exception("TIPO DOCUMENTO YA SE APLICO ALGUN TIPO DE RETENCION");
                }
                //
                var sistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "07",
                    TipoDoc = "Compras",
                };
                var rt_02 = Sistema.MyData.SistemaDocumento_Get(sistDoc);
                if (rt_02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt_02.Mensaje);
                }
                _sistemaDoc_Iva = rt_02.Entidad;
                //
                sistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "08",
                    TipoDoc = "Compras",
                };
                var rt_03 = Sistema.MyData.SistemaDocumento_Get(sistDoc);
                if (rt_03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt_03.Mensaje);
                }
                _sistemaDoc_Islr = rt_03.Entidad;

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void procesarPagoPorRetencion()
        {
            try
            {
                var _esPorIva=true;
                var _tasaRetIva = 75m;
                var _montoRetencionIva = (_docOrigen.montoImpuesto * _tasaRetIva /100m);
                var _montoRetencionIvaDivisa = _montoRetencionIva/_docOrigen.factorCambio; 
                var _retencionIva_1 = _docOrigen.montoIva1 * _tasaRetIva/100m;
                var _retencionIva_2 = _docOrigen.montoIva2 * _tasaRetIva/100m;
                var _retencionIva_3 = _docOrigen.montoIva3 * _tasaRetIva/100m;
                _montoRetencionIva = Math.Round(_montoRetencionIva, 2, MidpointRounding.AwayFromZero);
                _montoRetencionIvaDivisa= Math.Round(_montoRetencionIvaDivisa, 2, MidpointRounding.AwayFromZero);
                _retencionIva_1 = Math.Round(_retencionIva_1, 2, MidpointRounding.AwayFromZero);
                _retencionIva_2 = Math.Round(_retencionIva_2, 2, MidpointRounding.AwayFromZero);
                _retencionIva_3 = Math.Round(_retencionIva_3, 2, MidpointRounding.AwayFromZero);
                var _documentos = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.DocRetencion>();
                if (_esPorIva)
                {
                    var _nota = "RETENCION IVA " + _tasaRetIva.ToString() + "%, DOC: " + _docOrigen.documentoNro;
                    var _det = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.DocRetencionDet()
                    {
                        base1 = _docOrigen.montoBase1,
                        base2 = _docOrigen.montoBase2,
                        base3 = _docOrigen.montoBase3,
                        ciRifDocRefRet = _docOrigen.provCiRif,
                        fechaDocRefRet = _docOrigen.fechaEmision,
                        impuesto1 = _docOrigen.montoIva1,
                        impuesto2 = _docOrigen.montoIva2,
                        impuesto3 = _docOrigen.montoIva3,
                        montoBase = _docOrigen.montoBase,
                        montoExento = _docOrigen.montoExento,
                        montoImpuesto = _docOrigen.montoImpuesto,
                        montoRetencion = _montoRetencionIva,
                        montoTotal = _docOrigen.montoTotal,
                        numAplicaDocRefRet = "",
                        numControlDocRefRet = _docOrigen.controlNro,
                        numDocRefRet = _docOrigen.documentoNro,
                        retIva1 = _retencionIva_1,
                        retIva2 = _retencionIva_2,
                        retIva3 = _retencionIva_3,
                        sistAutoDocRet = _sistemaDoc_Iva.autoId,
                        sistSignoDocRet = _sistemaDoc_Iva.signo,
                        sistTipoDocRefRet = "",
                        sistTipoDocRet = _sistemaDoc_Iva.tipo,
                        sustraendoRetencion = 0m,
                        tasa1 = _docOrigen.tasaIva1,
                        tasa2 = _docOrigen.tasaIva2,
                        tasa3 = _docOrigen.tasaIva3,
                        tasaRetencion = _tasaRetIva,
                        totalRetencion = _montoRetencionIva,
                    };
                    var _detalles = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.DocRetencionDet>();
                    _detalles.Add(_det);
                    var _docIva = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.DocRetencion()
                    {
                        EsIva = true,
                        MontoBase1 = _docOrigen.montoBase1,
                        MontoBase2 = _docOrigen.montoBase2,
                        MontoBase3 = _docOrigen.montoBase3,
                        MontoExento = _docOrigen.montoExento,
                        MontoImpuesto1 = _docOrigen.montoIva1,
                        MontoImpuesto2 = _docOrigen.montoIva2,
                        MontoImpuesto3 = _docOrigen.montoIva3,
                        MontoRetencion = _montoRetencionIva,
                        MontoTotal = _docOrigen.montoTotal,
                        PrvAuto = _docOrigen.provAuto,
                        PrvCiRif = _docOrigen.provCiRif,
                        PrvCodigo = _docOrigen.provCodigo,
                        PrvDirFiscal = _docOrigen.provDirFiscal,
                        PrvNombre = _docOrigen.provNombre,
                        retMonto = 0m,
                        retSustraendo = 0m,
                        SistDocAuto = _sistemaDoc_Iva.autoId,
                        SistDocCodigo = _sistemaDoc_Iva.codigo,
                        SistDocNombre = _sistemaDoc_Iva.nombre,
                        TasaRetencion = _tasaRetIva,
                        docRetDetalle = _detalles,
                        cxpRetencion = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.CxP()
                        {
                            acumulado = 0m,
                            autoProveedor = _docOrigen.provAuto,
                            acumuladoDivisa = 0m,
                            autoSistemaDoc = _sistemaDoc_Iva.autoId,
                            ciRifProveedor = _docOrigen.provCiRif,
                            codigoProveedor = _docOrigen.provCodigo,
                            diasCredito = 0,
                            documentoNro = _docOrigen.documentoNro,
                            fechaEmision = _docOrigen.fechaEmision,
                            fechaVencimiento = _docOrigen.fechaVencimiento,
                            importe = _montoRetencionIva,
                            importeDivisa = _montoRetencionIvaDivisa,
                            nombreRazonSocialProveedor = _docOrigen.provNombre,
                            notas = _nota,
                            resta = 0m,
                            restaDivisa = 0m,
                            siglasTipoDocumento = _sistemaDoc_Iva.siglas,
                            signoTipoDocumento = -1,
                            tasaDivisa = _docOrigen.factorCambio,
                        },
                        cxpReciboRetencion = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Recibo()
                        {
                            autoSistemaDoc = _sistemaDoc_Iva.autoId,
                            documento = _sistemaDoc_Iva.siglas,
                            importe = _montoRetencionIva,
                            importeDivisa = _montoRetencionIvaDivisa,
                            montoRecibido = _montoRetencionIva,
                            montoRecibidoDivisa = _montoRetencionIvaDivisa,
                            nota = _nota,
                            prvAuto = _docOrigen.provAuto,
                            prvCiRif = _docOrigen.provCiRif,
                            prvCodigo = _docOrigen.provCodigo,
                            prvDirFiscal = _docOrigen.provDirFiscal,
                            prvNombre = _docOrigen.provNombre,
                            prvTlf = _docOrigen.provTelefono,
                            tasaCambio = _docOrigen.factorCambio,
                            usuarioAuto = Sistema.UsuarioP.autoUsu,
                            usuarioNombre = Sistema.UsuarioP.nombreUsu,
                            docRecibo = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.ReciboDoc>(),
                        },
                    };
                    _documentos.Add(_docIva);
                }
                var fichaOOB = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Ficha()
                {
                    autoEntCompra = _docOrigen.autoId,
                    autoEntCxP = _docOrigen.idDocCxp,
                    Documentos = _documentos,
                };
                var rt = Sistema.MyData.Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(fichaOOB);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}