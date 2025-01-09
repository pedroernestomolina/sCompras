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
            //
            var doc = ficha.documento;
            var fichaDTO = new DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha();
            var _documento = new DtoLibTransporte.Documento.Agregar.CompraGasto.Documento()
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
            var _proveedor = new DtoLibTransporte.Documento.Agregar.CompraGasto.Proveedor()
            {
                autoProv = prv.autoProv,
                fechaEmiDoc = prv.fechaEmiDoc,
                montoDebito = prv.montoDebito,
                montoCredito= prv.montoCredito,
            };
            var cxp = ficha.cxp;
            var _docCxp = new DtoLibTransporte.Documento.Agregar.CompraGasto.CxP()
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
            _documento.cxp = _docCxp;
            _documento.proveedor = _proveedor;
            fichaDTO.documento = _documento;
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
            //
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