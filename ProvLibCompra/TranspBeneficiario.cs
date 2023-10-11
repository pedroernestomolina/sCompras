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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Crud.Entidad.Ficha> 
            Transporte_Beneficiario_GetById(int idBeneficiario)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Crud.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"select 
                                        id as id,
                                        cirif as ciRif,
                                        nombre_razonsocial as nombreRazonSocial,
                                        direccion as direccion,
                                        telefono as telefono,
                                        estatus_anulado as estatusAnulado                                        ,
                                        fecha_registro as fechaRegistro
                                    from transp_beneficiario
                                    where id=@id";
                    var _sql_2 = @"";
                    var _sql = _sql_1 + _sql_2;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", idBeneficiario);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Beneficiario.Crud.Entidad.Ficha>(_sql, p1).FirstOrDefault();
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
        public DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Lista.Ficha> 
            Transporte_Beneficiario_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"select 
                                        id as id,
                                        cirif as ciRif,
                                        nombre_razonsocial as nombreRazonSocial
                                    from transp_beneficiario";
                    var _sql = _sql_1;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Beneficiario.Lista.Ficha>(_sql).ToList();
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
        public DtoLib.ResultadoId 
            Transporte_Beneficiario_Agregar(DtoLibTransporte.Beneficiario.Crud.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var sql = @"INSERT INTO transp_beneficiario (
                                        id, 
                                        cirif, 
                                        nombre_razonsocial, 
                                        direccion, 
                                        telefono, 
                                        fecha_registro, 
                                        estatus_anulado)
                                    VALUES (
                                        NULL, 
                                        @cirif, 
                                        @nombre_razonsocial, 
                                        @direccion, 
                                        @telefono, 
                                        @fecha_registro, 
                                        '0')";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@cirif", ficha.ciRif);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@nombre_razonsocial", ficha.nombreRazonSocial);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@direccion", ficha.direccion);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@telefono", ficha.telefono);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR BENEFICIARIO";
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
            Transporte_Beneficiario_Editar(DtoLibTransporte.Beneficiario.Crud.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var sql = @"update transp_beneficiario set
                                        cirif=@cirif,
                                        nombre_razonsocial=@nombre_razonsocial,
                                        direccion=@direccion,
                                        telefono=@telefono
                                    where id=@id";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@id", ficha.id);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@cirif", ficha.ciRif);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@nombre_razonsocial", ficha.nombreRazonSocial);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@direccion", ficha.direccion);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@telefono", ficha.telefono);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR BENEFICIARIO";
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