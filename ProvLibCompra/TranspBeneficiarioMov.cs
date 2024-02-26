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
            Transporte_Beneficiario_Mov_Agregar(DtoLibTransporte.Beneficiario.Mov.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        //
                        var sql = @"update sistema_contadores set 
                                        a_transp_beneficiario_recnumero=a_transp_beneficiario_recnumero+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            throw new Exception("PROBLEMA AL ACTUALIZAR TABLA CONTADORES");
                        }
                        var aRecibo = cnn.Database.SqlQuery<int>("select a_transp_beneficiario_recnumero from sistema_contadores").FirstOrDefault();
                        var autoRecibo = aRecibo.ToString().Trim().PadLeft(10, '0');
                        //
                        //INSERTAR MOVIMIENTO-BENEFICIARIO
                        sql = @"INSERT INTO transp_beneficiario_mov (
                                        id, 
                                        id_beneficiario, 
                                        id_concepto, 
                                        fecha_registro, 
                                        fecha_mov, 
                                        nombre_bene, 
                                        cirif_bene, 
                                        desc_concepto, 
                                        cod_concepto, 
                                        monto_div, 
                                        factor_tasa, 
                                        notas, 
                                        estatus_anulado,
                                        recibo_nro)
                                    VALUES 
                                        (NULL, 
                                        @id_beneficiario, 
                                        @id_concepto, 
                                        @fecha_registro, 
                                        @fecha_mov, 
                                        @nombre_bene, 
                                        @cirif_bene, 
                                        @desc_concepto, 
                                        @cod_concepto, 
                                        @monto_div, 
                                        @factor_tasa, 
                                        @notas, 
                                        '0',
                                        @recibo_nro)";
                        var mov = ficha.mov;
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_beneficiario", mov.idBeneficiario);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@id_concepto", mov.idConcepto);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro",fechaSistema.Date);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_mov", mov.fechaMov);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@nombre_bene", mov.nombreBeneficiario);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@cirif_bene", mov.ciRifBeneficiario);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@desc_concepto", mov.descConcepto);
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@cod_concepto", mov.codConcepto);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@monto_div", mov.montoMonDiv);
                        var p09 = new MySql.Data.MySqlClient.MySqlParameter("@factor_tasa", mov.factorTasa);
                        //
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@notas",mov.notasMov);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@recibo_nro", autoRecibo);
                        //
                        r1 = cnn.Database.ExecuteSqlCommand(sql,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11);
                        if (r1 == 0)
                        {
                            throw new Exception("ERROR AL INSERTAR MOVIMIENTO DE ABONO");
                        }
                        cnn.SaveChanges();
                        //
                        sql = "SELECT LAST_INSERT_ID()";
                        var idMov= cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        //
                        //INSERTAR CAJA MOVIMIENTO 
                        foreach(var rg in ficha.movCaja)
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
                                        signo,
                                        fecha_emision)
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
                                        -1,
                                        @fecha_emision)";
                            var cjMov=rg.movimientoCaja;
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@concepto_mov", cjMov.descMov);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_act", cjMov.montoMovMonAct);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_div", cjMov.montoMovMonDiv);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio_mov", cjMov.factorCambio);
                            p06 = new MySql.Data.MySqlClient.MySqlParameter("@mov_fue_divisa", cjMov.movFueDivisa ? "1" : "0");
                            p07 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_emision", mov.fechaMov);
                            var r2 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06, p07);
                            if (r2 == 0)
                            {
                                throw new Exception("ERROR AL INSERTAR MOVIMIENTO DE CAJA");
                            }
                            cnn.SaveChanges();
                            //
                            sql = "SELECT LAST_INSERT_ID()";
                            var idMovCj = cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                            //
                            // INSERTAR CAJA AFECTADA 
                            sql = @"INSERT INTO transp_beneficiario_caj (
                                        id, 
                                        id_mov, 
                                        id_caja, 
                                        desc_caja, 
                                        cod_caja,
                                        monto_mov,
                                        fecha_reg,
                                        estatus_anulado,
                                        es_divisa,
                                        signo_mov,
                                        id_caja_mov) 
                                    VALUES (
                                        NULL,
                                        @id_mov, 
                                        @id_caja, 
                                        @desc_caja, 
                                        @cod_caja,
                                        @monto_mov,
                                        @fecha_reg,
                                        '0',
                                        @es_divisa,
                                        -1,
                                        @id_caja_mov)";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_mov", idMov);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@desc_caja", rg.descCaja);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@cod_caja", rg.codCaja);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov", rg.monto);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                            p06 = new MySql.Data.MySqlClient.MySqlParameter("@es_divisa", rg.esDivisa);
                            p07 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja_mov", idMovCj);
                            var r3 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06, p07);
                            if (r3 == 0)
                            {
                                throw new Exception("ERROR AL INSERTAR BENFICIARIO-MOV-CAJA");
                            }
                            cnn.SaveChanges();
                            //
                            // ACTUALIZAR SALDO CAJAS 
                            sql = @"update transp_caja set 
                                        monto_egreso=monto_egreso+@monto
                                    where id=@idCaja";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", rg.idCaja);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.monto);
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r4 == 0)
                            {
                                throw new Exception("ERROR AL ACTUALIZAR SALDO CAJA");
                            }
                            cnn.SaveChanges();
                        }
                        ts.Commit();
                        result.Id = idMov;
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
        //
        public DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Mov.Lista.Ficha> 
            Transporte_Beneficiario_Mov_GetLista(DtoLibTransporte.Beneficiario.Mov.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Mov.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as idMov,
                                        recibo_nro as reciboNro,
                                        nombre_bene as nombreBene,
                                        cirif_bene as cirifBene,
                                        fecha_registro as fechaReg,
                                        monto_div as montoDiv,
                                        estatus_anulado as estatusAnulado,
                                        desc_concepto as descConcepto,
                                        cod_concepto as codConcepto
                                    FROM transp_beneficiario_mov ";
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
                        if (filtro.Estatus != "")
                        {
                            _sql_2 += " and estatus_anulado=@estatus ";
                            p4.ParameterName = "@estatus";
                            p4.Value = filtro.Estatus.Trim().ToUpper() == "I" ? "1" : "0";
                        }
                        if (filtro.IdBeneficiario != -1)
                        {
                            _sql_2 += " and id_beneficiario=@idBeneficiario ";
                            p3.ParameterName = "@idBeneficiario";
                            p3.Value = filtro.IdBeneficiario;
                        }
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Beneficiario.Mov.Lista.Ficha>(_sql, p1, p2, p3, p4).ToList();
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
        //
        public DtoLib.Resultado 
            Transporte_Beneficiario_Mov_Anular(DtoLibTransporte.Beneficiario.Mov.Anular.Ficha ficha)
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
                        var sql = @"update transp_beneficiario_mov set 
                                        estatus_anulado='1'
                                    where id=@idMov";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", ficha.idMov);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS BENEFICIARIO-MOV";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        //ANULAR CAJA MOVIMIENTO 
                        foreach (var rg in ficha.cajas)
                        {
                            sql = @"update transp_caja_mov set
                                        estatus_anulado_mov='1'
                                    where id=@idCajaMov";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCajaMov", rg.idCajaMov);
                            var r3 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r3 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS CAJA-MOV";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            // ANULAR CAJA-MOV-BENEFICIARIO
                            sql = @"update transp_beneficiario_caj set 
                                        estatus_anulado='1'
                                    where id=@idBeneficiarioMov";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idBeneficiarioMov", rg.idBeneficiarioMov);
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r4 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS BENFICIARIO-CAJA";
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
                            var p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.monto);
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
        //
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Mov.Anular.Ficha> 
            Transporte_Beneficiario_Mov_Anular_ObtenerData(int idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Mov.Anular.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    id as idMov
                                FROM transp_beneficiario_mov 
                                where id=@idMov";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Beneficiario.Mov.Anular.Ficha>(sql, p0).FirstOrDefault();
                    if (_ent == null)
                    {
                        result.Mensaje = "MOVIMIENTO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    //
                    sql = @"SELECT 
                                id as idBeneficiarioMov,
                                id_caja as idCaja,
                                id_caja_mov as idCajaMov,
                                monto_mov as monto
                            FROM transp_beneficiario_caj 
                            where id_mov=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _det = cnn.Database.SqlQuery<DtoLibTransporte.Beneficiario.Mov.Anular.caja>(sql, p0).ToList();
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
    }
}