﻿using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider: ILibCompras.IProvider
    {
        //MOVIMIENTOS
        public DtoLib.Resultado
            Transporte_Caja_Movimientos_Agregar(DtoLibTransporte.Caja.Movimiento.Crud.Agregar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var mesRelacion = fechaSistema.Month.ToString().Trim().PadLeft(2, '0');
                        var anoRelacion = fechaSistema.Year.ToString().Trim().PadLeft(4, '0');
                        //
                        var sql = @"update sistema_contadores set 
                                        a_transp_aliado_anticipo_recnumero=a_transp_aliado_anticipo_recnumero+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var aRecibo = cnn.Database.SqlQuery<int>("select a_transp_aliado_anticipo_recnumero from sistema_contadores").FirstOrDefault();
                        var autoRecibo = aRecibo.ToString().Trim().PadLeft(10, '0');
                        //
                        //INSERTAR CAJA MOVIMIENTO 
                        sql = @"INSERT INTO transp_caja_mov (
                                        id, 
                                        id_caja, 
                                        fecha_reg, 
                                        concepto_mov, 
                                        tipo_mov, 
                                        monto_mov_mon_act,
                                        monto_mov_mon_div, 
                                        factor_cambio_mov, 
                                        estatus_anulado_mov,
                                        mov_fue_divisa,
                                        signo,
                                        es_mov_caja)
                                    VALUES (
                                        NULL, 
                                        @id_caja, 
                                        @fecha_reg, 
                                        @concepto_mov, 
                                        @tipoMov,
                                        @monto_mov_mon_act,
                                        @monto_mov_mon_div, 
                                        @factor_cambio_mov, 
                                        '0',
                                        @mov_fue_divisa,
                                        @signoMov,
                                        '1')";
                        var cjMov = ficha;
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", cjMov.idCaja);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@concepto_mov", cjMov.descMov);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_act", cjMov.montoMovMonAct);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_div", cjMov.montoMovMonDiv);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio_mov", cjMov.factorCambio);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@mov_fue_divisa", cjMov.movFueDivisa ? "1" : "0");
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@tipoMov", cjMov.tipoMov);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@signoMov", cjMov.signoMov);
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06, p07, p08);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR MOVIMIENTO DE CAJA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZAR SALDO CAJAS 
                        sql = @"update transp_caja set 
                                        monto_ingreso=monto_ingreso+@monto
                                    where id=@idCaja";
                        if (ficha.signoMov == -1)
                        {
                            sql = @"update transp_caja set 
                                        monto_egreso=monto_egreso+@monto
                                    where id=@idCaja";
                        }
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", ficha.idCaja);
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", ficha.montoMov);
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                        if (r3 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        ts.Commit();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.Caja.Movimiento.Lista.Ficha>
            Transporte_Caja_Movimientos_GetLista(DtoLibTransporte.Caja.Movimiento.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Caja.Movimiento.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        cj.id as idCaja,
                                        cjMov.id as idMov,
                                        cj.descripcion as cjDesc,
                                        cj.es_divisa as cjEsDivisa,
                                        cjMov.fecha_reg as fechaMov,
                                        cjMov.concepto_mov as motivoMov,
                                        cjMov.tipo_mov as tipoMov,
                                        cjMov.signo as signoMov,
                                        cjMov.monto_mov_mon_act as montoMonAct,
                                        cjMov.monto_mov_mon_div as montoMonDiv,
                                        cjMov.factor_cambio_mov as factorCambio,
                                        cjMov.estatus_anulado_mov as estatusAnulado,
                                        cjMov.mov_fue_divisa as movFueDivisa
                                    FROM transp_caja_mov as cjMov
                                    join transp_caja as cj on cj.id=cjMov.id_caja ";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro != null)
                    {
                        if (filtro.Desde.HasValue)
                        {
                            _sql_2 += " and cjMov.fecha_reg>=@desde ";
                            p1.ParameterName = "@desde";
                            p1.Value = filtro.Desde.Value;
                        }
                        if (filtro.Hasta.HasValue)
                        {
                            _sql_2 += " and cjMov.fecha_reg<=@hasta ";
                            p2.ParameterName = "@hasta";
                            p2.Value = filtro.Hasta.Value;
                        }
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Caja.Movimiento.Lista.Ficha>(_sql, p1, p2).ToList();
                    result.Lista = _lst;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.Resultado 
            Transporte_Caja_Movimientos_Anular(DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var mesRelacion = fechaSistema.Month.ToString().Trim().PadLeft(2, '0');
                        var anoRelacion = fechaSistema.Year.ToString().Trim().PadLeft(4, '0');
                        //
                        //ACTUALIZAR CAJA MOVIMIENTO 
                        var sql = @"update transp_caja_mov set 
                                    estatus_anulado_mov='1'
                                where id=@idMov and estatus_anulado_mov='0' and es_mov_caja='1'";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", ficha.idMov);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS MOVIMIENTO DE CAJA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZAR SALDO CAJAS 
                        sql = @"update transp_caja set 
                                        monto_ingreso=monto_ingreso-@monto
                                    where id=@idCaja";
                        if (ficha.signoMov == -1)
                        {
                            sql = @"update transp_caja set 
                                        monto_egreso=monto_egreso-@monto
                                    where id=@idCaja";
                        }
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", ficha.idCaja);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", ficha.monto);
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        ts.Commit();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha> 
            Transporte_Caja_Movimientos_Anular_ObtenerData(int idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        cjMov.id as idMov,
                                        cjMov.id_caja as idCaja,
                                        cjMov.signo as signoMov,
                                        case 
                                            when mov_fue_divisa='0' then monto_mov_mon_act
                                            else monto_mov_mon_div
                                        end as monto
                                    FROM transp_caja_mov as cjMov
                                    WHERE cjMov.id=@idMov";
                    var _sql_2 = @"";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _sql = _sql_1 + _sql_2;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha>(_sql, p0).FirstOrDefault();
                    if (_ent == null)
                    {
                        result.Mensaje = "MOVIMIENTO CAJA NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = _ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
    }
}