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
        class verificarAnular 
        {
            public string estatusAnulado { get; set; }
            public DateTime fechaEmision { get; set; }
            public string estatusCierreContable { get; set; }
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGasto.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_GetData(string autoDoc)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGasto.GetData.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"select 
                                    doc.documento as documento,
                                    doc.auto_proveedor as autoPrv,
                                    doc.auto_cxp as autoCxp,
                                    doc.total as total,
                                    doc.tipo as codigoTipoDoc,
                                    doc.tipo_documento_compra as tipoDocumentoCompra,
                                    doc.auto_sistema_documento as autoSistemaDoc,
                                    cta.auto_sistema_documento as autoSistemaDocCxp
                                from compras as doc
                                join cxp as cta on cta.auto=doc.auto_cxp
                                where doc.auto=@autoDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", autoDoc);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Anular.CompraGasto.GetData.Documento>(sql, p1).FirstOrDefault();
                    if (_ent==null)
                    {
                        throw new Exception("DOCUMENTO NO ENCONTRADO");
                    }
                    //
                    var autoCxp = _ent.autoCxp;
                    sql = @"SELECT
                                cta.auto as autoCxp,
                                cta.auto_sistema_documento as autoSistDocCxp,
                                rec.auto as autoRecibo,
                                rec.auto_sistema_documento as autoSistDocRec 
                            FROM cxp_documentos as doc
                            join cxp as cta on cta.auto=doc.auto_cxp_pago
                            join cxp_recibos as rec on rec.auto=doc.auto_cxp_recibo
                            where doc.auto_cxp=@autoCxP";
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoCxP", autoCxp);
                    var _entRetRec = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Anular.CompraGasto.GetData.RetRec>(sql, p1).ToList();
                    //
                    result.Entidad = new DtoLibTransporte.Documento.Anular.CompraGasto.GetData.Ficha()
                    {
                        documento = _ent,
                        retencionRecibo = _entRetRec,
                    };
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
            Transporte_Documento_Anular_CompraGrasto(DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        //
                        var sql = "update sistema_contadores set a_compras=a_compras+1, a_cxp=a_cxp+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        //
                        sql = @"INSERT INTO auditoria_documentos (
                                    auto_documento, 
                                    auto_sistema_documentos, 
                                    auto_usuario,
                                    usuario,
                                    codigo, 
                                    fecha, 
                                    hora, 
                                    memo, 
                                    estacion, 
                                    ip
                                )
                                VALUES (
                                    @auto_documento, 
                                    @auto_sistema_documentos, 
                                    @auto_usuario,
                                    @usuario,
                                    @codigo, 
                                    @fecha, 
                                    @hora, 
                                    @memo, 
                                    @estacion, 
                                    @ip
                                )";
                        foreach (var rg in ficha.auditoria) 
                        {
                            var p1 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", rg.autoDoc);
                            var p2 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documentos", rg.autoSistemaDocumento);
                            var p3 = new MySql.Data.MySqlClient.MySqlParameter("@auto_usuario", rg.autoUsuario);
                            var p4 = new MySql.Data.MySqlClient.MySqlParameter("@usuario", rg.nombreUsuario);
                            var p5 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", rg.codigoUsuario);
                            var p6 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                            var p7 = new MySql.Data.MySqlClient.MySqlParameter("@hora", fechaSistema.ToShortTimeString());
                            var p8 = new MySql.Data.MySqlClient.MySqlParameter("@memo", rg.motivo);
                            var p9 = new MySql.Data.MySqlClient.MySqlParameter("@estacion", rg.estacion);
                            var p10 = new MySql.Data.MySqlClient.MySqlParameter("@ip", rg.ip);
                            var v1 = cnn.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
                            if (v1 == 0)
                            {
                                result.Mensaje = "PROBLEMA AL REGISTRAR MOVIMIENTO AUDITORIA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                        }
                        //
                        sql = @"update compras set 
                                    estatus_anulado='1'
                                where auto=@autoDoc";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", ficha.autoDocCompra);
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS ANULADO DOCUMENTO COMPRA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoProv", ficha.proveedor.autoProv);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoDebito", ficha.proveedor.montoDebito);
                        sql = @"update proveedores set
                                    debitos=debitos-@montoDebito
                                where auto=@autoProv";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p01, p02);
                        if (r3 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR DATA PROVEEDOR";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        sql = @"update cxp set 
                                    estatus_anulado='1'
                                where auto=@autoCxp";
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoCxp", ficha.autoDocCxP);
                        var r4 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r4 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS ANULADO DOCUMENTO CXP";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        foreach (var rg in ficha.retenciones) 
                        {
                            sql = @"update cxp set 
                                    estatus_anulado='1'
                                where auto=@autoRet";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoRet", rg.autoCxP);
                            var r5 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r5 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS ANULADO CXP DOCUMENTO RETENCION";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            sql = @"update cxp_recibos set 
                                    estatus_anulado='1'
                                where auto=@autoRecibo";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoRecibo", rg.autoRecibo);
                            var r6 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r6 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS ANULADO RECIBO DOCUMENTO RETENCION";
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
        public DtoLib.Resultado 
            Transporte_Documento_Anular_CompraGrasto_Verificar(string autoDoc, string autoDocCxp)
        {
            var rt = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = "select now()";
                    var fechaSistema = cnn.Database.SqlQuery<DateTime>(_sql).FirstOrDefault();
                    //
                    _sql = @"select 
                                fecha as fechaEmision,
                                estatus_anulado as estatusAnulado,
                                estatus_cierre_contable as estatusCierreContable
                            from compras 
                            where auto=@autoDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", autoDoc);
                    var _ent = cnn.Database.SqlQuery<verificarAnular>(_sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        rt.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (_ent.estatusAnulado == "1")
                    {
                        rt.Mensaje = "DOCUMENTO YA ANULADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (_ent.fechaEmision.Year != fechaSistema.Year || _ent.fechaEmision.Month != fechaSistema.Month)
                    {
                        rt.Mensaje = "DOCUMENTO SE ENCUENTRA EN OTRO PERIODO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (_ent.estatusCierreContable == "1")
                    {
                        rt.Mensaje = "DOCUMENTO SE ENCUENTRA BLOQUEADO CONTABLEMENTE";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    _sql = @"SELECT 
                                count(*) as cnt
                            from cxp_documentos as doc
                            join cxp as pag on pag.auto=doc.auto_cxp_pago
                            where doc.auto_cxp=@autoDocCxp and 
                            doc.tipo_documento='PAG'";
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDocCxp", autoDocCxp);
                    var cnt = cnn.Database.SqlQuery<int>(_sql, p1).FirstOrDefault();
                    if (cnt > 0)
                    {
                        rt.Mensaje = "HAY ABONOS [ PAGOS ] REGISTRADO AL DOCUMENTO ANULAR";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return rt;
        }
    }
}