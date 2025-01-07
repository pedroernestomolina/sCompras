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
        public OOB.ResultadoAuto
            Compra_DocumentoAgregarNC(OOB.LibCompra.Documento.Agregar.NotaCredito.Ficha docNC)
        {
            var result = new OOB.ResultadoAuto();
            //
            var fichaDTO = new DtoLibCompra.Documento.Agregar.NotaCredito.Ficha();
            var xdoc = docNC.documento;
            var documento = new DtoLibCompra.Documento.Agregar.NotaCredito.FichaDocumento()
            {
                anoRelacion = xdoc.anoRelacion,
                anticipoIva = xdoc.anticipoIva,
                aplicaDocumentoNro = xdoc.aplicaDocumentoNro,
                autoConcepto = xdoc.autoConcepto,
                autoProveedor = xdoc.autoProveedor,
                autoRemision = xdoc.autoRemision,
                cierreFtp = xdoc.cierreFtp,
                ciRifProveedor = xdoc.ciRifProveedor,
                cntRenglones = xdoc.cntRenglones,
                codicionPago = xdoc.codicionPago,
                codigoProveedor = xdoc.codigoProveedor,
                columna = xdoc.columna,
                comprobanteRetencionISLR = xdoc.comprobanteRetencionISLR,
                comprobanteRetencionNro = xdoc.comprobanteRetencionNro,
                controlNro = xdoc.controlNro,
                denominacionFiscal = xdoc.denominacionFiscal,
                diasCredito = xdoc.diasCredito,
                diasValidez = xdoc.diasValidez,
                direccionFiscalProveedor = xdoc.direccionFiscalProveedor,
                documentoNombre = xdoc.documentoNombre,
                documentoNro = xdoc.documentoNro,
                documentoRemision = xdoc.documentoRemision,
                documentoTipo = xdoc.documentoTipo,
                esAnulado = xdoc.esAnulado,
                estacionEquipo = xdoc.estacionEquipo,
                estatusCierreContable = xdoc.estatusCierreContable,
                expediente = xdoc.expediente,
                factorCambio = xdoc.factorCambio,
                fechaDocumento = xdoc.fechaDocumento,
                fechaRetencion = xdoc.fechaRetencion,
                fechaVencimiento = xdoc.fechaVencimiento,
                mesRelacion = xdoc.mesRelacion,
                montoBase = xdoc.montoBase,
                montoBase1 = xdoc.montoBase1,
                montoBase2 = xdoc.montoBase2,
                montoBase3 = xdoc.montoBase3,
                montoCargo = xdoc.montoCargo,
                montoCosto = xdoc.montoCosto,
                montoDescuento1 = xdoc.montoDescuento1,
                montoDescuento2 = xdoc.montoDescuento2,
                montoDivisa = xdoc.montoDivisa,
                montoExento = xdoc.montoExento,
                montoImpuesto = xdoc.montoImpuesto,
                montoImpuesto1 = xdoc.montoImpuesto1,
                montoImpuesto2 = xdoc.montoImpuesto2,
                montoImpuesto3 = xdoc.montoImpuesto3,
                montoNeto = xdoc.montoNeto,
                montoRetencionISLR = xdoc.montoRetencionISLR,
                montoRetencionIva = xdoc.montoRetencionIva,
                montoSaldoPendeiente = xdoc.montoSaldoPendeiente,
                montoTotal = xdoc.montoTotal,
                montoUtilidad = xdoc.montoUtilidad,
                nombreRazonSocialProveedor = xdoc.nombreRazonSocialProveedor,
                notaDocumento = xdoc.notaDocumento,
                ordenCompraNro = xdoc.ordenCompraNro,
                planilla = xdoc.planilla,
                serieDocumento = xdoc.serieDocumento,
                signoDocumento = xdoc.signoDocumento,
                situacionDocumento = xdoc.situacionDocumento,
                subTotal = xdoc.subTotal,
                subTotalImpuesto = xdoc.subTotalImpuesto,
                subTotalNeto = xdoc.subTotalNeto,
                sucursalCodigo = xdoc.sucursalCodigo,
                tarifa = xdoc.tarifa,
                telefonoPropveedor = xdoc.telefonoPropveedor,
                tercerosIva = xdoc.tercerosIva,
                tipoDocumento = xdoc.tipoDocumento,
                tipoProveedor = xdoc.tipoProveedor,
                tipoRemision = xdoc.tipoRemision,
                usuarioAuto = xdoc.usuarioAuto,
                usuarioCodigo = xdoc.usuarioCodigo,
                usuarioNombre = xdoc.usuarioNombre,
                valorPorccargo = xdoc.valorPorccargo,
                valorPorcDescuento1 = xdoc.valorPorcDescuento1,
                valorPorcDescuento2 = xdoc.valorPorcDescuento2,
                valorPorctUtilidad = xdoc.valorPorctUtilidad,
                valorTasaIva1 = xdoc.valorTasaIva1,
                valorTasaIva2 = xdoc.valorTasaIva2,
                valorTasaIva3 = xdoc.valorTasaIva3,
                valorTasaRetencionISLR = xdoc.valorTasaRetencionISLR,
                valorTasaRetencionIva = xdoc.valorTasaRetencionIva,
                //
                AplicaLibroSeniat = xdoc.AplicaLibroSeniat ? "1" : "0",
                DescSucursal = xdoc.DescSucursal,
                IdSucursal = xdoc.IdSucursal,
            };
            var xcxp = docNC.cxp;
            var cxp = new DtoLibCompra.Documento.Agregar.NotaCredito.FichaCxP()
            {
                acumulado = xcxp.acumulado,
                Anexo = xcxp.Anexo,
                autoAgencia = xcxp.autoAgencia,
                autoProveedor = xcxp.autoProveedor,
                ciRifProveedor = xcxp.ciRifProveedor,
                codigoProveedor = xcxp.codigoProveedor,
                diasCredito = xcxp.diasCredito,
                documentoNro = xcxp.documentoNro,
                esAnulado = xcxp.esAnulado,
                esCancelado = xcxp.esCancelado,
                estatusCierreContable = xcxp.estatusCierreContable,
                fechaVencimiento = xcxp.fechaVencimiento,
                importe = xcxp.importe,
                importeDivisa = xcxp.importeDivisa,
                nombreAgencia = xcxp.nombreAgencia,
                nombreRazonSocialProveedor = xcxp.nombreRazonSocialProveedor,
                nota = xcxp.nota,
                numero = xcxp.numero,
                resta = xcxp.resta,
                signoDocumento = xcxp.signoDocumento,
                tipoDocumento = xcxp.tipoDocumento,
            };
            var detalles = new List<DtoLibCompra.Documento.Agregar.NotaCredito.FichaDetalle>();
            foreach (var it in docNC.detalles)
            {
                var nr = new DtoLibCompra.Documento.Agregar.NotaCredito.FichaDetalle()
                {
                    autoDepartamento = it.autoDepartamento,
                    autoDeposito = it.autoDeposito,
                    autoGrupo = it.autoGrupo,
                    autoProducto = it.autoProducto,
                    autoProveedor = it.autoProveedor,
                    autoSubGrupo = it.autoSubGrupo,
                    autoTasaIva = it.autoTasaIva,
                    cantidadBonoFac = it.cantidadBonoFac,
                    cantidadFac = it.cantidadFac,
                    cantidadUnd = it.cantidadUnd,
                    categoriaPrd = it.categoriaPrd,
                    cierreFtp = it.cierreFtp,
                    codigoProducto = it.codigoProducto,
                    codigoProveedor = it.codigoProveedor,
                    contenidoEmpaque = it.contenidoEmpaque,
                    costoBruto = it.costoBruto,
                    costoCompra = it.costoCompra,
                    costoPromedioUnd = it.costoPromedioUnd,
                    costoUnd = it.costoUnd,
                    decimalesPrd = it.decimalesPrd,
                    depositoCodigo = it.depositoCodigo,
                    depositoNombre = it.depositoNombre,
                    detalle = it.detalle,
                    empaquePrd = it.empaquePrd,
                    esAnulado = it.esAnulado,
                    estatusUnidad = it.estatusUnidad,
                    fechaLote = it.fechaLote,
                    montoDescto1 = it.montoDescto1,
                    montoDescto2 = it.montoDescto2,
                    montoDescto3 = it.montoDescto3,
                    montoImpuesto = it.montoImpuesto,
                    montoTotal = it.montoTotal,
                    nombreProducto = it.nombreProducto,
                    signo = it.signo,
                    tipoDocumento = it.tipoDocumento,
                    totalNeto = it.totalNeto,
                    valorPorcDescto1 = it.valorPorcDescto1,
                    valorPorcDescto2 = it.valorPorcDescto2,
                    valorPorcDescto3 = it.valorPorcDescto3,
                    valorTasaIva = it.valorTasaIva,
                };
                detalles.Add(nr);
            }
            var prdDeposito = new List<DtoLibCompra.Documento.Agregar.NotaCredito.FichaPrdDeposito>();
            foreach (var it in docNC.prdDeposito)
            {
                var nr = new DtoLibCompra.Documento.Agregar.NotaCredito.FichaPrdDeposito()
                {
                    autoDep = it.autoDep,
                    autoPrd = it.autoPrd,
                    cantidadUnd = it.cantidadUnd,
                };
                prdDeposito.Add(nr);
            }
            var prdKardex = new List<DtoLibCompra.Documento.Agregar.NotaCredito.FichaPrdKardex>();
            foreach (var it in docNC.prdKardex)
            {
                var nr = new DtoLibCompra.Documento.Agregar.NotaCredito.FichaPrdKardex()
                {
                    autoConcepto = it.autoConcepto,
                    autoDeposito = it.autoDeposito,
                    autoPrd = it.autoPrd,
                    cantidadBonoFac = it.cantidadBonoFac,
                    cantidadFac = it.cantidadFac,
                    cantidadUnd = it.cantidadUnd,
                    cierreFtp = it.cierreFtp,
                    codigoConcepto = it.codigoConcepto,
                    codigoDeposito = it.codigoDeposito,
                    codigoMovDoc = it.codigoMovDoc,
                    codigoSucursal = it.codigoSucursal,
                    costoUnd = it.costoUnd,
                    documentoNro = it.documentoNro,
                    entidad = it.entidad,
                    esAnulado = it.esAnulado,
                    modulo = it.modulo,
                    montoTotal = it.montoTotal,
                    nombreConcepto = it.nombreConcepto,
                    nombreDeposito = it.nombreDeposito,
                    nota = it.nota,
                    precioUnd = it.precioUnd,
                    siglasMovDoc = it.siglasMovDoc,
                    signoDocumento = it.signoDocumento,
                    factorCambio = it.factorCambio,
                };
                prdKardex.Add(nr);
            }
            fichaDTO.documento = documento;
            fichaDTO.cxp = cxp;
            fichaDTO.detalles = detalles;
            fichaDTO.prdDeposito = prdDeposito;
            fichaDTO.prdKardex = prdKardex;
            var r01 = MyData.Compra_DocumentoAgregarNC(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }
            //
            result.Auto = r01.Auto;
            return result;
        }
    }
}
