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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha> 
            Transporte_Reportes_Compras_Retenciones_GetLista(OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha>();
            var filtroDTO = new DtoLibTransporte.Reportes.Compras.Retencion.Filtro()
            {
                tipoRet = (DtoLibTransporte.Reportes.Compras.enumerados.tipoRetencion)filtro.tipoRet,
            };
            var r01 = MyData.Transporte_Reportes_Compras_Retenciones_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha()
                        {
                            fechaDoc = s.fechaDoc,
                            idDoc = s.idDoc,
                            montoBase1 = s.montoBase1,
                            montoBase2 = s.montoBase2,
                            montoBase3 = s.montoBase3,
                            montoExento = s.montoExento,
                            montoImp1 = s.montoImp1,
                            montoImp2 = s.montoImp2,
                            montoImp3 = s.montoImp3,
                            numDoc = s.numDoc,
                            prvCiRif = s.prvCiRif,
                            prvNombre = s.prvNombre,
                            retMonto = s.retMonto,
                            retSustraendo = s.retSustraendo,
                            tasaRet = s.tasaRet,
                            totalDoc = s.totalDoc,
                            totalRet = s.totalRet,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha> 
            Transporte_Reportes_Compras_GeneralDoc_GetLista(OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha>();
            var filtroDTO = new DtoLibTransporte.Reportes.Compras.GeneralDoc.Filtro()
            {
            };
            var r01 = MyData.Transporte_Reportes_Compras_GeneralDoc_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha()
                        {
                            anoRel = s.anoRel,
                            desConcepto = s.desConcepto,
                            estatusDoc = s.estatusDoc,
                            fechaDoc = s.fechaDoc,
                            fechaReg = s.fechaReg,
                            idDoc = s.idDoc,
                            mesRel = s.mesRel,
                            montoDiv = s.montoDiv,
                            netoDoc = s.netoDoc,
                            prvCiRif = s.prvCiRif,
                            prvNombre = s.prvNombre,
                            siglasDoc = s.siglasDoc,
                            signoDoc = s.signoDoc,
                            totalDoc = s.totalDoc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha> 
            Transporte_Reportes_Compras_Planilla_RetIva(string idDocCompra)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>();
            var r01 = MyData.Transporte_Reportes_Compras_Planilla_RetIva(idDocCompra);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha()
            {
                anoRelRet = s.anoRelRet,
                aplica = s.aplica,
                base1 = s.base1,
                base2 = s.base2,
                base3 = s.base3,
                comprobanteRet = s.comprobanteRet,
                exento = s.exento,
                fechaEmiDoc = s.fechaEmiDoc,
                fechaRet = s.fechaRet,
                impuesto1 = s.impuesto1,
                impuesto2 = s.impuesto2,
                impuesto3 = s.impuesto3,
                mesRelRet = s.mesRelRet,
                totalRet = s.totalRet,
                numControlDoc = s.numControlDoc,
                numDoc = s.numDoc,
                prvCiRif = s.prvCiRif,
                prvNombre = s.prvNombre,
                retencion1 = s.retencion1,
                retencion2 = s.retencion2,
                retencion3 = s.retencion3,
                tasa1 = s.tasa1,
                tasa2 = s.tasa2,
                tasa3 = s.tasa3,
                tasaRet = s.tasaRet,
                tipoDoc = s.tipoDoc,
                total = s.total,
            };
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIslr(string idDocCompra)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>();
            var r01 = MyData.Transporte_Reportes_Compras_Planilla_RetIslr(idDocCompra);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha()
            {
                anoRelRet = s.anoRelRet,
                aplica = s.aplica,
                base1 = s.base1,
                base2 = s.base2,
                base3 = s.base3,
                comprobanteRet = s.comprobanteRet,
                exento = s.exento,
                fechaEmiDoc = s.fechaEmiDoc,
                fechaRet = s.fechaRet,
                impuesto1 = s.impuesto1,
                impuesto2 = s.impuesto2,
                impuesto3 = s.impuesto3,
                mesRelRet = s.mesRelRet,
                totalRet = s.totalRet,
                numControlDoc = s.numControlDoc,
                numDoc = s.numDoc,
                prvCiRif = s.prvCiRif,
                prvNombre = s.prvNombre,
                retencion1 = s.retencion1,
                retencion2 = s.retencion2,
                retencion3 = s.retencion3,
                tasa1 = s.tasa1,
                tasa2 = s.tasa2,
                tasa3 = s.tasa3,
                tasaRet = s.tasaRet,
                tipoDoc = s.tipoDoc,
                total = s.total,
                conceptoCod = s.conceptoCod,
                conceptoDoc = s.conceptoDoc,
                dirFiscal = s.dirFiscal,
                subtRet = s.subtRet,
                sustraendoRet = s.sustraendoRet,
            };
            return result;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Ficha> 
            Transporte_Reportes_Aliado_Anticipos_GetLista(OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Ficha>();
            var filtroDTO = new DtoLibTransporte.Reportes.Aliado.Anticipo.General.Filtro()
            {
            };
            var r01 = MyData.Transporte_Reportes_Aliado_Anticipos_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Ficha()
                        {
                            aplicaRet = s.aplicaRet,
                            ciRifAliado = s.ciRifAliado,
                            estatusAnulado = s.estatusAnulado,
                            factorCambio = s.factorCambio,
                            fecha = s.fecha,
                            idAliado = s.idAliado,
                            idMov = s.idMov,
                            montoPagoDiv = s.montoPagoDiv,
                            montoAntSolicitadoDiv = s.montoAntSolicitadoDiv,
                            montoRetMonAct = s.montoRetMonAct,
                            motivo = s.motivo,
                            nombreAliado = s.nombreAliado,
                            numRecibo = s.numRecibo,
                            sustraendoMonAct = s.sustraendoMonAct,
                            tasaRet = s.tasaRet,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha> 
            Transporte_Reportes_Aliado_PagoServ_GetLista(OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha>();
            var filtroDTO = new DtoLibTransporte.Reportes.Aliado.PagoServ.General.Filtro()
            {
            };
            var r01 = MyData.Transporte_Reportes_Aliado_PagoServ_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha()
                        {
                            aplicaRet = s.aplicaRet,
                            cirifAliado = s.cirifAliado,
                            cntServPag = s.cntServPag,
                            codigoAliado = s.codigoAliado,
                            estatusAnulado = s.estatusAnulado,
                            fecha = s.fecha,
                            idAliado = s.idAliado,
                            idMov = s.idMov,
                            montoPagoSelMonDiv = s.montoPagoSelMonDiv,
                            montoRetMonAct = s.montoRetMonAct,
                            motivo = s.motivo,
                            nombreAliado = s.nombreAliado,
                            numRecibo = s.numRecibo,
                            retencion = s.retencion,
                            sustraendo = s.sustraendo,
                            tasaFactor = s.tasaFactor,
                            tasaRet = s.tasaRet,
                            totalPagoMonDiv = s.totalPagoMonDiv,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.Planilla.Ficha>
            Transporte_Reportes_Aliado_Anticipos_Planilla(int idMov)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.Planilla.Ficha>();
            var r01 = MyData.Transporte_Reportes_Aliado_Anticipos_Planilla(idMov);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s= r01.Entidad;
            var nr = new OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.Planilla.Ficha()
            {
                aplicaRet = s.aplicaRet,
                ciRifAliado = s.ciRifAliado,
                fechaEmision = s.fechaEmision,
                fechaRegistro = s.fechaRegistro,
                montoPagado = s.montoPagado,
                montoRet = s.montoRet,
                montoSolicitado = s.montoSolicitado,
                motivo = s.motivo,
                nombreAliado = s.nombreAliado,
                numRecibo = s.numRecibo,
                sustraendo = s.sustraendo,
                tasaFactor = s.tasaFactor,
                tasaRet = s.tasaRet,
            };
            result.Entidad = nr;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Ficha> 
            Transporte_Reportes_Aliado_PagoServ_Planilla(int idMov)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Ficha>();
            var r01 = MyData.Transporte_Reportes_Aliado_PagoServ_Planilla(idMov);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Ficha()
            {
                aplicaRet = s.aplicaRet,
                ciRifAliado = s.ciRifAliado,
                cntServ = s.cntServ,
                fechaEmision = s.fechaEmision,
                fechaRegistro = s.fechaRegistro,
                montoAPagar = s.montoAPagar,
                montoRetMonAct = s.montoRetMonAct,
                montoRetMonDiv = s.montoRetMonDiv,
                motivo = s.motivo,
                nombreAliado = s.nombreAliado,
                numRecibo = s.numRecibo,
                retencion = s.retencion,
                sustraendo = s.sustraendo,
                tasaFactor = s.tasaFactor,
                tasaRet = s.tasaRet,
                totalPago = s.totalPago,
                serv = s.serv.Select(ss => 
                {
                    var xr = new OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Serv()
                    {
                        cliCiRif = ss.cliCiRif,
                        cliNombre = ss.cliNombre,
                        codServ = ss.codServ,
                        descServ = ss.descServ,
                        detServ = ss.detServ,
                        docCodigo = ss.docCodigo,
                        docFecha = ss.docFecha,
                        docNombre = ss.docNombre,
                        docNumero = ss.docNumero,
                        montoPago = ss.montoPago,
                    };
                    return xr;
                }).ToList(),
            };
            result.Entidad = nr;
            return result;
        }

        //CAJAS
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha> 
            Transporte_Reportes_Caja_Movimientos_GetLista(OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha>();
            var filtroDTO = new DtoLibTransporte.Reportes.Caja.Movimiento.Filtro()
            {
            };
            var r01 = MyData.Transporte_Reportes_Caja_Movimientos_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha()
                        {
                            cjDesc = s.cjDesc,
                            cjEsDivisa = s.cjEsDivisa,
                            estatusAnulado = s.estatusAnulado,
                            factorCambio = s.factorCambio,
                            fechaMov = s.fechaMov,
                            idCaja = s.idCaja,
                            idMov = s.idMov,
                            montoMonAct = s.montoMonAct,
                            montoMonDiv = s.montoMonDiv,
                            motivoMov = s.motivoMov,
                            movFueDivisa = s.movFueDivisa,
                            signoMov = s.signoMov,
                            tipoMov = s.tipoMov,
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