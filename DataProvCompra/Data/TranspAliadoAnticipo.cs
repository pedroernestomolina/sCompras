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
        public OOB.Resultado 
            Transporte_Aliado_Anticipo_Agregar(OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Aliado.Anticipo.Agregar.Ficha();
            var mov = new DtoLibTransporte.Aliado.Anticipo.Agregar.Movimiento()
            {
                aplicaRet = ficha.movimiento.aplicaRet,
                ciRifAliado = ficha.movimiento.ciRifAliado,
                fechaEmision = ficha.movimiento.fechaEmision,
                idAliado = ficha.movimiento.idAliado,
                montoNetoMonAct = ficha.movimiento.montoNetoMonAct,
                montoNetoMonDiv = ficha.movimiento.montoNetoMonDiv,
                montoPagoMonAct = ficha.movimiento.montoPagoMonAct,
                montoPagoMonDiv = ficha.movimiento.montoPagoMonDiv,
                montoRet = ficha.movimiento.montoRet,
                motivo = ficha.movimiento.motivo,
                nombreAliado = ficha.movimiento.nombreAliado,
                sustraendoRet = ficha.movimiento.sustraendoRet,
                tasaFactor = ficha.movimiento.tasaFactor,
                tasaRet = ficha.movimiento.tasaRet,
            };
            var aliado = new DtoLibTransporte.Aliado.Anticipo.Agregar.AliadoAbonar()
            {
                idAliado = ficha.aliadoAbonar.idAliado,
                montoAbonar = ficha.aliadoAbonar.montoAbonar,
                montoRetAbonar = ficha.aliadoAbonar.montoRetAbonar,
            };
            fichaDTO.movimiento = mov;
            fichaDTO.aliadoAbonar = aliado;
            fichaDTO.alidoCaja = ficha.alidoCaja.Select(s =>
            {
                var rg = new DtoLibTransporte.Aliado.Anticipo.Agregar.AliadoCaja()
                {
                    idAliado = s.idAliado,
                    idCaja = s.idCaja,
                    monto = s.monto,
                    movimientoCaja = new DtoLibTransporte.Aliado.Anticipo.Agregar.CajaMovimiento()
                    {
                        descMov = s.movimientoCaja.descMov,
                        factorCambio = s.movimientoCaja.factorCambio,
                        fechaMov = s.movimientoCaja.fechaMov,
                        montoMovMonAct = s.movimientoCaja.montoMovMonAct,
                        montoMovMonDiv = s.movimientoCaja.montoMovMonDiv,
                        movFueDivisa = s.movimientoCaja.movFueDivisa,
                    },
                };
                return rg;
            }).ToList();
            var r01 = MyData.Transporte_Aliado_Anticipo_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
    }
}