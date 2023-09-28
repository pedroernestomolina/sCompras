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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha> 
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha>();
            var r01 = MyData.Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(idAliado);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha()
                        {
                            aliadoCiRif = s.aliadoCiRif,
                            aliadoCodigo = s.aliadoCodigo,
                            aliadoNombre = s.aliadoNombre,
                            clienteCiRif = s.clienteCiRif,
                            clienteNombre = s.clienteNombre,
                            fechaDoc = s.fechaDoc,
                            idAliado = s.idAliado,
                            idAliadoDoc = s.idAliadoDoc,
                            idAliadoServ = s.idAliadoServ,
                            importeServDiv = s.importeServDiv,
                            nombreDoc = s.nombreDoc,
                            numDoc = s.numDoc,
                            servCodigo = s.servCodigo,
                            servDesc = s.servDesc,
                            servDetalle = s.servDetalle,
                            servId = s.servId,
                            servMontoAcumuladoDiv = s.servMontoAcumuladoDiv,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.Resultado 
            Transporte_Aliado_PagoServ_AgregarPago(OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Aliado.PagoServ.AgregarPago.Ficha();
            var fm = ficha.movimiento;
            var mov = new DtoLibTransporte.Aliado.PagoServ.AgregarPago.Movimiento()
            {
                aplicaRet = fm.aplicaRet,
                ciRifAliado = fm.ciRifAliado,
                cntServ = fm.cntServ,
                codigoAliado = fm.codigoAliado,
                fechaEmision = fm.fechaEmision,
                idAliado = fm.idAliado,
                montoMonAct = fm.montoMonAct,
                montoMonDiv = fm.montoMonDiv,
                montoRetMonAct = fm.montoRetMonAct,
                montoRetMonDiv = fm.montoRetMonDiv,
                motivo = fm.motivo,
                nombreAliado = fm.nombreAliado,
                retencion = fm.retencion,
                sustraendo = fm.sustraendo,
                tasaFactorCambio = fm.tasaFactorCambio,
                tasaRet = fm.tasaRet,
                totalPagMonAct = fm.totalPagMonAct,
                totalPagMonDiv = fm.totalPagMonDiv,
            };
            var caj = ficha.movimiento.cajas.Select(s =>
            {
                var nr = new DtoLibTransporte.Aliado.PagoServ.AgregarPago.Caja()
                {
                    descCaja = s.descCaja,
                    esDivisa = s.esDivisa,
                    idCaja = s.idCaja,
                    montoUsado= s.montoUsado,
                    montoUsadoMonAct=s.montoUsadoMonAct,
                    montoUsadoMonDiv=s.montoUsadoMonDiv,
                };
                return nr;
            }).ToList();
            var det = ficha.movimiento.detalles.Select(s =>
            {
                var rg = new DtoLibTransporte.Aliado.PagoServ.AgregarPago.Detalle()
                {
                    idAliadoDoc = s.idAliadoDoc,
                    idAliadoDocServ = s.idAliadoDocServ,
                    motnoDocSerMonDiv = s.motnoDocSerMonDiv,
                };
                return rg;
            }).ToList();
            mov.detalles = det;
            mov.cajas = caj;
            fichaDTO.movimiento = mov;
            fichaDTO.MontoPorAnticipoUsado = ficha.MontoPorAnticipoUsado;
            fichaDTO.MontoPorRetAnticipoUsado = ficha.MontoPorRetAnticipoUsado;
            var r01 = MyData.Transporte_Aliado_PagoServ_AgregarPago (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
        public OOB.Resultado 
            Transporte_Aliado_PagoServ_AnularPago(int idMov)
        {
            var result = new OOB.Resultado();
            var r01 = MyData.Transporte_Aliado_PagoServ_AnularPago_ObtenerData(idMov);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var r02 = MyData.Transporte_Aliado_PagoServ_AnularPago (r01.Entidad);
            if (r02.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r02.Mensaje);
            }
            return result;
        }
        //
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha> 
            Transporte_Aliado_PagoServ_GetLista(OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha>();
            var filtroDTO = new DtoLibTransporte.Aliado.PagoServ.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
            };
            var r01 = MyData.Transporte_Aliado_PagoServ_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha()
                        {
                            cirifAliado = s.cirifAliado,
                            cntServPag = s.cntServPag,
                            estatusAnulado = s.estatusAnulado,
                            fecha = s.fecha,
                            idMov = s.idMov,
                            montoPagoSelMonDiv = s.montoPagoSelMonDiv,
                            motivo = s.motivo,
                            nombreAliado = s.nombreAliado,
                            numRecibo = s.numRecibo,
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