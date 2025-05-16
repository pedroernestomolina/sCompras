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
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha>
            Transporte_CxpDoc_GetDocPend_ById(string idCxP)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha>();
            var r01 = MyData.Transporte_CxpDoc_GetDocPend_ById(idCxP);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01 != null)
            {
                var s = r01.Entidad;
                result.Entidad = new OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha()
                {
                    acumuladoDiv = s.acumuladoDiv,
                    ciRif = s.ciRif,
                    diasCredito = s.diasCredito,
                    docNro = s.docNro,
                    fechaEmision = s.fechaEmision,
                    fechaVence = s.fechaVence,
                    id = s.id,
                    importeDiv = s.importeDiv,
                    nombreRazonSocial = s.nombreRazonSocial,
                    restaDiv = s.restaDiv,
                    signoDoc = s.signoDoc,
                    tasafactor = s.tasafactor,
                    tipoDoc = s.tipoDoc,
                    anoRelacion = s.anoRelacion,
                    autoProv = s.autoProv,
                    codProv = s.codProv,
                    codTipoDoc = s.codTipoDoc,
                    conceptoCod = s.conceptoCod,
                    conceptoDesc = s.conceptoDesc,
                    descripcionDoc = s.descripcionDoc,
                    docNroControl = s.docNroControl,
                    fechaReg = s.fechaReg,
                    mesRelacion = s.mesRelacion,
                    condicion = s.condicion,
                    dirFiscalPrv = s.dirFiscalPrv,
                    telefonoPrv = s.telefonoPrv,
                };
            }
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Resultado>
            Transporte_CxpDoc_GestionPago_Agregar(OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Ficha ficha)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Resultado>();
            var rec = ficha.Recibo;
            var fichaDTO = new DtoLibTransporte.CxpDoc.Pago.Agregar.Ficha()
            {
                Recibo = new DtoLibTransporte.CxpDoc.Pago.Agregar.DataRecibo()
                {
                    fechaEmision=rec.fechaEmision,
                    importeMonAct = rec.importeMonAct,
                    importeDivisa = rec.importeDivisa,
                    montoRecibidoMonAct = rec.montoRecibidoMonAct,
                    montoRecibidoDivisa = rec.montoRecibidoDivisa,
                    nota = rec.nota,
                    prvAuto = rec.prvAuto,
                    prvCiRif = rec.prvCiRif,
                    prvCodigo = rec.prvCodigo,
                    prvDirFiscal = rec.prvDirFiscal,
                    prvNombre = rec.prvNombre,
                    prvTlf = rec.prvTlf,
                    tasaCambio = rec.tasaCambio,
                    usuarioAuto = rec.usuarioAuto,
                    usuarioNombre = rec.usuarioNombre,
                    autoSistemaDoc = rec.autoSistemaDoc,
                    codSistemaDoc = rec.codSistemaDoc,
                    guardarComoAnticipoProv =rec.guardarComoAnticipoProv,
                    anticipoUsado=rec.anticipoUsado,
                    reciboDoc = rec.reciboDoc.Select(s =>
                    {
                        var nr = new DtoLibTransporte.CxpDoc.Pago.Agregar.DataReciboDoc()
                        {
                            autoCxpDoc = s.autoCxpDoc,
                            codTipoDc = s.codTipoDc,
                            importeDivisa = s.importeDivisa,
                            numDoc = s.numDoc,
                        };
                        return nr;
                    }).ToList(),
                    metPago = rec.metpago.Select(ss => 
                    {
                        var mt = new DtoLibTransporte.CxpDoc.Pago.Agregar.DataReciboMetodoPago()
                        {
                            autoMedPago = ss.autoMedPago,
                            autoUsuario = ss.autoUsuario,
                            codigoMedPago = ss.codigoMedPago,
                            descMedPago = ss.descMedPago,
                            OpAplicaConversion = ss.OpAplicaConversion,
                            OpBanco = ss.OpBanco,
                            OpDetalle = ss.OpDetalle,
                            OpFecha = ss.OpFecha,
                            OpLote = ss.OpLote,
                            OpMonto = ss.OpMonto,
                            OpNroCta = ss.OpNroCta,
                            OpNroTransf = ss.OpNroTransf,
                            OpRef = ss.OpRef,
                            OpTasa = ss.OpTasa,
                            montoAplicaDiv= ss.montoAplicaDiv,
                        };
                        return mt;
                    }).ToList(),
                },
            };
            if (ficha.Cajas != null)
            {
                var lt = new List<DtoLibTransporte.CxpDoc.Pago.Agregar.DataCaja>();
                foreach (var rg in ficha.Cajas)
                {
                    var mv = new DtoLibTransporte.CxpDoc.Pago.Agregar.DataCaja() 
                    {
                        idCaja = rg.idCaja,
                        codCaja = rg.codCaja,
                        descCaja = rg.descCaja,
                        monto = rg.monto,
                        cajaMov = new DtoLibTransporte.CxpDoc.Pago.Agregar.CajaMov()
                        {
                            descMov = rg.cajaMov.descMov,
                            factorCambio = rg.cajaMov.factorCambio,
                            montoMovMonAct = rg.cajaMov.montoMovMonAct,
                            montoMovMonDiv = rg.cajaMov.montoMovMonDiv,
                            movFueDivisa = rg.cajaMov.movFueDivisa,
                        },
                    };
                    lt.Add(mv);
                }
                fichaDTO.Cajas = lt;
            }
            var r01 = MyData.Transporte_CxpDoc_GestionPago_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Resultado()
            {
                autoRecibo = r01.Entidad.autoRecibo,
            };
            return result;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha> 
            Transporte_CxpDoc_GetLista_PagosEmitidos(OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha>();
            var filtroDTO = new DtoLibTransporte.CxpDoc.Pago.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                EstatusDoc = (DtoLibTransporte.CxpDoc.Pago.Lista.enumerados.EstatusDoc)filtro.EstatusDoc,
                IdProveedor = filtro.IdProveedor
            };
            var r01 = MyData.Transporte_CxpDoc_GetLista_PagosEmitidos(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha>();
            if (r01 != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha()
                        {
                            fecha = s.fecha,
                            importe = s.importe,
                            nota = s.nota,
                            provCiRif = s.provCiRif,
                            provNombre = s.provNombre,
                            reciboNro = s.reciboNro,
                            tasaFactor = s.tasaFactor,
                            estatusDoc = s.estatusDoc,
                            idMov = s.idMov,
                            anticipoGuardado= s.anticipoGuardado,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        //
        public OOB.Resultado 
            Transporte_CxpDoc_GestionPago_Anular(OOB.LibCompra.Transporte.CxpDoc.Pago.Anular.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var r01 = MyData.Transporte_CxpDoc_GestionPago_Anular_ObtenerData(ficha.idRecibo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad.tipoDoc.Trim().ToUpper() != "PAG") 
            {
                throw new Exception("SOLO SE PERMITE ANULAR TIPO DE DOCUMENTOS PAGO");
            }
            r01.Entidad.auditoria = new DtoLibTransporte.CxpDoc.Pago.Anular.Auditoria()
            {
                autoUsuario = ficha.auditoria.autoUsuario,
                codigoUsuario = ficha.auditoria.codigoUsuario,
                estacionEquipo = ficha.auditoria.estacionEquipo,
                motivo = ficha.auditoria.motivo,
                nombreUsuario = ficha.auditoria.nombreUsuario,
            };
            var r02 = MyData.Transporte_CxpDoc_GestionPago_Anular(r01.Entidad);
            if (r02.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
    }
}