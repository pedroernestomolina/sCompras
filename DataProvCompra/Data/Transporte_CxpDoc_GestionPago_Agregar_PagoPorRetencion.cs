using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv : IData
    {
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado> 
            Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Ficha ficha)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado>(); 
            //
            var _documentos = ficha.Documentos.Select(s =>
            {
                var _ret = s.cxpRetencion;
                var _retRec= s.cxpReciboRetencion;
                var _doc = new DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencion()
                {
                    MontoBase1 = s.MontoBase1,
                    MontoBase2 = s.MontoBase2,
                    MontoBase3 = s.MontoBase3,
                    MontoExento = s.MontoExento,
                    MontoImpuesto1 = s.MontoImpuesto1,
                    MontoImpuesto2 = s.MontoImpuesto2,
                    MontoImpuesto3 = s.MontoImpuesto3,
                    MontoRetencion = s.MontoRetencion,
                    MontoTotal = s.MontoTotal,
                    PrvAuto = s.PrvAuto,
                    PrvCiRif = s.PrvCiRif,
                    PrvCodigo = s.PrvCodigo,
                    PrvDirFiscal = s.PrvDirFiscal,
                    PrvNombre = s.PrvNombre,
                    retMonto = s.retMonto,
                    retSustraendo = s.retSustraendo,
                    SistDocAuto = s.SistDocAuto,
                    SistDocCodigo = s.SistDocCodigo,
                    SistDocNombre = s.SistDocNombre,
                    TasaRetencion = s.TasaRetencion,
                    EsIva = s.EsIva,
                    docRetDetalle = s.docRetDetalle.Select(ss =>
                    {
                        var _docDet = new DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencionDet()
                        {
                            base1 = ss.base1,
                            base2 = ss.base2,
                            base3 = ss.base3,
                            ciRifDocRefRet = ss.ciRifDocRefRet,
                            fechaDocRefRet = ss.fechaDocRefRet,
                            impuesto1 = ss.impuesto1,
                            impuesto2 = ss.impuesto2,
                            impuesto3 = ss.impuesto3,
                            montoBase = ss.montoBase,
                            montoExento = ss.montoExento,
                            montoImpuesto = ss.montoImpuesto,
                            montoRetencion = ss.montoRetencion,
                            montoTotal = ss.montoTotal,
                            numAplicaDocRefRet = ss.numAplicaDocRefRet,
                            numControlDocRefRet = ss.numControlDocRefRet,
                            numDocRefRet = ss.numDocRefRet,
                            retIva1 = ss.retIva1,
                            retIva2 = ss.retIva2,
                            retIva3 = ss.retIva3,
                            sistAutoDocRet = ss.sistAutoDocRet,
                            sistSignoDocRet = ss.sistSignoDocRet,
                            sistTipoDocRefRet = ss.sistTipoDocRefRet,
                            sistTipoDocRet = ss.sistTipoDocRet,
                            sustraendoRetencion = ss.sustraendoRetencion,
                            tasa1 = ss.tasa1,
                            tasa2 = ss.tasa2,
                            tasa3 = ss.tasa3,
                            tasaRetencion = ss.tasaRetencion,
                            totalRetencion = ss.totalRetencion,
                        };
                        return _docDet;
                    }).ToList(),
                    cxpRetencion = new DtoLibTransporte.Documento.Agregar.CompraGasto.CxP()
                    {
                        acumulado = _ret.acumulado,
                        acumuladoDivisa = _ret.acumuladoDivisa,
                        autoProveedor = _ret.autoProveedor,
                        autoSistemaDoc = _ret.autoSistemaDoc,
                        ciRifProveedor = _ret.ciRifProveedor,
                        codigoProveedor = _ret.codigoProveedor,
                        diasCredito = _ret.diasCredito,
                        documentoNro = _ret.documentoNro,
                        fechaEmision = _ret.fechaEmision,
                        fechaVencimiento = _ret.fechaVencimiento,
                        importe = _ret.importe,
                        importeDivisa = _ret.importeDivisa,
                        nombreRazonSocialProveedor = _ret.nombreRazonSocialProveedor,
                        notas = _ret.notas,
                        resta = _ret.resta,
                        restaDivisa = _ret.restaDivisa,
                        siglasTipoDocumento = _ret.siglasTipoDocumento,
                        signoTipoDocumento = _ret.signoTipoDocumento,
                        tasaDivisa = _ret.tasaDivisa,
                    },
                    cxpReciboRetencion = new DtoLibTransporte.Documento.Agregar.CompraGasto.Recibo()
                    {
                        autoSistemaDoc = _retRec.autoSistemaDoc,
                        documento = _retRec.documento,
                        importe = _retRec.importe,
                        importeDivisa = _retRec.importeDivisa,
                        montoRecibido = _retRec.montoRecibido,
                        montoRecibidoDivisa = _retRec.montoRecibidoDivisa,
                        nota = _retRec.nota,
                        prvAuto = _retRec.prvAuto,
                        prvCiRif = _retRec.prvCiRif,
                        prvCodigo = _retRec.prvCodigo,
                        prvDirFiscal = _retRec.prvDirFiscal,
                        prvNombre = _retRec.prvNombre,
                        prvTlf = _retRec.prvTlf,
                        tasaCambio = _retRec.tasaCambio,
                        usuarioAuto = _retRec.usuarioAuto,
                        usuarioNombre = _retRec.usuarioNombre,
                        docRecibo = _retRec.docRecibo.Select(sss => 
                        {
                            var _rec = new DtoLibTransporte.Documento.Agregar.CompraGasto.ReciboDoc()
                            {
                                importe = sss.importe,
                                numDocumentoAfecta = sss.numDocumentoAfecta,
                                siglasDocumentoAfecta = sss.siglasDocumentoAfecta,
                                tipoOperacionRealizar = sss.tipoOperacionRealizar,
                            };
                            return _rec;
                        }).ToList(),
                    },
                };
                return _doc;
            }).ToList();
            var fichaDTO = new DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Ficha()
            {
                autoEntCompra = ficha.autoEntCompra,
                autoEntCxP = ficha.autoEntCxP,
                Documentos = _documentos,
            };
            var r01 = MyData.Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado()
            {
                autoRetISLR = r01.Entidad.autoRetISLR,
                autoRetIva = r01.Entidad.autoRetIva,
            };
            //
            return result;
        }
    }
}