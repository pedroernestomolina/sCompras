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
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha> 
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    aliado.id as aliadoId,
                                    aliado.ciRif as aliadoCiRif,
                                    aliado.nombreRazonSocial as aliadoNombre,
                                    aliado.codigo as aliadoCodigo,
                                    vta.ci_rif as clienteCiRif,
                                    vta.razon_social as clienteNombre,
                                    aliadoDoc.doc_fecha as fechaDoc,
                                    aliadoDoc.doc_numero as numDoc,
                                    aliadoDoc.doc_nombre as nombreDoc,
                                    aliadoServ.importe_serv_div as importeServDiv,
                                    aliadoServ.id_serv as servId,
                                    aliadoServ.codigo_serv as servCodigo,
                                    aliadoServ.desc_serv as servDesc,
                                    aliadoServ.detalle_serv as servDetalle,
                                    aliadoServ.monto_acumulado_div as servMontoAcumuladoDiv,
                                    aliadoDoc.id as idAliadoDoc,
                                    aliadoServ.id as idAliadoServ
                                from transp_aliado_doc as aliadoDoc 
                                join transp_aliado_doc_servicio as aliadoServ on aliadoServ.id_aliado_doc=aliadoDoc.id
                                join transp_aliado as aliado on aliado.id=aliadoDoc.id_aliado
                                join ventas as vta on vta.auto=aliadoDoc.id_doc_ref
                                where aliado.id=@idAliado and 
                                        aliadoDoc.estatus_anulado='0' and
                                        aliadoServ.estatus_anulado='0' and 
                                        aliadoServ.importe_serv_div>aliadoServ.monto_acumulado_div";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", idAliado);
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha>(sql, p1).ToList();
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
            Transporte_Aliado_PagoServ_AgregarPago(DtoLibTransporte.Aliado.PagoServ.AgregarPago.Ficha ficha)
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
                                        a_transp_aliado_pagoserv_recnumero=a_transp_aliado_pagoserv_recnumero+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        sql = "select a_transp_aliado_pagoserv_recnumero from sistema_contadores";
                        var nRecibo = cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        var numRecibo = nRecibo.ToString().Trim().PadLeft(10, '0');
                        //
                        //INSERTAR DOCUMENTO DE PAGO POR SERV PRESTADO
                        sql = @"INSERT INTO transp_aliado_pagoserv (
                                    id, 
                                    id_aliado, 
                                    fecha_emision, 
                                    fecha_registro, 
                                    aliado_nombre, 
                                    aliado_codigo, 
                                    aliado_cirif, 
                                    recibo_numero, 
                                    cnt_serv_pag, 
                                    motivo, 
                                    monto_mon_act, 
                                    monto_mon_div, 
                                    tasa_factor, 
                                    aplica_ret, 
                                    tasa_ret, 
                                    retencion, 
                                    sustraendo, 
                                    monto_ret_mon_act, 
                                    monto_ret_mon_div, 
                                    total_pag_mon_act, 
                                    total_pag_mon_div, 
                                    estatus_anulado,
                                    monto_anticipo_usado,
                                    monto_anticipo_ret_usado,
                                    estatus_procesado,
                                    tasa_promedio_factor_anticipo) 
                            VALUES (
                                    NULL,
                                    @id_aliado, 
                                    @fecha_emision, 
                                    @fecha_registro, 
                                    @aliado_nombre, 
                                    @aliado_codigo, 
                                    @aliado_cirif, 
                                    @recibo_numero, 
                                    @cnt_serv_pag, 
                                    @motivo, 
                                    @monto_mon_act, 
                                    @monto_mon_div, 
                                    @tasa_factor, 
                                    @aplica_ret, 
                                    @tasa_ret, 
                                    @retencion, 
                                    @sustraendo, 
                                    @monto_ret_mon_act, 
                                    @monto_ret_mon_div, 
                                    @total_pag_mon_act, 
                                    @total_pag_mon_div, 
                                    '0',
                                    @monto_anticipo_usado,
                                    @monto_anticipo_ret_usado,
                                    '0',
                                    @tasa_promedio_factor_anticipo)";
                        var mov = ficha.movimiento;
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado",mov.idAliado);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_emision",mov.fechaEmision);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro",fechaSistema.Date);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@aliado_nombre",mov.nombreAliado);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@aliado_codigo",mov.codigoAliado);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@aliado_cirif",mov.ciRifAliado);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@recibo_numero",numRecibo);
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@cnt_serv_pag",mov.cntServ);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@motivo",mov.motivo);
                        var p09 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mon_act",mov.montoMonAct);
                        //
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mon_div",mov.montoMonDiv);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_factor",mov.tasaFactorCambio);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_ret",mov.aplicaRet?"1":"0");
                        var p13 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_ret",mov.tasaRet);
                        var p14 = new MySql.Data.MySqlClient.MySqlParameter("@retencion",mov.retencion);
                        var p15 = new MySql.Data.MySqlClient.MySqlParameter("@sustraendo",mov.sustraendo);
                        var p16 = new MySql.Data.MySqlClient.MySqlParameter("@monto_ret_mon_act",mov.montoRetMonAct);
                        var p17 = new MySql.Data.MySqlClient.MySqlParameter("@monto_ret_mon_div",mov.montoRetMonDiv);
                        var p18 = new MySql.Data.MySqlClient.MySqlParameter("@total_pag_mon_act",mov.totalPagMonAct);
                        var p19 = new MySql.Data.MySqlClient.MySqlParameter("@total_pag_mon_div",mov.totalPagMonDiv);
                        //
                        var p20 = new MySql.Data.MySqlClient.MySqlParameter("@monto_anticipo_usado", ficha.MontoPorAnticipoUsado);
                        var p21 = new MySql.Data.MySqlClient.MySqlParameter("@monto_anticipo_ret_usado", ficha.MontoPorRetAnticipoUsado);
                        var p22 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_promedio_factor_anticipo", ficha.TasaPromedioFactorAnticipo);
                        //
                        var r2 = cnn.Database.ExecuteSqlCommand(sql,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                            p20, p21, p22);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR MOVIMIENTO DE PAGO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        sql = "SELECT LAST_INSERT_ID()";
                        var idpago= cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                        //
                        // INSERTO DETALLES SERVCIOS PAGADOS
                        foreach (var det in ficha.movimiento.detalles) 
                        {
                            sql = @"INSERT INTO transp_aliado_pagoserv_det (
                                        id, 
                                        id_pagoserv, 
                                        id_aliado, 
                                        id_aliado_doc, 
                                        id_aliado_serv, 
                                        fecha_registro, 
                                        monto_pago_mon_div, 
                                        estatus_anulado
                                    ) 
                                    VALUES (
                                        NULL,
                                        @id_pagoserv, 
                                        @id_aliado, 
                                        @id_aliado_doc, 
                                        @id_aliado_serv, 
                                        @fecha_registro, 
                                        @monto_pago_mon_div, 
                                        '0'
                                    )";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_pagoserv", idpago);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado", mov.idAliado);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado_doc", det.idAliadoDoc);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado_serv", det.idAliadoDocServ);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@monto_pago_mon_div", det.motnoDocSerMonDiv);
                            var r3 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05);
                            if (r3 == 0)
                            {
                                result.Mensaje = "ERROR AL REGISTRAR DETALLE DE PAGO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            //ACTUALIZAR SALDO ALIADO-DOCUMENTO
                            sql = @"update transp_aliado_doc set 
                                        acumulado_divisa=acumulado_divisa+@montoMonDiv
                                    where id=@idAliadoDoc and 
                                            estatus_anulado<>'1' and 
                                            importe_divisa>=(acumulado_divisa+@montoMonDiv)";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idAliadoDoc", det.idAliadoDoc);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@montoMonDiv", det.motnoDocSerMonDiv);
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r4 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ALIADO-DOCUMENTO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            //ACTUALIZAR SALDO ALIADO-DOCUMENTO-SERVICIO
                            sql = @"update transp_aliado_doc_servicio set 
                                        monto_acumulado_div=monto_acumulado_div+@montoMonDiv
                                    where id=@idAliadoDocServ and 
                                            estatus_anulado<>'1' and 
                                            importe_serv_div>=(monto_acumulado_div+@montoMonDiv)";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idAliadoDocServ", det.idAliadoDocServ);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@montoMonDiv", det.motnoDocSerMonDiv);
                            var r5 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r5 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ALIADO-DOCUMENTO-SERVICIO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }
                        //
                        //INSERTAR CAJAS USADA 
                        foreach (var rg in mov.cajas)
                        {
                            //INSERTAR MOV-CAJA
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
                            var _concepto = "PAGO ALIADO: " + ficha.movimiento.nombreAliado + ", POR SERVCICIO PRESTADO SEGUN RECIBO NUMERO: " + numRecibo;
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@concepto_mov", _concepto);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_act", rg.montoUsadoMonAct);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_div", rg.montoUsadoMonDiv);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio_mov", mov.tasaFactorCambio);
                            p06 = new MySql.Data.MySqlClient.MySqlParameter("@mov_fue_divisa", rg.esDivisa ? "1" : "0");
                            p07 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_emision", mov.fechaEmision);
                            var r6 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06, p07);
                            if (r6 == 0)
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
                            //INSERTAR CAJA USADA CON EL MOVIMIENTO GENERADO
                            sql = @"INSERT INTO transp_aliado_pagoserv_caj (
                                        id, 
                                        id_pagoserv, 
                                        id_aliado, 
                                        id_caja, 
                                        id_caja_mov, 
                                        desc_caja, 
                                        monto, 
                                        es_divisa, 
                                        fecha_registro, 
                                        estatus_anulado
                                    ) 
                                    VALUES (
                                        NULL,
                                        @id_pagoserv, 
                                        @id_aliado, 
                                        @id_caja, 
                                        @id_caja_mov, 
                                        @desc_caja, 
                                        @monto, 
                                        @es_divisa, 
                                        @fecha_registro, 
                                        '0'
                                    )";
                            var cjMov = rg;
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_pagoserv", idpago);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@id_aliado", mov.idAliado);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja_mov", idMov);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@desc_caja", rg.descCaja);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.montoUsado);
                            p06 = new MySql.Data.MySqlClient.MySqlParameter("@es_divisa", rg.esDivisa ? "1" : "0");
                            p07 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                            var r7 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06, p07);
                            if (r7 == 0)
                            {
                                result.Mensaje = "ERROR AL INSERTAR ALIADO-PAGOSERV-CAJ ";
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
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.montoUsado);
                            var r8 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r8 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }
                        //
                        // ACTUALIZAR ALIADO ANTICPOS
                        sql = @"update transp_aliado set
                                    monto_anticipos_mon_divisa= monto_anticipos_mon_divisa-@montoAnticipo,
                                    monto_anticipos_ret_mon_divisa=monto_anticipos_ret_mon_divisa-@montoRetAnticipo
                                where id=@idAliado";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", ficha.movimiento.idAliado );
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoAnticipo", ficha.MontoPorAnticipoUsado);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@montoRetAnticipo", ficha.MontoPorRetAnticipoUsado);
                        var r9 = cnn.Database.ExecuteSqlCommand(sql, p01, p02, p03);
                        if (r9 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR MONTO ANTICIPO ALIADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        ts.Commit();
                        result.Id = idpago;
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
            Transporte_Aliado_PagoServ_AnularPago(DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha ficha)
        {
            var result = new DtoLib.ResultadoEntidad<int>();
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
                        var sql = @"update transp_aliado_pagoserv 
                                        set estatus_anulado='1'
                                    where id=@idPago 
                                            and estatus_anulado='0' 
                                            and estatus_procesado='0'";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@idPago", ficha.idMovPago);
                        var r1 = cnn.Database.ExecuteSqlCommand(sql,p00);
                        if (r1 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS MOVIMIENTO DE PAGO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        foreach (var det in ficha.detalles)
                        {
                            //
                            //
                            sql = @"update transp_aliado_pagoserv_det
                                        set estatus_anulado='1'
                                    where id=@idPagoServDet";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idPagoServDet", det.idPagoServDet);
                            var r2 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r2 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ESTATUS DETALLE DE PAGO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            //
                            sql = @"update transp_aliado_doc 
                                        set acumulado_divisa=acumulado_divisa-@monto
                                    where id=@idAliadoDoc";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idAliadoDoc", det.idAliadoDoc);
                            var p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", det.monto);
                            var r3 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r3 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ALIADO-DOCUMENTO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            //
                            sql = @"update transp_aliado_doc_servicio set 
                                        monto_acumulado_div=monto_acumulado_div-@monto
                                    where id=@idAliadoDocServ";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idAliadoDocServ", det.idAliadoDocServ);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", det.monto);
                            var r4 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r4 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR ALIADO-DOCUMENTO-SERVICIO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }
                        //
                        foreach (var rg in ficha.cajas)
                        {
                            //
                            //
                            sql = @"update transp_aliado_pagoserv_caj set 
                                        estatus_anulado='1'
                                    where id=@idPagoServCaja";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idPagoServCaja", rg.idPagoServCaja);
                            var r5 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r5 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR PAGOSERV-CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                            //
                            //
                            sql = @"update transp_caja_mov set 
                                        estatus_anulado_mov='1'
                                    where id=@idCajaMov";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCajaMov", rg.idCajaMov);
                            var r6 = cnn.Database.ExecuteSqlCommand(sql, p00);
                            if (r6 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR CAJA-MOV";
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
                            var r7 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                            if (r7 == 0)
                            {
                                result.Mensaje = "ERROR AL ACTUALIZAR SALDO CAJA";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }
                        //
                        // ACTUALIZAR ALIADO ANTICPOS
                        sql = @"update transp_aliado set
                                    monto_anticipos_mon_divisa= monto_anticipos_mon_divisa+@montoAnticipo,
                                    monto_anticipos_ret_mon_divisa=monto_anticipos_ret_mon_divisa+@montoRetAnticipo
                                where id=@idAliado";
                        var px0 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", ficha.idAliado);
                        var px1 = new MySql.Data.MySqlClient.MySqlParameter("@montoAnticipo", ficha.montoPorAnticipoUsado);
                        var px2 = new MySql.Data.MySqlClient.MySqlParameter("@montoRetAnticipo", ficha.montoPorRetAnticipoUsado);
                        var r8 = cnn.Database.ExecuteSqlCommand(sql, px0, px1, px2);
                        if (r8 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR MONTO ANTICIPO ALIADO";
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha> 
            Transporte_Aliado_PagoServ_AnularPago_ObtenerData(int idMovPago)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"select 
                                    id as idMovPago,
                                    id_aliado as idAliado,
                                    monto_anticipo_usado as montoPorAnticipoUsado,  
                                    monto_anticipo_ret_usado as montoPorRetAnticipoUsado 
                                from transp_aliado_pagoserv
                                where id=@idMovPago";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMovPago", idMovPago);
                    var _ent= cnn.Database.SqlQuery<DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha>(sql, p0).FirstOrDefault();
                    if (_ent == null) 
                    {
                        result.Mensaje = "MOVIMIENTO DE PAGO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    //
                    sql = @"select 
                                    id as idPagoServDet,
                                    id_aliado_doc as idAliadoDoc,
                                    id_aliado_serv as idAliadoDocServ, 
                                    monto_pago_mon_div as monto 
                                from transp_aliado_pagoserv_det
                                where id_pagoserv=@idMovPago";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMovPago", idMovPago);
                    var _det= cnn.Database.SqlQuery<DtoLibTransporte.Aliado.PagoServ.AnularPago.detalleDoc>(sql, p0).ToList();
                    _ent.detalles = _det;
                    //
                    sql = @"select 
                                    id as idPagoServCaja,
                                    id_caja as idCaja,
                                    id_caja_mov as idCajaMov, 
                                    monto as monto 
                                from transp_aliado_pagoserv_caj
                                where id_pagoserv=@idMovPago";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMovPago", idMovPago);
                    var _caj = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.PagoServ.AnularPago.caja>(sql, p0).ToList();
                    _ent.cajas = _caj;
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
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.Lista.Ficha>
            Transporte_Aliado_PagoServ_GetLista(DtoLibTransporte.Aliado.PagoServ.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as idMov,
                                        aliado_nombre as nombreAliado,
                                        aliado_cirif as cirifAliado,
                                        recibo_numero as numRecibo,
                                        fecha_registro as fecha,
                                        motivo as motivo,
                                        monto_mon_div as montoPagoSelMonDiv,
                                        estatus_anulado as estatusAnulado,
                                        estatus_procesado as estatusProcesado,
                                        cnt_serv_pag as cntServPag
                                    FROM transp_aliado_pagoserv";
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
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.PagoServ.Lista.Ficha>(_sql, p1, p2, p3, p4).ToList();
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