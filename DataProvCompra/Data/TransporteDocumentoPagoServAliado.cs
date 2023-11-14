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
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha>
            Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(int idPagoServ)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha>();
            var r01 = MyData.Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(idPagoServ);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha()
            {
                idAliado = s.idAliado,
                idPago = s.idPago,
                nroRecibo = s.nroRecibo,
                retencion = s.retencion,
                sustraendo = s.sustraendo,
                tasaCambio = s.tasaCambio,
                tasaRet = s.tasaRet,
                totalMonAct = s.totalMonAct,
                totalMonDiv = s.totalMonDiv,
                totalRetMonAct = s.totalRetMonAct,
                totalRetMonDiv = s.totalRetMonDiv,
            };
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Resultado>
            Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Ficha ficha)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Resultado>();
            var fichaDTO = new DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Ficha();
            var doc = ficha.documento;
            var documento = new DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Documento()
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
                tipoDocumentoCompra = (DtoLibTransporte.Documento.Agregar.CompraGastoAliado.enumerados.tipoDocumentoCompra)doc.tipoDocumentoCompra,
                autoSistemaDocumento = doc.autoSistemaDocumento,
                maquinafiscal = doc.maquinafiscal,
                idPagoServAliado = doc.idPagoServAliado,
            };
            var prv = ficha.documento.proveedor;
            var proveedor = new DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Proveedor()
            {
                autoProv = prv.autoProv,
                fechaEmiDoc = prv.fechaEmiDoc,
                montoDebito = prv.montoDebito,
                montoCredito = prv.montoCredito,
            };
            documento.docRet = new List<DtoLibTransporte.Documento.Agregar.CompraGastoAliado.DocRetencion>();
            if (ficha.documento.montoRetISLR > 0m)
            {
                var retDetalle = new DtoLibTransporte.Documento.Agregar.CompraGastoAliado.DocRetencionDet()
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
                    montoTotal = (ficha.documento.montoTotal - ficha.documento.igtfMonto),
                    numAplicaDocRefRet = ficha.documento.aplicaNumeroDoc,
                    numControlDocRefRet = ficha.documento.numeroControlDoc,
                    numDocRefRet = ficha.documento.numeroDoc,
                    retIva1 = 0m,
                    retIva2 = 0m,
                    retIva3 = 0m,
                    sistAutoDocRet = ficha.documento.autoSistemaDocumento,
                    sistSignoDocRet = ficha.documento.signoDoc,
                    sistTipoDocRefRet = ficha.documento.codTipoDoc,
                    sistTipoDocRet = ficha.documento.SistDocRetIslrCodigo,
                    sustraendoRetencion = ficha.documento.sustraendoRetISLR,
                    tasa1 = ficha.documento.tasaIva1,
                    tasa2 = ficha.documento.tasaIva2,
                    tasa3 = ficha.documento.tasaIva3,
                    tasaRetencion = ficha.documento.tasaRetencionISLR,
                    totalRetencion = ficha.documento.totalRetISLR,
                };
                var docRetIslr = new DtoLibTransporte.Documento.Agregar.CompraGastoAliado.DocRetencion()
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
                    SistDocAuto = ficha.documento.SistDocRetIslrAuto,
                    SistDocCodigo = ficha.documento.SistDocRetIslrCodigo,
                    SistDocNombre = ficha.documento.SistDocRetIslrNombre,
                    TasaRetencion = ficha.documento.tasaRetencionISLR,
                    EsIva = false,
                    retMonto = ficha.documento.montoRetISLR,
                    retSustraendo = ficha.documento.sustraendoRetISLR,
                    docRetDetalle = new List<DtoLibTransporte.Documento.Agregar.CompraGastoAliado.DocRetencionDet>(),
                };
                docRetIslr.docRetDetalle.Add(retDetalle);
                documento.docRet.Add(docRetIslr);
            }
            documento.proveedor = proveedor;
            fichaDTO.documento = documento;
            //
            var r01 = MyData.Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Resultado()
            {
                autoDocCompra = r01.Entidad.autoDocCompra,
                autoDocCxp = r01.Entidad.autoDocCxp,
            };
            return result;
        }
        public OOB.Resultado
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(string autoDoc)
        {
            var result = new OOB.Resultado();
            var r01 = MyData.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(string autoDoc)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData.Ficha>();
            var r01 = MyData.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData.Ficha
            {
                documento = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData.Documento()
                {
                    autoCxp = s.documento.autoCxp,
                    autoPrv = s.documento.autoPrv,
                    codigoTipoDoc = s.documento.codigoTipoDoc,
                    documento = s.documento.documento,
                    total = s.documento.total,
                    autoSistemaDoc = s.documento.autoSistemaDoc,
                    tipoDocumentoCompra = s.documento.tipoDocumentoCompra,
                    idRelPagServ = s.documento.idRelPagServ,
                    idTranspAliadoPagServ = s.documento.idTranspAliadoPagServ,
                    totalDivisa = s.documento.totalDivisa,
                },
                retencionDoc = s.retencionDoc.Select(xx =>
                {
                    var xr = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData.RetDoc()
                    {
                        autoDocCompraRet = xx.autoDocCompraRet,
                    };
                    return xr;
                }).ToList(),
            };
            return result;
        }
        public OOB.ResultadoEntidad<bool>
            Transporte_Documento_ChequearSiEs_CompraGrasto_DePagoAliadoServ(string autoDoc)
        {
            var result = new OOB.ResultadoEntidad<bool>();
            var r01 = MyData.Transporte_Documento_ChequearSiEs_CompraGrasto_DePagoAliadoServ(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = r01.Entidad;
            return result;
        }
        public OOB.Resultado 
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ(OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.Anular.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular.Ficha()
            {
                idPagoServicio = ficha.idPagoServicio,
                idRelCompraPago = ficha.idRelCompraPago,
                autoDocCompra = ficha.autoDocCompra,
                auditoria = ficha.auditoria.Select(s =>
                {
                    var nr = new DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular.Auditoria()
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
                proveedor = new DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular.Proveedor()
                {
                    autoProv = ficha.proveedor.autoProv,
                    montoDebito = ficha.proveedor.montoDebito,
                    montoCredito = ficha.proveedor.montoCredito,
                },
                docRetCompra = ficha.docRetCompra.Select(t =>
                {
                    var xnr = new DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular.DocRetCompra()
                    {
                        autoDocRetCompra = t.autoDocRetCompra,
                    };
                    return xnr;
                }).ToList(),
            };
            var r01 = MyData.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
    }
}