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
        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha> 
            Compra_DocumentoVisualizar(string auto)
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
                isAnulado= s.EstatusDoc.Trim().ToUpper() =="1",
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

        public OOB.Resultado 
            Compra_DocumentoAnularFactura(OOB.LibCompra.Documento.Anular.Factura.Ficha ficha)
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

        public OOB.Resultado 
            Compra_DocumentoAnularNotaCredito(OOB.LibCompra.Documento.Anular.NotaCredito.Ficha ficha)
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
        public OOB.Resultado 
            Compra_DocumentoCorrector(OOB.LibCompra.Documento.Corrector.Ficha ficha)
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
        public OOB.ResultadoLista<OOB.LibCompra.Documento.ListaItemImportar.Ficha> 
            Compra_Documento_ItemImportar_GetLista(string autoDoc)
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
                            autoEmpCompPreDeterminado = s.autoEmpCompPreDeterminado,
                            contEmpCompPreDeterminado = s.contEmpCompPreDeterminado,
                            autoEmpInv = s.autoEmpInv,
                            contEmpInv = s.contEmpInv,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado 
            Compra_Documento_Pendiente_Agregar(OOB.LibCompra.Documento.Pendiente.Agregar.Ficha ficha)
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
                        //
                        prdEstatusDivisa = s.esAdmDivisa ? "1" : "0",
                        prdCostoActualLocal = s.prdCostoActualLocal,
                        prdCostoActualDivisa = s.prdCostoActualDivisa,
                        precioFacturaDivisa = s.precioFacturaDivisa,
                        //
                        autoEmpaque = s.autoEmpaque,
                        decimalEmpaque = s.decimalEmpaque,
                        estatusEmpCompraPredeterminado = s.estatusEmpCompraPredeterminado,
                        idEmpSeleccionado = s.idEmpSeleccionado,
                    };
                    if (s.preciosVtaPend!=null)
                    {
                        rg.preciosVtaPend = s.preciosVtaPend.Select(ss =>
                        {
                            var nr = new DtoLibCompra.Documento.Pendiente.Agregar.PrecioVtaPend()
                            {
                                contEmpVta = ss.contEmpVta,
                                descEmpVta = ss.descEmpVta,
                                idEmpqVta = ss.idEmpqVta,
                                precios = ss.precios,
                            };
                            return nr;
                        }).ToList();
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
        public OOB.ResultadoEntidad<int> 
            Compra_Documento_Pendiente_Cnt(OOB.LibCompra.Documento.Pendiente.Filtro.Ficha filtro)
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
        public OOB.ResultadoLista<OOB.LibCompra.Documento.Pendiente.Lista.Ficha> 
            Compra_Documento_Pendiente_GetLista(OOB.LibCompra.Documento.Pendiente.Filtro.Ficha filtro)
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
        public OOB.Resultado 
            Compra_Documento_Pendiente_Eliminar(int idDoc)
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
        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.Pendiente.Abrir.Ficha> 
            Compra_Documento_Pendiente_Abrir_GetById(int idDoc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.Pendiente.Abrir.Ficha>();
            //
            var r01 = MyData.Compra_Documento_Pendiente_Abrir(idDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
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
                            //
                            esAdmDivisa = s.prdEstatusDivisa == "1",
                            prdCostoActualDivisa = s.prdCostoActualDivisa,
                            prdCostoActualLocal = s.prdCostoActualLocal,
                            precioFacturaDivisa = s.precioFacturaDivisa,
                            //
                            autoEmpaque = s.autoEmpaque,
                            decimalEmpaque = s.decimalEmpaque,
                            estatusEmpCompraPredeterminado = s.estatusEmpCompraPredeterminado,
                            idEmpaqueSeleccionado = s.idEmpaqueSeleccionado,
                            //
                            preciosVtaPend = s.preciosVtaPend.Select(ss=>
                            {
                                var nr = new OOB.LibCompra.Documento.Pendiente.Abrir.PrecioVtaPend()
                                {
                                    contEmpVta = ss.contEmpVta,
                                    descEmpVta = ss.descEmpVta,
                                    idEmpqVta = ss.idEmpqVta,
                                    pVta1 = ss.pVta1,
                                    pVta2 = ss.pVta2,
                                    pVta3 = ss.pVta3,
                                    pVta4 = ss.pVta4,
                                };
                                return nr;
                            }).ToList(),
                        };
                        return rg;
                    }).ToList();
                }
            }
            doc.items = items;
            rt.Entidad = doc;
            //
            return rt;
        }
    }
}