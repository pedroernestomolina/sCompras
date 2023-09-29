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
        public DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha> 
            Transporte_Caja_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"select 
                                        id as id,
                                        codigo,
                                        descripcion,
                                        saldo_inicial as saldoInicial,
                                        monto_ingreso-monto_ingreso_anulado as montoPorIngresos,
                                        monto_egreso-monto_egreso_anulado as montoPorEgresos,
                                        0 as montoPorAnulaciones,
                                        estatus_anulado as estatusAnulado,
                                        es_divisa as esDivisa
                                    FROM transp_caja";
                    var _sql = _sql_1;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Caja.Lista.Ficha>(_sql).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Crud.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as id,
                                        codigo,
                                        descripcion as descripcion,
                                        fecha_registro as fechaRegistro,
                                        saldo_inicial as saldoInicial,
                                        monto_ingreso as montoIngreso,
                                        monto_egreso as montoEgreso,
                                        monto_ingreso_anulado as montoIngresoAnulado,
                                        monto_egreso_anulado as montoEgresoAnulado,
                                        es_divisa as esDivisa,
                                        estatus_anulado as estatusAnulado
                                    FROM transp_caja
                                    WHERE id=@idCja";
                    var _sql_2 = @"";
                    var _sql = _sql_1 + _sql_2;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idCja", idCja);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Caja.Crud.Entidad.Ficha>(_sql, p1).FirstOrDefault();
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
        public DtoLib.ResultadoId 
            Transporte_Caja_Agregar(DtoLibTransporte.Caja.Crud.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var sql = @"INSERT INTO transp_caja (
                                        id, 
                                        descripcion, 
                                        fecha_registro, 
                                        saldo_inicial, 
                                        monto_ingreso, 
                                        monto_egreso, 
                                        estatus_anulado, 
                                        es_divisa, 
                                        monto_ingreso_anulado, 
                                        monto_egreso_anulado, 
                                        codigo)
                                    VALUES (
                                        NULL, 
                                        @descripcion, 
                                        @fecha_registro, 
                                        @saldo_inicial, 
                                        0, 
                                        0, 
                                        '0', 
                                        @es_divisa, 
                                        0, 
                                        0, 
                                        @codigo)";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@saldo_inicial", ficha.saldoInicial);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@es_divisa", ficha.esDivisa?"1":"0");
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR CAJA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        sql = "SELECT LAST_INSERT_ID()";
                        var idEnt = cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        result.Id = idEnt;
                        //
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
        public DtoLib.Resultado 
            Transporte_Caja_Editar(DtoLibTransporte.Caja.Crud.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var sql = @"UPDATE transp_caja set 
                                        descripcion=@descripcion, 
                                        saldo_inicial=@saldo_inicial, 
                                        es_divisa=@es_divisa, 
                                        codigo=@codigo
                                    where id=@idCaja";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", ficha.id);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@saldo_inicial", ficha.saldoInicial);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@es_divisa", ficha.esDivisa ? "1" : "0");
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR CAJA";
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
    }
}