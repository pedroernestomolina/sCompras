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
        public DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var _sql_1 = @"select 
                                        id as id,
                                        codigo as codigo,
                                        descripcion as descripcion 
                                    FROM compras_concepto";
                    var _sql = _sql_1;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>(_sql).ToList();
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
            Transporte_Documento_Concepto_Agregar(DtoLibTransporte.Documento.Concepto.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var sql = @"INSERT INTO compras_concepto (
                                id, 
                                codigo, 
                                descripcion
                            ) VALUES (
                                NULL,
                                @codigo, 
                                @descripcion 
                            )";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR CONCEPTO POR COMPRA";
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
            Transporte_Documento_Concepto_Editar(DtoLibTransporte.Documento.Concepto.Editar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var sql = @"update compras_concepto set 
                                        codigo=@codigo, 
                                        descripcion=@descripcion
                                    where id=@idConcepto";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@idConcepto", ficha.id);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR CONCEPTO POR COMPRA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetById(int id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"select 
                                        id as id,
                                        codigo as codigo,
                                        descripcion as descripcion 
                                    FROM compras_concepto
                                    where id=@idConcepto";
                    var _sql = _sql_1;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idConcepto", id);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>(_sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("CONCEPTO [ ID ] NO ENCONTRADO");
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
