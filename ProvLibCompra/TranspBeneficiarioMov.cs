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
                        //INSERTAR MOVIMIENTO-BENEFICIARIO
                        var sql = @"INSERT INTO transp_beneficiario_mov (
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
                                        estatus_anulado)
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
                                        '0')";
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
                        //
                        var r1 = cnn.Database.ExecuteSqlCommand(sql,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR MOVIMIENTO DE ABONO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
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
                            var r2 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06);
                            if (r2 == 0)
                            {
                                result.Mensaje = "ERROR AL INSERTAR MOVIMIENTO DE CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
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
                                result.Mensaje = "ERROR AL INSERTAR BENFICIARIO-MOV-CAJA";
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
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r4 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
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
    }
}