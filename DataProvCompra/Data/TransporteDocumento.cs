using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado> 
            Transporte_Documento_Agregar_CompraGrasto(OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Ficha ficha)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado>();
            var fichaDTO = new  DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha();
            var doc=ficha.documento;
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
                montoRetencionISLR = doc.montoRetencionISLR,
                montoRetencionIva = doc.montoRetencionIva,
                montoTotal = doc.montoTotal,
                subTotal = doc.subTotal,
                subTotalImpuesto = doc.subTotalImpuesto,
                subTotalNeto = doc.subTotalNeto,
            };
            var prv = ficha.proveedor;
            var proveedor = new DtoLibTransporte.Documento.Agregar.CompraGasto.Proveedor()
            {
                autoProv = prv.autoProv,
                fechaEmiDoc = prv.fechaEmiDoc,
                montoDebito = prv.montoDebito,
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
            };
            fichaDTO.documento = documento;
            fichaDTO.cxp = docCxp;
            fichaDTO.proveedor= proveedor;
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


        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha> Transporte_Documento_Concepto_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha> ();
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
    }
}