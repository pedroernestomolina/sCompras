using LibEntityCompra;
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
        public DtoLib.ResultadoId 
            Transporte_Aliado_Anticipo_Agregar(DtoLibTransporte.Aliado.Anticipo.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();
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
                        //INSERTAR DOCUMENTO DE ANTICIPO ALIADO
                        sql = @"INSERT INTO transp_aliado_anticipo (
                                    id, 
                                    id_aliado,
                                    fecha_emision, 
                                    fecha_registro, 
                                    cirif_aliado,
                                    nombre_aliado,
                                    monto_neto_mon_act,
                                    monto_neto_mon_div, 
                                    tasa_factor, 
                                    motivo, 
                                    aplica_ret,
                                    tasa_ret, 
                                    sustraendo_ret,
                                    monto_retencion, 
                                    monto_pago_mon_act,
                                    monto_pag_mon_div, 
                                    estatus_anulado,
                                    recibo_numero)
                                VALUES (
                                    NULL, 
                                    @id_aliado,
                                    @fecha_emision, 
                                    @fecha_registro, 
                                    @cirif_aliado,
                                    @nombre_aliado,
                                    @monto_neto_mon_act,
                                    @monto_neto_mon_div, 
                                    @tasa_factor, 
                                    @motivo, 
                                    @aplica_ret,
                                    @tasa_ret, 
                                    @sustraendo_ret,
                                    @monto_retencion, 
                                    @monto_pago_mon_act,
                                    @monto_pag_mon_div, 
                                    '0',
                                    @recibo_numero)";
                        var mov = ficha.movimiento;
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado",mov.idAliado);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_emision",mov.fechaEmision);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro",fechaSistema.Date);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@cirif_aliado",mov.ciRifAliado);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@nombre_aliado",mov.nombreAliado);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@monto_neto_mon_act",mov.montoNetoMonAct);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@monto_neto_mon_div",mov.montoNetoMonDiv);
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_factor",mov.tasaFactor);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@motivo",mov.motivo);
                        var p09 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_ret",mov.aplicaRet);
                        //
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_ret",mov.tasaRet);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@sustraendo_ret",mov.sustraendoRet);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@monto_retencion",mov.montoRet);
                        var p13 = new MySql.Data.MySqlClient.MySqlParameter("@monto_pago_mon_act",mov.montoPagoMonAct);
                        var p14 = new MySql.Data.MySqlClient.MySqlParameter("@monto_pag_mon_div",mov.montoPagoMonDiv);
                        var p15 = new MySql.Data.MySqlClient.MySqlParameter("@recibo_numero",autoRecibo);
                        //
                        var r2 = cnn.Database.ExecuteSqlCommand(sql,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR MOVIMIENTO DE ABONO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        sql = "SELECT LAST_INSERT_ID()";
                        var idAnticipo = cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        //
                        // ACTUALIZAR ALIADO 
                        sql = @"update transp_aliado set
                                    monto_anticipos_mon_divisa= monto_anticipos_mon_divisa+@monto,
                                    monto_anticipos_ret_mon_divisa=monto_anticipos_ret_mon_divisa+@montoRet
                                where id=@idAliado";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", ficha.aliadoAbonar.idAliado);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@monto", ficha.aliadoAbonar.montoAbonar);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@montoRet", ficha.aliadoAbonar.montoRetAbonar);
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p01, p02, p03);
                        if (r3 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR MONTO ANTICIPO ALIADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        //INSERTAR CAJA MOVIMIENTO POR ANTICIPO DEL ALIADO
                        foreach(var rg in ficha.alidoCaja)
                        {
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
                                        signo)
                                    VALUES (
                                        NULL, 
                                        @id_caja, 
                                        @fecha_reg, 
                                        @concepto_mov, 
                                        'E', 
                                        @monto_mov_mon_act,
                                        @monto_mov_mon_div, 
                                        @factor_cambio_mov, 
                                        '0',
                                        @mov_fue_divisa,
                                        -1)";
                            var cjMov=rg.movimientoCaja;
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@concepto_mov", cjMov.descMov);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_act", cjMov.montoMovMonAct);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_div", cjMov.montoMovMonDiv);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio_mov", cjMov.factorCambio);
                            p06 = new MySql.Data.MySqlClient.MySqlParameter("@mov_fue_divisa", cjMov.movFueDivisa ? "1" : "0");
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06);
                            if (r4 == 0)
                            {
                                result.Mensaje = "ERROR AL INSERTAR MOVIMIENTO DE CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            sql = "SELECT LAST_INSERT_ID()";
                            var idMov = cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                            //
                            // INSERTAR CAJA AFECTADA POR ANITCIPO DEL ALIADO
                            sql = @"INSERT INTO transp_aliado_anticipo_caja (
                                        id, 
                                        id_anticipo, 
                                        id_caja, 
                                        estatus_anulado, 
                                        id_caja_mov,
                                        id_aliado,
                                        fecha_reg,
                                        fecha_mov) 
                                    VALUES (
                                        NULL,
                                        @id_anticipo, 
                                        @id_caja, 
                                        '0',
                                        @id_caja_mov,
                                        @id_aliado,
                                        @fecha_reg,
                                        @fecha_mov)";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_anticipo", idAnticipo);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja_mov", idMov);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado", rg.idAliado);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_mov", cjMov.fechaMov);
                            var r5 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05);
                            if (r5 == 0)
                            {
                                result.Mensaje = "ERROR AL INSERTAR ALIADO-ANITICIPO-CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            // ACTUALIZAR SALDO CAJAS 
                            sql = @"update transp_caja set 
                                        monto_egreso=monto_egreso+@monto
                                    where id=@idCaja";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", rg.idCaja);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.monto);
                            var r6 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r6 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }
                        ts.Commit();
                        result.Id = idAnticipo;
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
        public DtoLib.Resultado 
            Transporte_Aliado_Anticipo_Anular(DtoLibTransporte.Aliado.Anticipo.Anular.Ficha ficha)
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
                        //ANULAR DOCUMENTO DE ANTICIPO 
                        var sql = @"update transp_aliado_anticipo set 
                                        estatus_anulado='1'
                                    where id=@idMov";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", ficha.idMov);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS ANTICIPO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZAR ALIADO 
                        sql = @"update transp_aliado set
                                    monto_anticipos_mon_divisa= monto_anticipos_mon_divisa-@monto,
                                    monto_anticipos_ret_mon_divisa=monto_anticipos_ret_mon_divisa-@montoRet
                                where id=@idAliado";
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", ficha.idAliado);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", ficha.monto);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoRet", ficha.montoRet);
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR SALDO ALIADO-ANTICIPO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        //ANULAR CAJA MOVIMIENTO POR ANTICIPO DEL ALIADO
                        foreach (var rg in ficha.cajas)
                        {
                            sql = @"update transp_caja_mov set
                                        estatus_anulado_mov='1'
                                    where id=@idCajaMov";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCajaMov", rg.idCajaMov);
                            var r3 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r3 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS CAJA-MOVIMIENTO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            // anular CAJA AFECTADA POR ANITCIPO DEL ALIADO
                            sql = @"update transp_aliado_anticipo_caja set 
                                        estatus_anulado='1'
                                    where id=@idAnticipoCaja";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idAnticipoCaja", rg.idAnticipoCaja);
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r4 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS ANITICIPO-CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            // ACTUALIZAR SALDO CAJAS 
                            sql = @"update transp_caja set 
                                        monto_egreso_anulado=monto_egreso_anulado+@monto
                                    where id=@idCaja";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", rg.idCaja);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.monto);
                            var r6 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r6 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Anticipo.Anular.Ficha> 
            Transporte_Aliado_Anticipo_Anular_ObtenerData(int idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Anticipo.Anular.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    id as idMov,
                                    id_aliado as idAliado,
                                    monto_pag_mon_div as monto,
                                    monto_neto_mon_div-monto_pag_mon_div as montoRet
                                FROM transp_aliado_anticipo
                                where id=@idMov";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Anticipo.Anular.Ficha>(sql, p0).FirstOrDefault();
                    if (_ent == null)
                    {
                        result.Mensaje = "MOVIMIENTO ANTICIPO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    //
                    sql = @"SELECT 
                                aliadoCaja.id as idAnticipoCaja,
                                aliadoCaja.id_caja as idCaja,
                                aliadoCaja.id_caja_mov as idCajaMov,
                                case 
                                    when mov_fue_divisa='0' then monto_mov_mon_act
                                    else monto_mov_mon_div
                                end as monto
                            FROM transp_aliado_anticipo_caja as aliadoCaja
                            join transp_caja_mov as  cajaMov on cajaMov.id=aliadoCaja.id_caja_mov
                            where id_anticipo=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _det = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Anticipo.Anular.caja>(sql, p0).ToList();
                    _ent.cajas = _det;
                    //
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
        //
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Anticipo.Lista.Ficha> 
            Transporte_Aliado_Anticipo_GetLista(DtoLibTransporte.Aliado.Anticipo.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Anticipo.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as idMov,
                                        id_aliado as idAliado,
                                        nombre_aliado as nombreAliado,
                                        cirif_aliado as cirifAliado,
                                        fecha_registro as fecha,
                                        recibo_numero as numRecibo,
                                        monto_neto_mon_div as montoAntSolicitadoDiv,
                                        motivo as motivo,
                                        estatus_anulado as estatusAnulado
                                    FROM transp_aliado_anticipo";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro != null) 
                    {
                        if (filtro.Desde.HasValue) 
                        {
                            _sql_2 += " and fecha_registro>=@desde ";
                            p1.ParameterName = "@desde";
                            p1.Value = filtro.Desde.Value;
                        }
                        if (filtro.Hasta.HasValue)
                        {
                            _sql_2 += " and fecha_registro<=@hasta ";
                            p2.ParameterName = "@hasta";
                            p2.Value = filtro.Hasta.Value;
                        }
                        if (filtro.IdAliado != -1)
                        {
                            _sql_2 += " and id_aliado=@idAliado ";
                            p3.ParameterName = "@idAliado";
                            p3.Value = filtro.IdAliado;
                        }
                        if (filtro.Estatus != "")
                        {
                            _sql_2 += " and estatus_anulado=@estatus ";
                            p4.ParameterName = "@estatus";
                            p4.Value = filtro.Estatus.Trim().ToUpper() == "I" ? "1" : "0";
                        }
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Anticipo.Lista.Ficha>(_sql, p1, p2, p3, p4).ToList();
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
    }
}