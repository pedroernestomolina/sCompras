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
            Compra_DocumentoAgregarFactura(OOB.LibCompra.Documento.Cargar.Factura.Ficha docFac)
        {
            var result = new OOB.ResultadoAuto();
            //
            var fichaDTO = new DtoLibCompra.Documento.Agregar.Factura.Ficha();
            var xdoc = docFac.documento;
            var documento = new DtoLibCompra.Documento.Agregar.Factura.FichaDocumento()
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
            var xcxp = docFac.cxp;
            var cxp = new DtoLibCompra.Documento.Agregar.Factura.FichaCxP()
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
            var detalles = new List<DtoLibCompra.Documento.Agregar.Factura.FichaDetalle>();
            foreach (var it in docFac.detalles)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaDetalle()
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
                    estatusHabilitarCambioPrecioVenta = it.estatusHabilitarCambioPrecioVenta,
                };
                detalles.Add(nr);
            }
            var prdDeposito = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdDeposito>();
            foreach (var it in docFac.prdDeposito)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdDeposito()
                {
                    autoDep = it.autoDep,
                    autoPrd = it.autoPrd,
                    cantidadUnd = it.cantidadUnd,
                    nombrePrd = it.nombrePrd,
                };
                prdDeposito.Add(nr);
            }
            var prdKardex = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdKardex>();
            foreach (var it in docFac.prdKardex)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdKardex()
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
                    nombrePrd = it.nombrePrd,
                    factorCambio = it.factorCambio,
                };
                prdKardex.Add(nr);
            }
            var prdCosto = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdCosto>();
            if (docFac.prdCosto != null)
            {
                foreach (var it in docFac.prdCosto)
                {
                    var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdCosto()
                    {
                        autoPrd = it.autoPrd,
                        cntUnd = it.cntUnd,
                        contenido = it.contenido,
                        costo = it.costo,
                        costoDivisa = it.costoDivisa,
                        costoUnd = it.costoUnd,
                        nombrePrd = it.nombrePrd,
                    };
                    prdCosto.Add(nr);
                }
            }
            var prdCostoHistorico = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdCostoHistorico>();
            if (docFac.prdCostosHistorico != null)
            {
                foreach (var it in docFac.prdCostosHistorico)
                {
                    var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdCostoHistorico()
                    {
                        autoPrd = it.autoPrd,
                        costo = it.costo,
                        costoDivisa = it.costoDivisa,
                        documento = xdoc.documentoNro,
                        nota = "",
                        serie = "FAC",
                        tasaDivisa = xdoc.factorCambio,
                    };
                    prdCostoHistorico.Add(nr);
                }
            }
            var prdProveedor = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdProveedor>();
            foreach (var it in docFac.prdProveedor)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdProveedor()
                {
                    autoPrd = it.autoPrd,
                    autoProveedor = it.autoProveedor,
                    codigoRefProveedor = it.codigoRefProveedor,
                };
                prdProveedor.Add(nr);
            }

            var preciosMod = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecios>();
            foreach (var it in docFac.prdPreciosMod)
            {
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p1_1 = null;
                if (it.precio1_Emp1 != null)
                {
                    p1_1 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio1_Emp1.autoEmp,
                        contenido = it.precio1_Emp1.contenido,
                        precioFullDivisa = it.precio1_Emp1.precioFullDivisa,
                        precioNeto = it.precio1_Emp1.precioNeto,
                        utilidad = it.precio1_Emp1.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p1_2 = null;
                if (it.precio1_Emp2 != null)
                {
                    p1_2 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio1_Emp2.autoEmp,
                        contenido = it.precio1_Emp2.contenido,
                        precioFullDivisa = it.precio1_Emp2.precioFullDivisa,
                        precioNeto = it.precio1_Emp2.precioNeto,
                        utilidad = it.precio1_Emp2.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p1_3 = null;
                if (it.precio1_Emp3 != null)
                {
                    p1_3 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio1_Emp3.autoEmp,
                        contenido = it.precio1_Emp3.contenido,
                        precioFullDivisa = it.precio1_Emp3.precioFullDivisa,
                        precioNeto = it.precio1_Emp3.precioNeto,
                        utilidad = it.precio1_Emp3.utilidad,
                    };
                };
                //
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p2_1 = null;
                if (it.precio2_Emp1 != null)
                {
                    p2_1 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio2_Emp1.autoEmp,
                        contenido = it.precio2_Emp1.contenido,
                        precioFullDivisa = it.precio2_Emp1.precioFullDivisa,
                        precioNeto = it.precio2_Emp1.precioNeto,
                        utilidad = it.precio2_Emp1.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p2_2 = null;
                if (it.precio2_Emp2 != null)
                {
                    p2_2 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio2_Emp2.autoEmp,
                        contenido = it.precio2_Emp2.contenido,
                        precioFullDivisa = it.precio2_Emp2.precioFullDivisa,
                        precioNeto = it.precio2_Emp2.precioNeto,
                        utilidad = it.precio2_Emp2.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p2_3 = null;
                if (it.precio2_Emp3 != null)
                {
                    p2_3 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio2_Emp3.autoEmp,
                        contenido = it.precio2_Emp3.contenido,
                        precioFullDivisa = it.precio2_Emp3.precioFullDivisa,
                        precioNeto = it.precio2_Emp3.precioNeto,
                        utilidad = it.precio2_Emp3.utilidad,
                    };
                };
                //
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p3_1 = null;
                if (it.precio3_Emp1 != null)
                {
                    p3_1 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio3_Emp1.autoEmp,
                        contenido = it.precio3_Emp1.contenido,
                        precioFullDivisa = it.precio3_Emp1.precioFullDivisa,
                        precioNeto = it.precio3_Emp1.precioNeto,
                        utilidad = it.precio3_Emp1.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p3_2 = null;
                if (it.precio3_Emp2 != null)
                {
                    p3_2 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio3_Emp2.autoEmp,
                        contenido = it.precio3_Emp2.contenido,
                        precioFullDivisa = it.precio3_Emp2.precioFullDivisa,
                        precioNeto = it.precio3_Emp2.precioNeto,
                        utilidad = it.precio3_Emp2.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p3_3 = null;
                if (it.precio3_Emp3 != null)
                {
                    p3_3 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio3_Emp3.autoEmp,
                        contenido = it.precio3_Emp3.contenido,
                        precioFullDivisa = it.precio3_Emp3.precioFullDivisa,
                        precioNeto = it.precio3_Emp3.precioNeto,
                        utilidad = it.precio3_Emp3.utilidad,
                    };
                };
                //
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p4_1 = null;
                if (it.precio4_Emp1 != null)
                {
                    p4_1 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio4_Emp1.autoEmp,
                        contenido = it.precio4_Emp1.contenido,
                        precioFullDivisa = it.precio4_Emp1.precioFullDivisa,
                        precioNeto = it.precio4_Emp1.precioNeto,
                        utilidad = it.precio4_Emp1.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p4_2 = null;
                if (it.precio4_Emp2 != null)
                {
                    p4_2 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio4_Emp2.autoEmp,
                        contenido = it.precio4_Emp2.contenido,
                        precioFullDivisa = it.precio4_Emp2.precioFullDivisa,
                        precioNeto = it.precio4_Emp2.precioNeto,
                        utilidad = it.precio4_Emp2.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p4_3 = null;
                if (it.precio4_Emp3 != null)
                {
                    p4_3 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio4_Emp3.autoEmp,
                        contenido = it.precio4_Emp3.contenido,
                        precioFullDivisa = it.precio4_Emp3.precioFullDivisa,
                        precioNeto = it.precio4_Emp3.precioNeto,
                        utilidad = it.precio4_Emp3.utilidad,
                    };
                };
                //
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p5_1 = null;
                if (it.precio5_Emp1 != null)
                {
                    p5_1 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio5_Emp1.autoEmp,
                        contenido = it.precio5_Emp1.contenido,
                        precioFullDivisa = it.precio5_Emp1.precioFullDivisa,
                        precioNeto = it.precio5_Emp1.precioNeto,
                        utilidad = it.precio5_Emp1.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p5_2 = null;
                if (it.precio5_Emp2 != null)
                {
                    p5_2 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio5_Emp2.autoEmp,
                        contenido = it.precio5_Emp2.contenido,
                        precioFullDivisa = it.precio5_Emp2.precioFullDivisa,
                        precioNeto = it.precio5_Emp2.precioNeto,
                        utilidad = it.precio5_Emp2.utilidad,
                    };
                };
                DtoLibCompra.Documento.Agregar.Factura.FichaPrecio p5_3 = null;
                if (it.precio5_Emp3 != null)
                {
                    p5_3 = new DtoLibCompra.Documento.Agregar.Factura.FichaPrecio
                    {
                        autoEmp = it.precio5_Emp3.autoEmp,
                        contenido = it.precio5_Emp3.contenido,
                        precioFullDivisa = it.precio5_Emp3.precioFullDivisa,
                        precioNeto = it.precio5_Emp3.precioNeto,
                        utilidad = it.precio5_Emp3.utilidad,
                    };
                };

                var pm = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecios()
                {
                    autoPrd = it.autoPrd,
                    precio1_Emp1 = p1_1,
                    precio1_Emp2 = p1_2,
                    precio1_Emp3 = p1_3,
                    //
                    precio2_Emp1 = p2_1,
                    precio2_Emp2 = p2_2,
                    precio2_Emp3 = p2_3,
                    //
                    precio3_Emp1 = p3_1,
                    precio3_Emp2 = p3_2,
                    precio3_Emp3 = p3_3,
                    //
                    precio4_Emp1 = p4_1,
                    precio4_Emp2 = p4_2,
                    precio4_Emp3 = p4_3,
                    //
                    precio5_Emp1 = p5_1,
                    precio5_Emp2 = p5_2,
                    precio5_Emp3 = p5_3,
                };
                preciosMod.Add(pm);
            }
            var historicoPrecios = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecioHistorico>();
            foreach (var it in docFac.prdPreciosHistorico)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecioHistorico()
                {
                    autoPrd = it.autoPrd,
                    nota = it.nota,
                    precio = it.precio,
                    precioId = it.precioId,
                    contenido = it.contenido,
                    empaque = it.empaque,
                    tasaFactorCambio = it.tasaFactorCambio,
                };
                historicoPrecios.Add(nr);
            }

            fichaDTO.documento = documento;
            fichaDTO.cxp = cxp;
            fichaDTO.detalles = detalles;
            fichaDTO.prdDeposito = prdDeposito;
            fichaDTO.prdKardex = prdKardex;
            fichaDTO.prdCosto = prdCosto;
            fichaDTO.prdCostosHistorico = prdCostoHistorico;
            fichaDTO.prdProveedor = prdProveedor;
            fichaDTO.prdPreciosMod = preciosMod;
            fichaDTO.prdPreciosHistorico = historicoPrecios;
            //
            var r01 = MyData.Compra_DocumentoAgregarFactura(fichaDTO);
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