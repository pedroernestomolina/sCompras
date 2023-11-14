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
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado>
            Transporte_Documento_Agregar_CompraGrasto(OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Ficha ficha)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado>();
            var fichaDTO = new DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha();
            var doc = ficha.documento;
            var documento = new DtoLibTransporte.Documento.Agregar.CompraGasto.Documento()
            {
                aplicaCodTipoDoc = doc.aplicaCodTipoDoc,
                aplicaFechaDoc = doc.aplicaFechaDoc,
                aplicaNumeroDoc = doc.aplicaNumeroDoc,
                autoProv = doc.autoProv,
                autoSucursal = doc.autoSucursal,
                autoUsuario = doc.autoUsuario,
                ciRifProv = doc.ciRifProv,
                codicionPagoDoc = doc.codicionPagoDoc,
                codigoComprasConcepto = doc.codigoComprasConcepto,
                codigoProv = doc.codigoProv,
                codigoSucursal = doc.codigoSucursal,
                codigoUsuario = doc.codigoUsuario,
                codTipoDoc = doc.codTipoDoc,
                descComprasConcepto = doc.descComprasConcepto,
                descSucursal = doc.descSucursal,
                diasCreditoDoc = doc.diasCreditoDoc,
                dirFiscalProv = doc.dirFiscalProv,
                estatusFiscal = doc.estatusFiscal,
                fechaEmisDoc = doc.fechaEmisDoc,
                fechaVencDoc = doc.fechaVencDoc,
                idComprasConcepto = doc.idComprasConcepto,
                moduloDoc = doc.moduloDoc,
                nombreDoc = doc.nombreDoc,
                nombreProv = doc.nombreProv,
                nombreUsuario = doc.nombreUsuario,
                notasDoc = doc.notasDoc,
                numeroControlDoc = doc.numeroControlDoc,
                numeroDoc = doc.numeroDoc,
                saldoPendiente = doc.saldoPendiente,
                siglasDoc = doc.siglasDoc,
                signoDoc = doc.signoDoc,
                tasaIva1 = doc.tasaIva1,
                tasaIva2 = doc.tasaIva2,
                tasaIva3 = doc.tasaIva3,
                tasaRetencionISLR = doc.tasaRetencionISLR,
                tasaRetencionIva = doc.tasaRetencionIva,
                telefonoProv = doc.telefonoProv,
                comprobanteRetencionISLR = doc.comprobanteRetencionISLR,
                comprobanteRetencionNro = doc.comprobanteRetencionNro,
                estacionEquipo = doc.estacionEquipo,
                factorCambio = doc.factorCambio,
                fechaRetencion = doc.fechaRetencion,
                montoBase = doc.montoBase,
                montoBase1 = doc.montoBase1,
                montoBase2 = doc.montoBase2,
                montoBase3 = doc.montoBase3,
                montoDivisa = doc.montoDivisa,
                montoExento = doc.montoExento,
                montoImpuesto = doc.montoImpuesto,
                montoImpuesto1 = doc.montoImpuesto1,
                montoImpuesto2 = doc.montoImpuesto2,
                montoImpuesto3 = doc.montoImpuesto3,
                montoNeto = doc.montoNeto,
                montoRetISLR = doc.montoRetISLR,
                sustraendoRetISLR = doc.sustraendoRetISLR,
                totalRetISLR = doc.totalRetISLR,
                montoRetencionIva = doc.montoRetencionIva,
                montoTotal = doc.montoTotal,
                subTotal = doc.subTotal,
                subTotalImpuesto = doc.subTotalImpuesto,
                subTotalNeto = doc.subTotalNeto,
                igtfMonto = doc.igtfMonto,
                tipoDocumentoCompra = (DtoLibTransporte.Documento.Agregar.CompraGasto.enumerados.tipoDocumentoCompra)doc.tipoDocumentoCompra,
                autoSistemaDocumento = doc.autoSistemaDocumento,
                maquinafiscal = doc.maquinafiscal,
            };
            var prv = ficha.proveedor;
            var proveedor = new DtoLibTransporte.Documento.Agregar.CompraGasto.Proveedor()
            {
                autoProv = prv.autoProv,
                fechaEmiDoc = prv.fechaEmiDoc,
                montoDebito = prv.montoDebito,
                montoCredito= prv.montoCredito,
            };
            var cxp = ficha.cxp;
            var docCxp = new DtoLibTransporte.Documento.Agregar.CompraGasto.CxP()
            {
                acumulado = cxp.acumulado,
                autoProveedor = cxp.autoProveedor,
                ciRifProveedor = cxp.ciRifProveedor,
                codigoProveedor = cxp.codigoProveedor,
                diasCredito = cxp.diasCredito,
                documentoNro = cxp.documentoNro,
                fechaVencimiento = cxp.fechaVencimiento,
                importe = cxp.importe,
                importeDivisa = cxp.importeDivisa,
                nombreRazonSocialProveedor = cxp.nombreRazonSocialProveedor,
                resta = cxp.resta,
                siglasTipoDocumento = cxp.siglasTipoDocumento,
                signoTipoDocumento = cxp.signoTipoDocumento,
                acumuladoDivisa = cxp.acumuladoDivisa,
                fechaEmision = cxp.fechaEmision,
                restaDivisa = cxp.restaDivisa,
                tasaDivisa = cxp.tasaDivisa,
                notas = cxp.notas,
                autoSistemaDoc = cxp.autoSistemaDoc,
            };
            documento.docRet = new List<DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencion>();
            if (ficha.retIva != null)
            {
                var retDetalle = new DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencionDet()
                {
                    base1 = ficha.documento.montoBase1,
                    base2 = ficha.documento.montoBase2,
                    base3 = ficha.documento.montoBase3,
                    ciRifDocRefRet = ficha.documento.ciRifProv,
                    fechaDocRefRet = ficha.documento.fechaEmisDoc,
                    impuesto1 = ficha.documento.montoImpuesto1,
                    impuesto2 = ficha.documento.montoImpuesto2,
                    impuesto3 = ficha.documento.montoImpuesto3,
                    montoBase = ficha.documento.montoBase,
                    montoExento = ficha.documento.montoExento,
                    montoImpuesto = ficha.documento.montoImpuesto,
                    montoRetencion = ficha.documento.montoRetencionIva,
                    montoTotal = (ficha.documento.montoTotal - ficha.documento.igtfMonto),
                    numAplicaDocRefRet = ficha.documento.aplicaNumeroDoc,
                    numControlDocRefRet = ficha.documento.numeroControlDoc,
                    numDocRefRet = ficha.documento.numeroDoc,
                    retIva1 = ficha.documento.montoImpuesto1 * ficha.documento.tasaRetencionIva / 100,
                    retIva2 = ficha.documento.montoImpuesto2 * ficha.documento.tasaRetencionIva / 100,
                    retIva3 = ficha.documento.montoImpuesto3 * ficha.documento.tasaRetencionIva / 100,
                    sistAutoDocRet = ficha.documento.autoSistemaDocumento,
                    sistSignoDocRet = ficha.documento.signoDoc,
                    sistTipoDocRefRet = ficha.documento.codTipoDoc,
                    sistTipoDocRet = ficha.retIva.tipoSistemaDoc,
                    sustraendoRetencion = 0m,
                    tasa1 = ficha.documento.tasaIva1,
                    tasa2 = ficha.documento.tasaIva2,
                    tasa3 = ficha.documento.tasaIva3,
                    tasaRetencion = ficha.documento.tasaRetencionIva,
                    totalRetencion = ficha.documento.montoRetencionIva,
                };
                var docRetIva = new DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencion()
                {
                    MontoBase1 = ficha.documento.montoBase1,
                    MontoBase2 = ficha.documento.montoBase2,
                    MontoBase3 = ficha.documento.montoBase3,
                    MontoExento = ficha.documento.montoExento,
                    MontoImpuesto1 = ficha.documento.montoImpuesto1,
                    MontoImpuesto2 = ficha.documento.montoImpuesto2,
                    MontoImpuesto3 = ficha.documento.montoImpuesto3,
                    MontoRetencion = ficha.documento.montoRetencionIva,
                    MontoTotal = (ficha.documento.montoTotal - ficha.documento.igtfMonto),
                    PrvAuto = ficha.documento.autoProv,
                    PrvCiRif = ficha.documento.ciRifProv,
                    PrvCodigo = ficha.documento.codigoProv,
                    PrvDirFiscal = ficha.documento.dirFiscalProv,
                    PrvNombre = ficha.documento.nombreProv,
                    SistDocAuto = ficha.retIva.autoSistemaDoc,
                    SistDocCodigo = ficha.retIva.tipoSistemaDoc,
                    SistDocNombre = ficha.retIva.nombreSistemaDoc,
                    TasaRetencion = ficha.documento.tasaRetencionIva,
                    EsIva = true,
                    retMonto = 0m,
                    retSustraendo = 0M,
                    docRetDetalle = new List<DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencionDet>(),
                    cxpRetencion = new DtoLibTransporte.Documento.Agregar.CompraGasto.CxP()
                    {
                        acumulado = ficha.retIva.acumulado,
                        autoProveedor = ficha.retIva.autoProveedor,
                        ciRifProveedor = ficha.retIva.ciRifProveedor,
                        codigoProveedor = ficha.retIva.codigoProveedor,
                        diasCredito = ficha.retIva.diasCredito,
                        documentoNro = ficha.retIva.documentoNro,
                        fechaVencimiento = ficha.retIva.fechaVencimiento,
                        importe = ficha.retIva.importe,
                        importeDivisa = ficha.retIva.importeDivisa,
                        nombreRazonSocialProveedor = ficha.retIva.nombreRazonSocialProveedor,
                        resta = ficha.retIva.resta,
                        siglasTipoDocumento = ficha.retIva.siglasTipoDocumento,
                        signoTipoDocumento = ficha.retIva.signoTipoDocumento,
                        acumuladoDivisa = ficha.retIva.acumuladoDivisa,
                        fechaEmision = ficha.retIva.fechaEmision,
                        restaDivisa = ficha.retIva.restaDivisa,
                        tasaDivisa = ficha.retIva.tasaDivisa,
                        notas = ficha.retIva.notas,
                        autoSistemaDoc = ficha.retIva.autoSistemaDoc,
                    },
                    cxpReciboRetencion = new DtoLibTransporte.Documento.Agregar.CompraGasto.Recibo()
                    {
                        documento = ficha.recIva.documento,
                        importe = ficha.recIva.importe,
                        importeDivisa = ficha.recIva.importeDivisa,
                        montoRecibido = ficha.recIva.montoRecibido,
                        montoRecibidoDivisa = ficha.recIva.montoRecibidoDivisa,
                        nota = ficha.recIva.nota,
                        prvAuto = ficha.recIva.prvAuto,
                        prvCiRif = ficha.recIva.prvCiRif,
                        prvCodigo = ficha.recIva.prvCodigo,
                        prvDirFiscal = ficha.recIva.prvDirFiscal,
                        prvNombre = ficha.recIva.prvNombre,
                        prvTlf = ficha.recIva.prvTlf,
                        tasaCambio = ficha.recIva.tasaCambio,
                        usuarioAuto = ficha.recIva.usuarioAuto,
                        usuarioNombre = ficha.recIva.usuarioNombre,
                        autoSistemaDoc = ficha.recIva.autoSistemaDoc,
                        docRecibo = new List<DtoLibTransporte.Documento.Agregar.CompraGasto.ReciboDoc>(),
                    },
                };
                docRetIva.docRetDetalle.Add(retDetalle);
                docRetIva.cxpReciboRetencion.docRecibo.
                    Add(new DtoLibTransporte.Documento.Agregar.CompraGasto.ReciboDoc()
                    {
                        importe = ficha.recIva.docRecibo.importe,
                        numDocumentoAfecta = ficha.recIva.docRecibo.numDocumentoAfecta,
                        siglasDocumentoAfecta = ficha.recIva.docRecibo.siglasDocumentoAfecta,
                        tipoOperacionRealizar = ficha.recIva.docRecibo.tipoOperacionRealizar,
                    });
                documento.docRet.Add(docRetIva);
            }
            if (ficha.retISLR != null)
            {
                var retDetalle = new DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencionDet()
                {
                    base1 = ficha.documento.montoBase1,
                    base2 = ficha.documento.montoBase2,
                    base3 = ficha.documento.montoBase3,
                    ciRifDocRefRet = ficha.documento.ciRifProv,
                    fechaDocRefRet = ficha.documento.fechaEmisDoc,
                    impuesto1 = ficha.documento.montoImpuesto1,
                    impuesto2 = ficha.documento.montoImpuesto2,
                    impuesto3 = ficha.documento.montoImpuesto3,
                    montoBase = ficha.documento.montoBase,
                    montoExento = ficha.documento.montoExento,
                    montoImpuesto = ficha.documento.montoImpuesto,
                    montoRetencion = ficha.documento.montoRetISLR,
                    montoTotal = (ficha.documento.montoTotal-ficha.documento.igtfMonto),
                    numAplicaDocRefRet = ficha.documento.aplicaNumeroDoc,
                    numControlDocRefRet = ficha.documento.numeroControlDoc,
                    numDocRefRet = ficha.documento.numeroDoc,
                    retIva1 = 0m,
                    retIva2 = 0m,
                    retIva3 = 0m,
                    sistAutoDocRet = ficha.documento.autoSistemaDocumento,
                    sistSignoDocRet = ficha.documento.signoDoc,
                    sistTipoDocRefRet = ficha.documento.codTipoDoc,
                    sistTipoDocRet = ficha.retISLR.tipoSistemaDoc,
                    sustraendoRetencion = ficha.documento.sustraendoRetISLR,
                    tasa1 = ficha.documento.tasaIva1,
                    tasa2 = ficha.documento.tasaIva2,
                    tasa3 = ficha.documento.tasaIva3,
                    tasaRetencion = ficha.documento.tasaRetencionISLR,
                    totalRetencion = ficha.documento.totalRetISLR,
                };
                var docRetIslr = new DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencion()
                {
                    MontoBase1 = ficha.documento.montoBase1,
                    MontoBase2 = ficha.documento.montoBase2,
                    MontoBase3 = ficha.documento.montoBase3,
                    MontoExento = ficha.documento.montoExento,
                    MontoImpuesto1 = ficha.documento.montoImpuesto1,
                    MontoImpuesto2 = ficha.documento.montoImpuesto2,
                    MontoImpuesto3 = ficha.documento.montoImpuesto3,
                    MontoRetencion = ficha.documento.totalRetISLR,
                    MontoTotal = (ficha.documento.montoTotal - ficha.documento.igtfMonto),
                    PrvAuto = ficha.documento.autoProv,
                    PrvCiRif = ficha.documento.ciRifProv,
                    PrvCodigo = ficha.documento.codigoProv,
                    PrvDirFiscal = ficha.documento.dirFiscalProv,
                    PrvNombre = ficha.documento.nombreProv,
                    SistDocAuto = ficha.retISLR.autoSistemaDoc,
                    SistDocCodigo = ficha.retISLR.tipoSistemaDoc,
                    SistDocNombre = ficha.retISLR.nombreSistemaDoc,
                    TasaRetencion = ficha.documento.tasaRetencionISLR,
                    EsIva = false,
                    retMonto = ficha.documento.montoRetISLR,
                    retSustraendo = ficha.documento.sustraendoRetISLR,
                    docRetDetalle = new List<DtoLibTransporte.Documento.Agregar.CompraGasto.DocRetencionDet>(),
                    cxpRetencion = new DtoLibTransporte.Documento.Agregar.CompraGasto.CxP()
                    {
                        acumulado = ficha.retISLR.acumulado,
                        autoProveedor = ficha.retISLR.autoProveedor,
                        ciRifProveedor = ficha.retISLR.ciRifProveedor,
                        codigoProveedor = ficha.retISLR.codigoProveedor,
                        diasCredito = ficha.retISLR.diasCredito,
                        documentoNro = ficha.retISLR.documentoNro,
                        fechaVencimiento = ficha.retISLR.fechaVencimiento,
                        importe = ficha.retISLR.importe,
                        importeDivisa = ficha.retISLR.importeDivisa,
                        nombreRazonSocialProveedor = ficha.retISLR.nombreRazonSocialProveedor,
                        resta = ficha.retISLR.resta,
                        siglasTipoDocumento = ficha.retISLR.siglasTipoDocumento,
                        signoTipoDocumento = ficha.retISLR.signoTipoDocumento,
                        acumuladoDivisa = ficha.retISLR.acumuladoDivisa,
                        fechaEmision = ficha.retISLR.fechaEmision,
                        restaDivisa = ficha.retISLR.restaDivisa,
                        tasaDivisa = ficha.retISLR.tasaDivisa,
                        notas = ficha.retISLR.notas,
                        autoSistemaDoc = ficha.retISLR.autoSistemaDoc,
                    },
                    cxpReciboRetencion = new DtoLibTransporte.Documento.Agregar.CompraGasto.Recibo()
                    {
                        documento = ficha.recISLR.documento,
                        importe = ficha.recISLR.importe,
                        importeDivisa = ficha.recISLR.importeDivisa,
                        montoRecibido = ficha.recISLR.montoRecibido,
                        montoRecibidoDivisa = ficha.recISLR.montoRecibidoDivisa,
                        nota = ficha.recISLR.nota,
                        prvAuto = ficha.recISLR.prvAuto,
                        prvCiRif = ficha.recISLR.prvCiRif,
                        prvCodigo = ficha.recISLR.prvCodigo,
                        prvDirFiscal = ficha.recISLR.prvDirFiscal,
                        prvNombre = ficha.recISLR.prvNombre,
                        prvTlf = ficha.recISLR.prvTlf,
                        tasaCambio = ficha.recISLR.tasaCambio,
                        usuarioAuto = ficha.recISLR.usuarioAuto,
                        usuarioNombre = ficha.recISLR.usuarioNombre,
                        autoSistemaDoc = ficha.recISLR.autoSistemaDoc,
                        docRecibo = new List<DtoLibTransporte.Documento.Agregar.CompraGasto.ReciboDoc>(),
                    },
                };
                docRetIslr.docRetDetalle.Add(retDetalle);
                docRetIslr.cxpReciboRetencion.docRecibo.
                    Add(new DtoLibTransporte.Documento.Agregar.CompraGasto.ReciboDoc()
                    {
                        importe = ficha.recISLR.docRecibo.importe,
                        numDocumentoAfecta = ficha.recISLR.docRecibo.numDocumentoAfecta,
                        siglasDocumentoAfecta = ficha.recISLR.docRecibo.siglasDocumentoAfecta,
                        tipoOperacionRealizar = ficha.recISLR.docRecibo.tipoOperacionRealizar,
                    });
                documento.docRet.Add(docRetIslr);
            }
            documento.cxp = docCxp;
            documento.proveedor = proveedor;
            fichaDTO.documento = documento;

            var r01 = MyData.Transporte_Documento_Agregar_CompraGrasto(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado()
            {
                autoDocCompra = r01.Entidad.autoDocCompra,
                autoDocCxp = r01.Entidad.autoDocCxp,
            };
            return result;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>();
            var r01 = MyData.Transporte_Documento_Concepto_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha()
                        {
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                            id = s.id,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoId
            Transporte_Documento_Concepto_Agregar(OOB.LibCompra.Transporte.Documento.Concepto.Agregar.Ficha ficha)
        {
            var result = new OOB.ResultadoId();
            var fichaDTO = new DtoLibTransporte.Documento.Concepto.Agregar.Ficha()
            {
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.Transporte_Documento_Concepto_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Id = r01.Id;
            return result;
        }
        public OOB.Resultado
            Transporte_Documento_Concepto_Editar(OOB.LibCompra.Transporte.Documento.Concepto.Editar.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Documento.Concepto.Editar.Ficha()
            {
                id = ficha.id,
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.Transporte_Documento_Concepto_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetById(int id)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>();
            var r01 = MyData.Transporte_Documento_Concepto_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha()
            {
                codigo = s.codigo,
                descripcion = s.descripcion,
                id = s.id,
            };
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_GetData(string autoDoc)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.Ficha>();
            var r01 = MyData.Transporte_Documento_Anular_CompraGrasto_GetData(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.Ficha
            {
                documento = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.Documento()
                {
                    autoCxp = s.documento.autoCxp,
                    autoPrv = s.documento.autoPrv,
                    codigoTipoDoc = s.documento.codigoTipoDoc,
                    documento = s.documento.documento,
                    total = s.documento.total,
                    autoSistemaDoc = s.documento.autoSistemaDoc,
                    tipoDocumentoCompra = s.documento.tipoDocumentoCompra,
                    autoSistemaDocCxp = s.documento.autoSistemaDocCxp,
                    importeDiv= s.documento.importeDiv,
                    acumuladoDiv = s.documento.acumuladoDiv,
                },
                retencionRecibo = s.retencionRecibo.Select(ss =>
                {
                    var nr = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.RetRec()
                    {
                        autoCxp = ss.autoCxp,
                        autoRecibo = ss.autoRecibo,
                        autoSistDocCxp = ss.autoSistDocCxp,
                        autoSistDocRec = ss.autoSistDocRec,
                    };
                    return nr;
                }).ToList(),
                retencionDoc = s.retencionDoc.Select(xx =>
                {
                    var xr = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.RetDoc()
                    {
                        autoDocCompraRet = xx.autoDocCompraRet,
                    };
                    return xr;
                }).ToList(),
            };
            return result;
        }
        public OOB.Resultado
            Transporte_Documento_Anular_CompraGrasto(OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Ficha()
            {
                autoDocCompra = ficha.autoDocCompra,
                autoDocCxP = ficha.autoDocCxP,
                auditoria = ficha.auditoria.Select(s =>
                {
                    var nr = new DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Auditoria()
                    {
                        autoDoc = s.autoDoc,
                        autoSistemaDocumento = s.autoSistemaDocumento,
                        autoUsuario = s.autoUsuario,
                        codigoUsuario = s.codigoUsuario,
                        estacion = s.estacion,
                        ip = s.ip,
                        motivo = s.motivo,
                        nombreUsuario = s.nombreUsuario,
                    };
                    return nr;
                }).ToList(),
                proveedor = new DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Proveedor()
                {
                    autoProv = ficha.proveedor.autoProv,
                    montoDebito = ficha.proveedor.montoDebito,
                    montoCredito = ficha.proveedor.montoCredito,
                },
                retenciones = ficha.retenciones.Select(s =>
                {
                    var nr = new DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Retencion()
                    {
                        autoCxP = s.autoCxP,
                        autoRecibo = s.autoRecibo,
                    };
                    return nr;
                }).ToList(),
                docRetCompra = ficha.docRetCompra.Select(t =>
                {
                    var xnr = new DtoLibTransporte.Documento.Anular.CompraGasto.Anular.DocRetCompra()
                    {
                        autoDocRetCompra = t.autoDocRetCompra,
                    };
                    return xnr;
                }).ToList(),
            };
            var r01 = MyData.Transporte_Documento_Anular_CompraGrasto(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Entidad.Ficha>
            Transporte_Documento_Entidad_CompraGrasto_GetById(string autoDoc)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Entidad.Ficha>();
            var r01 = MyData.Transporte_Documento_Entidad_CompraGrasto_GetById(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad.documento;
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Entidad.Ficha()
            {
                documento = new OOB.LibCompra.Transporte.Documento.Entidad.Documento()
                {
                    conceptoAuto = s.conceptoAuto,
                    conceptoCodigo = s.conceptoCodigo,
                    conceptoDesc = s.conceptoDesc,
                    docAnoRelacion = s.docAnoRelacion,
                    docAplicaCodDocRef = s.docAplicaCodDocRef,
                    docAplicaNumRef = s.docAplicaNumRef,
                    docAuto = s.docAuto,
                    docAutoCxp = s.docAutoCxp,
                    docCntRenglones = s.docCntRenglones,
                    docCondicionPago = s.docCondicionPago,
                    docControl = s.docControl,
                    docDiasCredito = s.docDiasCredito,
                    docEstatus = s.docEstatus,
                    docEstatusFiscal = s.docEstatusFiscal,
                    docFechaEmision = s.docFechaEmision,
                    docFechaRegistro = s.docFechaRegistro,
                    docFechaVencimiento = s.docFechaVencimiento,
                    docHoraRegistro = s.docHoraRegistro,
                    docMesRelacion = s.docMesRelacion,
                    docNotas = s.docNotas,
                    docNumero = s.docNumero,
                    docNumOrdenCompra = s.docNumOrdenCompra,
                    docTipoDocCompra = s.docTipoDocCompra,
                    equipoEstacion = s.equipoEstacion,
                    factorCambio = s.factorCambio,
                    montoBase = s.montoBase,
                    montoBase1 = s.montoBase1,
                    montoBase2 = s.montoBase2,
                    montoBase3 = s.montoBase3,
                    montoDivisa = s.montoDivisa,
                    montoExento = s.montoExento,
                    montoIGTF = s.montoIGTF,
                    montoImpuesto = s.montoImpuesto,
                    montoIva1 = s.montoIva1,
                    montoIva2 = s.montoIva2,
                    montoIva3 = s.montoIva3,
                    montoNeto = s.montoNeto,
                    montoRetIslr = s.montoRetIslr,
                    montoRetIva = s.montoRetIva,
                    montoTotal = s.montoTotal,
                    prvAuto = s.prvAuto,
                    prvCiRif = s.prvCiRif,
                    prvCodigo = s.prvCodigo,
                    prvDirFiscal = s.prvDirFiscal,
                    prvNombre = s.prvNombre,
                    prvTelefono = s.prvTelefono,
                    sistDocAuto = s.sistDocAuto,
                    sistDocCodigo = s.sistDocCodigo,
                    sistDocModulo = s.sistDocModulo,
                    sistDocNombre = s.sistDocNombre,
                    sistDocSiglas = s.sistDocSiglas,
                    sistDocSigno = s.sistDocSigno,
                    subTotal = s.subTotal,
                    subTotalImpuesto = s.subTotalImpuesto,
                    subTotalNeto = s.subTotalNeto,
                    sucAuto = s.sucAuto,
                    sucCodigo = s.sucCodigo,
                    sucDesc = s.sucDesc,
                    sustraendoRetIslr = s.sustraendoRetIslr,
                    tasaIva1 = s.tasaIva1,
                    tasaIva2 = s.tasaIva2,
                    tasaIva3 = s.tasaIva3,
                    tasaRetIslr = s.tasaRetIslr,
                    tasaRetIva = s.tasaRetIva,
                    totalRetIslr = s.totalRetIslr,
                    usuAuto = s.usuAuto,
                    usuCodigo = s.usuCodigo,
                    usuNombre = s.usuNombre,
                },
            };
            return result;
        }
    }
}