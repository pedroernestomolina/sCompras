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

        public OOB.ResultadoAuto Compra_DocumentoAgregarFactura(OOB.LibCompra.Documento.Cargar.Factura.Ficha docFac)
        {
            var result = new OOB.ResultadoAuto();

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
            };
            var xcxp= docFac.cxp;
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
                };
                prdKardex.Add(nr);
            }
            var prdCosto = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdCosto>();
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
            var prdCostoHistorico = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdCostoHistorico>();
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
            var prdPrecio = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecio>();
            foreach (var it in docFac.prdPrecios)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecio()
                {
                    autoPrd = it.autoPrd,
                    pDivisaFull_1 = it.pDivisaFull_1,
                    pDivisaFull_2 = it.pDivisaFull_2,
                    pDivisaFull_3 = it.pDivisaFull_3,
                    pDivisaFull_4 = it.pDivisaFull_4,
                    pDivisaFull_5 = it.pDivisaFull_5,
                    precioNeto_1 = it.precioNeto_1,
                    precioNeto_2 = it.precioNeto_2,
                    precioNeto_3 = it.precioNeto_3,
                    precioNeto_4 = it.precioNeto_4,
                    precioNeto_5 = it.precioNeto_5,
                    //
                    pDivisaFull_May_1 = it.pDivisaFull_may_1,
                    pDivisaFull_May_2 = it.pDivisaFull_may_2,
                    precioNeto_May_1 = it.precioNeto_may_1,
                    precioNeto_May_2 = it.precioNeto_may_2,
                };
                prdPrecio.Add(nr);
            }
            var prdPrecioHistorico = new List<DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecioHistorico>();
            foreach (var it in docFac.prdPreciosHistorico)
            {
                var nr = new DtoLibCompra.Documento.Agregar.Factura.FichaPrdPrecioHistorico()
                {
                    autoPrd = it.autoPrd,
                    nota = it.nota,
                    precio = it.precio,
                    precioId = it.precioId,
                };
                prdPrecioHistorico.Add(nr);
            }

            fichaDTO.documento = documento;
            fichaDTO.cxp = cxp;
            fichaDTO.detalles=detalles;
            fichaDTO.prdDeposito=prdDeposito;
            fichaDTO.prdKardex = prdKardex;
            fichaDTO.prdCosto = prdCosto;
            fichaDTO.prdCostosHistorico = prdCostoHistorico;
            fichaDTO.prdProveedor = prdProveedor;
            fichaDTO.prdPrecios = prdPrecio;
            fichaDTO.prdPreciosHistorico = prdPrecioHistorico;

            var r01 = MyData.Compra_DocumentoAgregarFactura(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha> Compra_DocumentoVisualizar(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha>();

            var r01 = MyData.Compra_DocumentoVisualizar(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Documento.Visualizar.Ficha()
            {
                anoRelacion = s.anoRelacion,
                cargoPorct = s.cargoPorct,
                controlNro = s.controlNro,
                descuentoPorct = s.descuentoPorct,
                diasCredito = s.diasCredito,
                documentoNombre = s.documentoNombre,
                documentoNro = s.documentoNro,
                documentoSerie = s.documentoSerie,
                documentoTipo= s.documentoTipo,
                equipoEstacion = s.equipoEstacion,
                factorCambio = s.factorCambio,
                fechaEmision = s.fechaEmision,
                fechaRegistro = s.fechaRegistro,
                fechaVencimiento = s.fechaVencimiento,
                mesRelacion = s.mesRelacion,
                montoBase = s.montoBase,
                montoBase1 = s.montoBase1,
                montoBase2 = s.montoBase2,
                montoBase3 = s.montoBase3,
                montoCargo = s.montoCargo,
                montoDescuento = s.montoDescuento,
                montoDivisa = s.montoDivisa,
                montoExento = s.montoExento,
                montoImpuesto = s.montoImpuesto,
                montoTotal = s.montoTotal,
                notas = s.notas,
                ordenCompraNro = s.ordenCompraNro,
                provCiRif = s.provCiRif,
                provCodigo = s.provCodigo,
                provDirFiscal = s.provDirFiscal,
                provNombre = s.provNombre,
                provTelefono = s.provTelefono,
                renglones = s.renglones,
                signo = s.signo,
                subTotal = s.subTotal,
                tasaIva1 = s.tasaIva1,
                tasaIva2 = s.tasaIva2,
                tasaIva3 = s.tasaIva3,
                usuarioCodigo = s.usuarioCodigo,
                usuarioNombre = s.usuarioNombre,
                montoIva1=s.montoIva1,
                montoIva2=s.montoIva2,
                montoIva3=s.montoIva3,
                horaRegistro=s.horaRegistro,
                aplica=s.aplica,
            };
            var det = s.detalles.Select(ss =>
            {
                var dt = new OOB.LibCompra.Documento.Visualizar.FichaDetalle()
                {
                    cntFactura = ss.cntFactura,
                    contenido = ss.contenido,
                    depositoCodigo = ss.depositoCodigo,
                    depositoNombre = ss.depositoNombre,
                    dscto1m = ss.dscto1m,
                    dscto1p = ss.dscto1p,
                    dscto2m = ss.dscto2m,
                    dscto2p = ss.dscto2p,
                    dscto3m = ss.dscto3m,
                    dscto3p = ss.dscto3p,
                    empaqueCompra = ss.empaqueCompra,
                    importe = ss.importe,
                    prdCodigo = ss.prdCodigo,
                    prdNombre = ss.prdNombre,
                    precioFactura = ss.precioFactura,
                    tasaIva = ss.tasaIva,
                };
                return dt;
            }).ToList();
            nr.detalles = det;
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Documento.Lista.Ficha> Compra_DocumentoGetLista(OOB.LibCompra.Documento.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Documento.Lista.Ficha>();

            var filtroDto = new DtoLibCompra.Documento.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                CodigoSuc = filtro.CodigoSuc,
                TipoDocumento = (DtoLibCompra.Enumerados.enumTipoDocumento)filtro.TipoDocumento,
                idProveedor=filtro.idProveedor,
            };
            var r01 = MyData.Compra_DocumentoGetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Documento.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Documento.Lista.Ficha()
                        {
                            auto = s.auto,
                            codigoSuc = s.codigoSuc,
                            esAnulado = s.esAnulado,
                            fechaEmision = s.fechaEmision,
                            fechaRegistro = s.fechaRegistro,
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            provCiRif = s.provCiRif,
                            provNombre = s.provNombre,
                            situacion = s.situacion,
                            tipoDoc = (OOB.LibCompra.Documento.Enumerados.enumTipoDocumento)s.tipoDoc,
                            tipoDocNombre = s.tipoDocNombre,
                            documentoNro = s.documento,
                            codigoTipo = s.tipo,
                            Signo = s.signo,
                            ControlNro= s.control,
                            Aplica=s.aplica,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Compra_DocumentoAnularFactura(OOB.LibCompra.Documento.Anular.Factura.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Documento.Anular.Factura.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                codigoDocumento = ficha.codigoDocumento,
                auditoria = new DtoLibCompra.Documento.Anular.Factura.FichaAuditoria()
                {
                    autoSistemaDocumento = ficha.autoSistemaDocumento,
                    autoUsuario = ficha.autoUsuario,
                    codigo = ficha.codigoUsuario,
                    estacion = ficha.estacion,
                    motivo = ficha.motivo,
                    usuario = ficha.nombreUsuario,
                }
            };
            var r01 = MyData.Compra_DocumentoAnularFactura(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Documento.ListaRemision.Ficha> Compra_DocumentoGetListaRemision(OOB.LibCompra.Documento.ListaRemision.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Documento.ListaRemision.Ficha>();

            var filtroDto = new DtoLibCompra.Documento.ListaRemision.Filtro()
            {
                autoProveedor = filtro.autoProveedor,
            };
            var r01 = MyData.Compra_DocumentoGetListaRemision(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Documento.ListaRemision.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Documento.ListaRemision.Ficha()
                        {
                            auto = s.auto,
                            control = s.control,
                            docNombre = s.docNombre,
                            docNro = s.docNro,
                            docTipo = s.docTipo,
                            fechaEmision = s.fechaEmision,
                            montoDivisa = s.montoDivisa,
                            total = s.total,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.Ficha> Compra_DocumentoGetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.Ficha>();

            var r01 = MyData.Compra_DocumentoGetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Documento.GetData.Ficha()
            {
                anoRelacion = s.anoRelacion,
                cargoPorct = s.cargoPorct,
                controlNro = s.controlNro,
                descuentoPorct = s.descuentoPorct,
                diasCredito = s.diasCredito,
                documentoNombre = s.documentoNombre,
                documentoNro = s.documentoNro,
                documentoSerie = s.documentoSerie,
                equipoEstacion = s.equipoEstacion,
                factorCambio = s.factorCambio,
                fechaEmision = s.fechaEmision,
                fechaRegistro = s.fechaRegistro,
                fechaVencimiento = s.fechaVencimiento,
                mesRelacion = s.mesRelacion,
                montoBase = s.montoBase,
                montoBase1 = s.montoBase1,
                montoBase2 = s.montoBase2,
                montoBase3 = s.montoBase3,
                montoCargo = s.montoCargo,
                montoDescuento = s.montoDescuento,
                montoDivisa = s.montoDivisa,
                montoExento = s.montoExento,
                montoImpuesto = s.montoImpuesto,
                montoTotal = s.montoTotal,
                notas = s.notas,
                ordenCompraNro = s.ordenCompraNro,
                provCiRif = s.provCiRif,
                provCodigo = s.provCodigo,
                provDirFiscal = s.provDirFiscal,
                provNombre = s.provNombre,
                provTelefono = s.provTelefono,
                renglones = s.renglones,
                signo = s.signo,
                subTotal = s.subTotal,
                tasaIva1 = s.tasaIva1,
                tasaIva2 = s.tasaIva2,
                tasaIva3 = s.tasaIva3,
                usuarioCodigo = s.usuarioCodigo,
                usuarioNombre = s.usuarioNombre,
                montoIva1 = s.montoIva1,
                montoIva2 = s.montoIva2,
                montoIva3 = s.montoIva3,
                horaRegistro = s.horaRegistro,
                autoId = s.autoId,
                documentoTipo = s.documentoTipo,
                provAuto = s.provAuto,
                codigoSucursal = s.codigoSucursal,
            };
            var det = s.detalles.Select(ss =>
            {
                var dt = new OOB.LibCompra.Documento.GetData.FichaDetalle()
                {
                    cntFactura = ss.cntFactura,
                    contenido = ss.contenido,
                    depositoAuto = ss.depositoAuto,
                    depositoCodigo = ss.depositoCodigo,
                    depositoNombre = ss.depositoNombre,
                    dscto1m = ss.dscto1m,
                    dscto1p = ss.dscto1p,
                    dscto2m = ss.dscto2m,
                    dscto2p = ss.dscto2p,
                    dscto3m = ss.dscto3m,
                    dscto3p = ss.dscto3p,
                    empaqueCompra = ss.empaqueCompra,
                    importe = ss.importe,
                    prdCodigo = ss.prdCodigo,
                    prdNombre = ss.prdNombre,
                    precioFactura = ss.precioFactura,
                    tasaIva = ss.tasaIva,
                    prdAuto = ss.prdAuto,
                    CodRefPrv = ss.codigoReferenciaProveedor,
                    prdAutoDepartamento = ss.prdAutoDepartamento,
                    prdAutoGrupo = ss.prdAutoGrupo,
                    prdAutoTasaIva = ss.prdAutoTasaIva,
                    decimales = ss.decimales,
                    categoria = ss.categoria,
                };
                return dt;
            }).ToList();
            nr.detalles = det;
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Compra_DocumentoAgregarNC(OOB.LibCompra.Documento.Agregar.NotaCredito.Ficha docNC)
        {
            var result = new OOB.ResultadoAuto();

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
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.Resultado Compra_DocumentoAnularNotaCredito(OOB.LibCompra.Documento.Anular.NotaCredito.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Documento.Anular.NotaCredito.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                codigoDocumento = ficha.codigoDocumento,
                auditoria = new DtoLibCompra.Documento.Anular.NotaCredito.FichaAuditoria()
                {
                    autoSistemaDocumento = ficha.autoSistemaDocumento,
                    autoUsuario = ficha.autoUsuario,
                    codigo = ficha.codigoUsuario,
                    estacion = ficha.estacion,
                    motivo = ficha.motivo,
                    usuario = ficha.nombreUsuario,
                }
            };
            var r01 = MyData.Compra_DocumentoAnularNotaCredito(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Compra_DocumentoCorrector(OOB.LibCompra.Documento.Corrector.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Documento.Corrector.Factura.Ficha()
            {
                autoDoc = ficha.autoDoc,
                autoProveedor = ficha.autoProveedor,
                ciRifProveedor = ficha.ciRifProveedor,
                controlNro = ficha.controlNro,
                direccionFiscalProveedor = ficha.direccionFiscalProveedor,
                documentoNro = ficha.documentoNro,
                fechaDocumento = ficha.fechaDocumento,
                nombreRazonSocialProveedor = ficha.nombreRazonSocialProveedor,
                notaDocumento = ficha.notaDocumento,
            };
            var r01 = MyData.Compra_DocumentoCorrectorFactura(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Documento.ListaItemImportar.Ficha> Compra_Documento_ItemImportar_GetLista(string autoDoc)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Documento.ListaItemImportar.Ficha>();

            var r01 = MyData.Compra_Documento_ItemImportar_GetLista(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Documento.ListaItemImportar.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Documento.ListaItemImportar.Ficha()
                        {
                            categoria = s.categoria,
                            cntFactura = s.cntFactura,
                            codRefProv = s.codRefProv,
                            contenidoEmp = s.contenidoEmp,
                            decimales = s.decimales,
                            dscto1p = s.dscto1p,
                            dscto2p = s.dscto2p,
                            dscto3p = s.dscto3p,
                            empaqueCompra = s.empaqueCompra,
                            estatusUnidad = s.estatusUnidad,
                            prdAuto = s.prdAuto,
                            prdAutoDepartamento = s.prdAutoDepartamento,
                            prdAutoGrupo = s.prdAutoGrupo,
                            prdAutoSubGrupo = s.prdAutoSubGrupo,
                            prdAutoTasaIva = s.prdAutoTasaIva,
                            prdCodigo = s.prdCodigo,
                            prdNombre = s.prdNombre,
                            precioFactura = s.precioFactura,
                            tasaIva = s.tasaIva,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Compra_Documento_Pendiente_Agregar(OOB.LibCompra.Documento.Pendiente.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Documento.Pendiente.Agregar.Ficha()
            {
                docFactorCambio = ficha.docFactorCambio,
                docItemsNro = ficha.docItemsNro,
                docMonto = ficha.docMonto,
                docMontoDivisa = ficha.docMontoDivisa,
                docNombre = ficha.docNombre,
                docTipo = ficha.docTipo,
                docNumero = ficha.docNumero,
                docControl = ficha.docControl,
                entidadCiRif = ficha.entidadCiRif,
                entidadNombre = ficha.entidadNombre,
                usuarioId = ficha.usuarioId,
                usuarioNombre = ficha.usuarioNombre,
                autoDeposito = ficha.autoDeposito,
                autoSucursal = ficha.autoSucursal,
                docDiasCredito = ficha.docDiasCredito,
                docFechaEmision = ficha.docFechaEmision,
                docNotas = ficha.docNotas,
                docOrdenCompra = ficha.docOrdenCompra,
                entidadAuto = ficha.entidadAuto,
                entidadCodigo = ficha.entidadCodigo,
                entidadDirFiscal = ficha.entidadDirFiscal,
                items = ficha.items.Select(s =>
                {
                    var rg = new DtoLibCompra.Documento.Pendiente.Agregar.FichaDetalle()
                    {
                        categoria = s.categoria,
                        cntFactura = s.cntFactura,
                        codRefProv = s.codRefProv,
                        contenidoEmp = s.contenidoEmp,
                        decimales = s.decimales,
                        dscto1p = s.dscto1p,
                        dscto2p = s.dscto2p,
                        dscto3p = s.dscto3p,
                        empaqueCompra = s.empaqueCompra,
                        estatusUnidad = s.estatusUnidad,
                        prdAuto = s.prdAuto,
                        prdAutoDepartamento = s.prdAutoDepartamento,
                        prdAutoGrupo = s.prdAutoGrupo,
                        prdAutoSubGrupo = s.prdAutoSubGrupo,
                        prdAutoTasaIva = s.prdAutoTasaIva,
                        prdCodigo = s.prdCodigo,
                        prdNombre = s.prdNombre,
                        precioFactura = s.precioFactura,
                        tasaIva = s.tasaIva,
                    };
                    return rg;
                }).ToList(),
            };
            var r01 = MyData.Compra_Documento_Pendiente_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.ResultadoEntidad<int> Compra_Documento_Pendiente_Cnt(OOB.LibCompra.Documento.Pendiente.Filtro.Ficha filtro)
        {
            var result = new OOB.ResultadoEntidad<int>();

            var fichaDTO = new DtoLibCompra.Documento.Pendiente.Filtro.Ficha()
            {
                idUsuario = filtro.idUsuario,
                docTipo = filtro.docTipo,
            };
            var r01 = MyData.Compra_Documento_Pendiente_Cnt(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad = r01.Entidad;

            return result;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Documento.Pendiente.Lista.Ficha> Compra_Documento_Pendiente_GetLista(OOB.LibCompra.Documento.Pendiente.Filtro.Ficha filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Documento.Pendiente.Lista.Ficha>();

            var filtroDTO = new DtoLibCompra.Documento.Pendiente.Filtro.Ficha()
            {
                docTipo = filtro.docTipo,
                idUsuario = filtro.idUsuario,
            };
            var r01 = MyData.Compra_Documento_Pendiente_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Documento.Pendiente.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Documento.Pendiente.Lista.Ficha()
                        {
                            docControl = s.docControl,
                            docFactorCambio = s.docFactorCambio,
                            docItemsNro = s.docItemsNro,
                            docMonto = s.docMonto,
                            docMontoDivisa = s.docMontoDivisa,
                            docNombre = s.docNombre,
                            docNumero = s.docNumero,
                            docTipo = s.docTipo,
                            entidadCiRif = s.entidadCiRif,
                            entidadNombre = s.entidadNombre,
                            id = s.id,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Compra_Documento_Pendiente_Eliminar(int idDoc)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Compra_Documento_Pendiente_Eliminar(idDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.Pendiente.Abrir.Ficha> Compra_Documento_Pendiente_Abrir_GetById(int idDoc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.Pendiente.Abrir.Ficha>();

            var r01 = MyData.Compra_Documento_Pendiente_Abrir(idDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var doc = new OOB.LibCompra.Documento.Pendiente.Abrir.Ficha()
            {
                docControl = ent.docControl,
                docDiasCredito = ent.docDiasCredito,
                docFactorCambio = ent.docFactorCambio,
                docNumero = ent.docNumero,
                entidadAuto = ent.entidadAuto,
                entidadCiRif = ent.entidadCiRif,
                entidadCodigo = ent.entidadCodigo,
                entidadDirFiscal = ent.entidadDirFiscal,
                entidadNombre = ent.entidadNombre,
                autoDeposito = ent.autoDeposito,
                autoSucursal = ent.autoSucursal,
                docFechaEmision = ent.docFechaEmision,
                docNotas = ent.docNotas,
                docOrdenCompra = ent.docOrdenCompra,
            };
            var items = new List<OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle>();
            if (ent.items != null)
            {
                if (ent.items.Count > 0) 
                {
                    items = ent.items.Select(s =>
                    {
                        var rg = new OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle()
                        {
                            categoria = s.categoria,
                            cntFactura = s.cntFactura,
                            codRefProv = s.codRefProv,
                            contenidoEmp = s.contenidoEmp,
                            decimales = s.decimales,
                            dscto1p = s.dscto1p,
                            dscto2p = s.dscto2p,
                            dscto3p = s.dscto3p,
                            empaqueCompra = s.empaqueCompra,
                            estatusUnidad = s.estatusUnidad,
                            prdAuto = s.prdAuto,
                            prdAutoDepartamento = s.prdAutoDepartamento,
                            prdAutoGrupo = s.prdAutoGrupo,
                            prdAutoSubGrupo = s.prdAutoSubGrupo,
                            prdAutoTasaIva = s.prdAutoTasaIva,
                            prdCodigo = s.prdCodigo,
                            prdNombre = s.prdNombre,
                            precioFactura = s.precioFactura,
                            tasaIva = s.tasaIva,
                        };
                        return rg;
                    }).ToList();
                }
            }
            doc.items = items;
            rt.Entidad = doc;

            return rt;
        }

    }

}