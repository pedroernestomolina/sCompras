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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha> 
            Transporte_Caja_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha>();
            var r01 = MyData.Transporte_Caja_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Caja.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Caja.Lista.Ficha()
                        {
                            id = s.id,
                            descripcion = s.descripcion,
                            estatusAnulado = s.estatusAnulado,
                            montoPorAnulaciones = s.montoPorAnulaciones,
                            montoPorEgresos = s.montoPorEgresos,
                            montoPorIngresos = s.montoPorIngresos,
                            saldoInicial = s.saldoInicial,
                            esDivisa= s.esDivisa
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }

        //MOVIMIENTOS
        public OOB.Resultado 
            Transporte_Caja_Movimientos_Agregar(OOB.LibCompra.Transporte.Caja.Movimiento.Crud.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Caja.Movimiento.Crud.Agregar.Ficha()
            {
                descMov = ficha.descMov,
                factorCambio = ficha.factorCambio,
                idCaja = ficha.idCaja,
                montoMov = ficha.montoMov,
                montoMovMonAct = ficha.montoMovMonAct,
                montoMovMonDiv = ficha.montoMovMonDiv,
                movFueDivisa = ficha.movFueDivisa,
                signoMov = ficha.signoMov,
                tipoMov = ficha.tipoMov,
            };
            var r01 = MyData.Transporte_Caja_Movimientos_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha> 
            Transporte_Caja_Movimientos_GetLista(OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha>();
            var filtroDTO = new DtoLibTransporte.Caja.Movimiento.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
            };
            var r01 = MyData.Transporte_Caja_Movimientos_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha()
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
                            signo = s.signo,
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