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
        public DtoLib.Resultado 
            Transporte_DocumentoRet_Crud_Anular_Procesar(DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.Ficha ficha)
        {
            var rt = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        //
                        // REGISTRO DE MOVIMIENTOS DE AUDITORIA
                        var sql = @"INSERT INTO auditoria_documentos (
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
                        foreach (var rg in ficha.auditorias)
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
                                throw new Exception("PROBLEMA AL REGISTRAR MOVIMIENTO AUDITORIA");
                            }
                        }
                        //
                        // ACTUALIZAR SALDO PROVEEDOR
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoProv", ficha.proveedor.idProv);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoCredito", ficha.proveedor.montoRestaurarMonDiv);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter();
                        sql = @"update proveedores set
                                    creditos=creditos-@montoCredito
                                where auto=@autoProv";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p01, p02);
                        if (r3 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR SALDO PROVEEDOR");
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZAR SALDO CXP DOCUMENTO COMPRA ORIGEN
                        sql = @"update cxp set 
                                    acumulado=acumulado-@montoRestaurar,
                                    resta=resta+@montoRestaurar,
                                    acumulado_divisa=acumulado_divisa-@montoRestaurarDiv,
                                    resta_divisa=resta_divisa+@montoRestaurarDiv
                                where auto=@autoCxp";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoCxp", ficha.cxpDocOrigen.idDoc);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoRestaurar", ficha.cxpDocOrigen.montoRestaurarMonAct);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@montoRestaurarDiv", ficha.cxpDocOrigen.montoRestaurarMonDiv);
                        var r4 = cnn.Database.ExecuteSqlCommand(sql, p01, p02, p03);
                        if (r4 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR SALDO CXP");
                        }
                        cnn.SaveChanges();
                        //
                        // ANULAR DOCUMENTO CXP ( IR )
                        sql = @"update cxp set 
                                    estatus_anulado='1'
                                where auto=@autoRet";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoRet", ficha.cxpIR.idDocIR);
                        var r5 = cnn.Database.ExecuteSqlCommand(sql, p01);
                        if (r5 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS DOCUMENTO CXP [ IR ]");
                        }
                        cnn.SaveChanges();
                        //
                        // ANULAR RECIBO CXP ( IR )
                        sql = @"update cxp_recibos set 
                                    estatus_anulado='1'
                                where auto=@autoRecibo";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoRecibo", ficha.cxpIR.idRecibo);
                        var r6 = cnn.Database.ExecuteSqlCommand(sql, p01);
                        if (r6 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS RECIBO CXP [ IR ]");
                        }
                        cnn.SaveChanges();
                        //
                        // ANULAR DOCUMENTO COMPRA RETENCION
                        sql = @"update compras_retenciones set 
                                    estatus_anulado='1'
                                where auto=@autoDocCompraRet";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoDocCompraRet", ficha.compraRet.idDocCompraRet);
                        var r7 = cnn.Database.ExecuteSqlCommand(sql, p01);
                        if (r7 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS DOCUMENTO COMPRA RETENCION");
                        }
                        cnn.SaveChanges();
                        //
                        // ANULAR DOCUMENTO COMPRA DETALLE RETENCION
                        sql = @"update compras_retenciones_detalle set 
                                    estatus_anulado='1'
                                where auto=@autoDocCompraRet";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoDocCompraRet", ficha.compraRet.idDocCompraRet);
                        var r8 = cnn.Database.ExecuteSqlCommand(sql, p01);
                        if (r8 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS DOCUMENTO COMPRA RETENCION DETALLE");
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZA DOCUMENTO COMPRA
                        if (ficha.compraRet.isRetIva)
                        {
                            sql = @"update compras set 
                                        tasa_retencion_iva=0,
                                        retencion_iva=0,
                                        comprobante_retencion='',
                                        fecha_retencion='2000-01-01'
                                where auto=@idDoc";
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", ficha.compraRet.idDocCompra);
                            var r9A = cnn.Database.ExecuteSqlCommand(sql, p01);
                            if (r9A == 0)
                            {
                                throw new Exception("ERROR AL ACTUALIZAR DOCUMENTO COMPRA");
                            }
                            cnn.SaveChanges();
                        }
                        else
                        {
                            sql = @"update compras set 
                                        tasa_retencion_islr=0,
                                        retencion_islr=0,
                                        sustraendo_ret_islr=0,
                                        monto_ret_islr=0,
                                        comprobante_retencion_islr=''
                                where auto=@idDoc";
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", ficha.compraRet.idDocCompra);
                            var r9B = cnn.Database.ExecuteSqlCommand(sql, p01);
                            if (r9B == 0)
                            {
                                throw new Exception("ERROR AL ACTUALIZAR DOCUMENTO COMPRA");
                            }
                            cnn.SaveChanges();
                        }
                        ts.Commit();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                rt.Mensaje = Helpers.MYSQL_VerificaError(ex);
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                rt.Mensaje = Helpers.ENTITY_VerificaError(ex);
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}
