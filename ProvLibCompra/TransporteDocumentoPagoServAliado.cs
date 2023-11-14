using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider : ILibCompras.IProvider
    {
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha>
            Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(int idPagoServ)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as idPago,
                                        id_aliado as idAliado,
                                        recibo_numero as nroRecibo,
                                        monto_mon_div as totalMonDiv,
                                        monto_mon_act as totalMonAct,
                                        tasa_factor as tasaCambio,
                                        tasa_ret as tasaRet,
                                        retencion as retencion,
                                        sustraendo as sustraendo,
                                        monto_ret_mon_act as totalRetMonAct,
                                        monto_ret_mon_div as totalRetMonDiv
                                    FROM transp_aliado_pagoserv
                                    where id=@idPagoServ";
                    var _sql_2 = @"";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idPagoServ", idPagoServ);
                    var _sql = _sql_1 + _sql_2;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha>(_sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("REGISTRO NO ENCONTRADO");
                    };
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Resultado>
            Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Ficha ficha)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Resultado>();
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
                        var sql = "update sistema_contadores set a_compras=a_compras+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var aMovCompra = cnn.Database.SqlQuery<int>("select a_compras from sistema_contadores").FirstOrDefault();
                        var autoEntCompra = aMovCompra.ToString().Trim().PadLeft(10, '0');
                        var _tipoDocumentoCompra = "2";
                        //
                        //INSERTAR DOCUMENTO DE COMPRA
                        sql = @"INSERT INTO compras (
                                auto, 
                                documento, 
                                fecha, 
                                fecha_vencimiento, 
                                razon_social, 
                                dir_fiscal, 
                                ci_rif, 
                                tipo, 
                                exento, 
                                base1,  
                                base2, 
                                base3, 
                                impuesto1, 
                                impuesto2, 
                                impuesto3, 
                                base, 
                                impuesto, 
                                total, 
                                tasa1, 
                                tasa2, 
                                tasa3, 
                                nota, 
                                tasa_retencion_iva, 
                                tasa_retencion_islr, 
                                retencion_iva, 
                                retencion_islr, 
                                auto_proveedor, 
                                codigo_proveedor, 
                                mes_relacion, 
                                control, 
                                fecha_registro, 
                                orden_compra, 
                                dias,   
                                descuento1, 
                                descuento2, 
                                cargos, 
                                descuento1p, 
                                descuento2p, 
                                cargosp, 
                                columna, 
                                estatus_anulado, 
                                aplica, 
                                comprobante_retencion, 
                                subtotal_neto, 
                                telefono, 
                                factor_cambio,              
                                condicion_pago, 
                                usuario, 
                                codigo_usuario, 
                                codigo_sucursal, 
                                hora, 
                                monto_divisa, 
                                estacion, 
                                renglones, 
                                saldo_pendiente, 
                                ano_relacion, 
                                comprobante_retencion_islr, 
                                dias_validez,
                                auto_usuario, 
                                situacion, 
                                signo, 
                                serie, 
                                tarifa, 
                                tipo_remision, 
                                documento_remision, 
                                auto_remision, 
                                documento_nombre, 
                                subtotal_impuesto, 
                                subtotal, 
                                auto_cxp, 
                                tipo_proveedor, 
                                planilla, 
                                expediente, 
                                anticipo_iva, 
                                terceros_iva, 
                                neto, 
                                costo, 
                                utilidad, 
                                utilidadp, 
                                documento_tipo, 
                                denominacion_fiscal, 
                                auto_concepto, 
                                fecha_retencion, 
                                estatus_cierre_contable, 
                                cierre_ftp, 
                                estatus_fiscal,
                                id_compras_concepto,
                                desc_compras_concepto,
                                codigo_compras_concepto,
                                auto_sucursal,
                                desc_sucursal,
                                igtf_monto,
                                tipo_documento_compra,
                                sustraendo_ret_islr,
                                monto_ret_islr,
                                auto_sistema_documento,
                                maquina_fiscal)
                            VALUES (
                                @auto, 
                                @documento, 
                                @fecha, 
                                @fecha_vencimiento, 
                                @razon_social, 
                                @dir_fiscal, 
                                @ci_rif, 
                                @tipo, 
                                @exento, 
                                @base1,  
                                @base2, 
                                @base3, 
                                @impuesto1, 
                                @impuesto2, 
                                @impuesto3, 
                                @base, 
                                @impuesto, 
                                @total, 
                                @tasa1, 
                                @tasa2, 
                                @tasa3, 
                                @nota, 
                                @tasa_retencion_iva, 
                                @tasa_retencion_islr, 
                                @retencion_iva, 
                                @retencion_islr, 
                                @auto_proveedor, 
                                @codigo_proveedor, 
                                @mes_relacion, 
                                @control, 
                                @fecha_registro, 
                                @orden_compra, 
                                @dias, 
                                0,
                                0,
                                0,  
                                0,
                                0,
                                0,
                                @columna, 
                                @estatus_anulado, 
                                @aplica, 
                                @comprobante_retencion, 
                                @subtotal_neto, 
                                @telefono, 
                                @factor_cambio,              
                                @condicion_pago, 
                                @usuario, 
                                @codigo_usuario, 
                                @codigo_sucursal, 
                                @hora, 
                                @monto_divisa, 
                                @estacion, 
                                0, 
                                @saldo_pendiente, 
                                @ano_relacion, 
                                @comprobante_retencion_islr, 
                                0,
                                @auto_usuario, 
                                @situacion, 
                                @signo, 
                                @serie, 
                                @tarifa, 
                                @tipo_remision, 
                                @documento_remision, 
                                @auto_remision, 
                                @documento_nombre, 
                                @subtotal_impuesto, 
                                @subtotal, 
                                @auto_cxp, 
                                @tipo_proveedor, 
                                @planilla, 
                                @expediente, 
                                0, 
                                0, 
                                @neto, 
                                0, 
                                0, 
                                0, 
                                @documento_tipo, 
                                @denominacion_fiscal, 
                                @auto_concepto, 
                                @fecha_retencion, 
                                @estatus_cierre_contable, 
                                @cierre_ftp, 
                                @estatus_fiscal,    
                                @id_compras_concepto,
                                @desc_compras_concepto,
                                @codigo_compras_concepto,
                                @auto_sucursal,
                                @desc_sucursal,
                                @igtf_monto,
                                @tipo_documento_compra,
                                @sustraendo_ret_islr,
                                @monto_ret_islr,
                                @auto_sistema_documento,
                                @maquina_fiscal)";
                        var doc = ficha.documento;
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoEntCompra);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", doc.numeroDoc);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", doc.fechaEmisDoc);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento", doc.fechaVencDoc);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@razon_social", doc.nombreProv);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal", doc.dirFiscalProv);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", doc.ciRifProv);
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@tipo", doc.codTipoDoc);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@exento", doc.montoExento);
                        var p09 = new MySql.Data.MySqlClient.MySqlParameter("@base1", doc.montoBase1);
                        //
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@base2", doc.montoBase2);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@base3", doc.montoBase3);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto1", doc.montoImpuesto1);
                        var p13 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto2", doc.montoImpuesto2);
                        var p14 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto3", doc.montoImpuesto3);
                        var p15 = new MySql.Data.MySqlClient.MySqlParameter("@base", doc.montoBase);
                        var p16 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto", doc.montoImpuesto);
                        var p17 = new MySql.Data.MySqlClient.MySqlParameter("@total", doc.montoTotal);
                        var p18 = new MySql.Data.MySqlClient.MySqlParameter("@tasa1", doc.tasaIva1);
                        var p19 = new MySql.Data.MySqlClient.MySqlParameter("@tasa2", doc.tasaIva2);
                        //
                        var p20 = new MySql.Data.MySqlClient.MySqlParameter("@tasa3", doc.tasaIva3);
                        var p21 = new MySql.Data.MySqlClient.MySqlParameter("@nota", doc.notasDoc);
                        var p22 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion_iva", doc.tasaRetencionIva);
                        var p23 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion_islr", doc.tasaRetencionISLR);
                        var p24 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_iva", doc.montoRetencionIva);
                        var p25 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_islr", doc.totalRetISLR);
                        var p26 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", doc.autoProv);
                        var p27 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", doc.codigoProv);
                        var p28 = new MySql.Data.MySqlClient.MySqlParameter("@mes_relacion", mesRelacion);
                        var p29 = new MySql.Data.MySqlClient.MySqlParameter("@control", doc.numeroControlDoc);
                        //
                        var p30 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                        var p31 = new MySql.Data.MySqlClient.MySqlParameter("@orden_compra", "");
                        var p32 = new MySql.Data.MySqlClient.MySqlParameter("@dias", doc.diasCreditoDoc);
                        var p39 = new MySql.Data.MySqlClient.MySqlParameter("@columna", "");
                        //
                        var p40 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_anulado", "0");
                        var p41 = new MySql.Data.MySqlClient.MySqlParameter("@aplica", doc.aplicaNumeroDoc);
                        var p42 = new MySql.Data.MySqlClient.MySqlParameter("@comprobante_retencion", doc.comprobanteRetencionNro);
                        var p43 = new MySql.Data.MySqlClient.MySqlParameter("@subtotal_neto", doc.subTotalNeto);
                        var p44 = new MySql.Data.MySqlClient.MySqlParameter("@telefono", doc.telefonoProv);
                        var p45 = new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio", doc.factorCambio);
                        var p46 = new MySql.Data.MySqlClient.MySqlParameter("@condicion_pago", doc.codicionPagoDoc);
                        var p47 = new MySql.Data.MySqlClient.MySqlParameter("@usuario", doc.nombreUsuario);
                        var p48 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_usuario", doc.codigoUsuario);
                        var p49 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_sucursal", doc.codigoSucursal);
                        //
                        var p50 = new MySql.Data.MySqlClient.MySqlParameter("@hora", fechaSistema.ToShortTimeString());
                        var p51 = new MySql.Data.MySqlClient.MySqlParameter("@monto_divisa", doc.montoDivisa);
                        var p52 = new MySql.Data.MySqlClient.MySqlParameter("@estacion", doc.estacionEquipo);
                        var p54 = new MySql.Data.MySqlClient.MySqlParameter("@saldo_pendiente", doc.saldoPendiente);
                        var p55 = new MySql.Data.MySqlClient.MySqlParameter("@ano_relacion", anoRelacion);
                        var p56 = new MySql.Data.MySqlClient.MySqlParameter("@comprobante_retencion_islr", doc.comprobanteRetencionISLR);
                        var p58 = new MySql.Data.MySqlClient.MySqlParameter("@auto_usuario", doc.autoUsuario);
                        var p59 = new MySql.Data.MySqlClient.MySqlParameter("@situacion", "Procesado");
                        //
                        var p60 = new MySql.Data.MySqlClient.MySqlParameter("@signo", doc.signoDoc);
                        var p61 = new MySql.Data.MySqlClient.MySqlParameter("@serie", doc.siglasDoc);
                        var p62 = new MySql.Data.MySqlClient.MySqlParameter("@tarifa", "");
                        var p63 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_remision", doc.aplicaCodTipoDoc);
                        var p64 = new MySql.Data.MySqlClient.MySqlParameter("@documento_remision", doc.aplicaNumeroDoc);
                        var p65 = new MySql.Data.MySqlClient.MySqlParameter("@auto_remision", "");
                        var p66 = new MySql.Data.MySqlClient.MySqlParameter("@documento_nombre", doc.nombreDoc);
                        var p67 = new MySql.Data.MySqlClient.MySqlParameter("@subtotal_impuesto", doc.subTotalImpuesto);
                        var p68 = new MySql.Data.MySqlClient.MySqlParameter("@subtotal", doc.subTotal);
                        var p69 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", "");
                        //
                        var p70 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_proveedor", "");
                        var p71 = new MySql.Data.MySqlClient.MySqlParameter("@planilla", "");
                        var p72 = new MySql.Data.MySqlClient.MySqlParameter("@expediente", "");
                        var p75 = new MySql.Data.MySqlClient.MySqlParameter("@neto", doc.montoNeto);
                        var p79 = new MySql.Data.MySqlClient.MySqlParameter("@documento_tipo", doc.moduloDoc);
                        //
                        var p80 = new MySql.Data.MySqlClient.MySqlParameter("@denominacion_fiscal", "");
                        var p81 = new MySql.Data.MySqlClient.MySqlParameter("@auto_concepto", "");
                        var p82 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_retencion", doc.fechaRetencion);
                        var p83 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable", "0");
                        var p84 = new MySql.Data.MySqlClient.MySqlParameter("@cierre_ftp", "");
                        var p85 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_fiscal", doc.estatusFiscal);
                        var p86 = new MySql.Data.MySqlClient.MySqlParameter("@id_compras_concepto", doc.idComprasConcepto);
                        var p87 = new MySql.Data.MySqlClient.MySqlParameter("@desc_compras_concepto", doc.descComprasConcepto);
                        var p88 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_compras_concepto", doc.codigoComprasConcepto);
                        var p89 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sucursal", doc.autoSucursal);
                        //
                        var p90 = new MySql.Data.MySqlClient.MySqlParameter("@desc_sucursal", doc.descSucursal);
                        var p91 = new MySql.Data.MySqlClient.MySqlParameter("@igtf_monto", doc.igtfMonto);
                        var p92 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento_compra", _tipoDocumentoCompra);
                        var p93 = new MySql.Data.MySqlClient.MySqlParameter("@sustraendo_ret_islr", doc.sustraendoRetISLR);
                        var p94 = new MySql.Data.MySqlClient.MySqlParameter("@monto_ret_islr", doc.montoRetISLR);
                        var p95 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", doc.autoSistemaDocumento);
                        var p96 = new MySql.Data.MySqlClient.MySqlParameter("@maquina_fiscal", doc.maquinafiscal);
                        //
                        var r2 = cnn.Database.ExecuteSqlCommand(sql,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                            p20, p21, p22, p23, p24, p25, p26, p27, p28, p29,
                            p30, p31, p32, p39,
                            p40, p41, p42, p43, p44, p45, p46, p47, p48, p49,
                            p50, p51, p52, p54, p55, p56, p58, p59,
                            p60, p61, p62, p63, p64, p65, p66, p67, p68, p69,
                            p70, p71, p72, p75, p79,
                            p80, p81, p82, p83, p84, p85, p86, p87, p88, p89,
                            p90, p91, p92, p93, p94, p95, p96);
                        if (r2 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR DOCUMENTO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZAR PROVEEDOR SALDO/FECHA
                        sql = @"update proveedores set
                                    debitos=debitos+@montoDebito,
                                    creditos=creditos+@montoCredito,
                                    fecha_ult_compra=@fechaEmision
                                where auto=@autoProv";
                        var _prv = ficha.documento.proveedor;
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoProv", _prv.autoProv);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoDebito", _prv.montoDebito);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@fechaEmision", _prv.fechaEmiDoc);
                        p04 = new MySql.Data.MySqlClient.MySqlParameter("@montoCredito", _prv.montoCredito);
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p01, p02, p03, p04);
                        if (r3 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR DATA PROVEEDOR";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // HAY DOCUMENTO COMPRA RETENCION 
                        if (ficha.documento.docRet != null)
                        {
                            foreach (var rgDocRet in ficha.documento.docRet)
                            {
                                sql = @"update sistema_contadores set 
                                            a_compras_retenciones=a_compras_retenciones+1, 
                                            a_compras_retencion_islr=a_compras_retencion_islr+1";
                                var xr1 = cnn.Database.ExecuteSqlCommand(sql);
                                var aCompraRet = cnn.Database.SqlQuery<int>("select a_compras_retenciones from sistema_contadores").FirstOrDefault();
                                var autoCompraRet = aCompraRet.ToString().Trim().PadLeft(10, '0');
                                //
                                var numDocCompraRet = "";
                                var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_islr from sistema_contadores").FirstOrDefault();
                                numDocCompraRet = n.ToString().Trim().PadLeft(10, '0');
                                sql = @"INSERT INTO compras_retenciones (
                                        auto, 
                                        documento, 
                                        fecha, 
                                        razon_social, 
                                        dir_fiscal, 
                                        ci_rif, 
                                        tipo, 
                                        exento, 
                                        base, 
                                        impuesto, 
                                        total, 
                                        tasa_retencion, 
                                        retencion, 
                                        auto_proveedor, 
                                        fecha_relacion, 
                                        codigo_proveedor, 
                                        ano_relacion, 
                                        mes_relacion, 
                                        renglones, 
                                        documento_nombre, 
                                        base2, 
                                        impuesto2, 
                                        estatus_anulado, 
                                        base3, 
                                        impuesto3, 
                                        estatus_cierre_contable,
                                        auto_sistema_documento,
                                        retencion_monto,
                                        retencion_sustraendo)
                                    VALUES (
                                        @auto, 
                                        @documento, 
                                        @fecha, 
                                        @razon_social, 
                                        @dir_fiscal, 
                                        @ci_rif, 
                                        @tipo, 
                                        @exento, 
                                        @base, 
                                        @impuesto, 
                                        @total, 
                                        @tasa_retencion, 
                                        @retencion, 
                                        @auto_proveedor, 
                                        @fecha_relacion, 
                                        @codigo_proveedor, 
                                        @ano_relacion, 
                                        @mes_relacion, 
                                        1,
                                        @documento_nombre, 
                                        @base2, 
                                        @impuesto2, 
                                        '0',
                                        @base3, 
                                        @impuesto3, 
                                        '0',
                                        @auto_sistema_documento,
                                        @retencion_monto,
                                        @retencion_sustraendo)";
                                var _docRet = rgDocRet;
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoCompraRet);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", numDocCompraRet);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@razon_social", _docRet.PrvNombre);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal", _docRet.PrvDirFiscal);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", _docRet.PrvCiRif);
                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@tipo", _docRet.SistDocCodigo);
                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@exento", _docRet.MontoExento);
                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@base", _docRet.MontoBase1);
                                p09 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto", _docRet.MontoImpuesto1);
                                //
                                p10 = new MySql.Data.MySqlClient.MySqlParameter("@total", _docRet.MontoTotal);
                                p11 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion", _docRet.TasaRetencion);
                                p12 = new MySql.Data.MySqlClient.MySqlParameter("@retencion", _docRet.MontoRetencion);
                                p13 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", _docRet.PrvAuto);
                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_relacion", fechaSistema.Date);
                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", _docRet.PrvCodigo);
                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@ano_relacion", anoRelacion);
                                p17 = new MySql.Data.MySqlClient.MySqlParameter("@mes_relacion", mesRelacion);
                                p18 = new MySql.Data.MySqlClient.MySqlParameter("@documento_nombre", _docRet.SistDocNombre);
                                p19 = new MySql.Data.MySqlClient.MySqlParameter("@base2", _docRet.MontoBase2);
                                //
                                p20 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto2", _docRet.MontoImpuesto2);
                                p21 = new MySql.Data.MySqlClient.MySqlParameter("@base3", _docRet.MontoBase3);
                                p22 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto3", _docRet.MontoImpuesto3);
                                p23 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", _docRet.SistDocAuto);
                                p24 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_monto", _docRet.retMonto);
                                p25 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_sustraendo", _docRet.retSustraendo);
                                var rf1 = cnn.Database.ExecuteSqlCommand(sql,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                    p20, p21, p22, p23, p24, p25);
                                if (rf1 == 0)
                                {
                                    result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION ]";
                                    result.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return result;
                                }
                                cnn.SaveChanges();
                                //
                                // INSERTAR COMPRA RETENCION DETALLE 
                                sql = @"INSERT INTO compras_retenciones_detalle (
                                        auto_documento, 
                                        documento, 
                                        fecha, 
                                        ci_rif, 
                                        tipo, 
                                        exento, 
                                        base, 
                                        impuesto, 
                                        total, 
                                        tasa_retencion, 
                                        retencion, 
                                        auto, 
                                        fecha_retencion, 
                                        comprobante, 
                                        tipo_retencion, 
                                        aplica, 
                                        control, 
                                        tasa, 
                                        signo, 
                                        tasa2, 
                                        base1, 
                                        base2, 
                                        impuesto1, 
                                        impuesto2, 
                                        retencion1, 
                                        retencion2, 
                                        estatus_anulado, 
                                        tasa3, 
                                        base3, 
                                        impuesto3, 
                                        retencion3, 
                                        retencion_monto,
                                        retencion_sustraendo) 
                                VALUES (
                                        @auto_documento, 
                                        @documento, 
                                        @fecha, 
                                        @ci_rif, 
                                        @tipo, 
                                        @exento, 
                                        @base, 
                                        @impuesto, 
                                        @total, 
                                        @tasa_retencion, 
                                        @retencion, 
                                        @auto, 
                                        @fecha_retencion, 
                                        @comprobante, 
                                        @tipo_retencion, 
                                        @aplica, 
                                        @control, 
                                        @tasa, 
                                        @signo, 
                                        @tasa2, 
                                        @base1, 
                                        @base2, 
                                        @impuesto1, 
                                        @impuesto2, 
                                        @retencion1, 
                                        @retencion2, 
                                        '0',
                                        @tasa3, 
                                        @base3, 
                                        @impuesto3, 
                                        @retencion3,
                                        @retencion_monto,
                                        @retencion_sustraendo)";
                                foreach (var det in _docRet.docRetDetalle)
                                {
                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", autoEntCompra);
                                    p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", det.numDocRefRet);
                                    p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", det.fechaDocRefRet);
                                    p03 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", det.ciRifDocRefRet);
                                    p04 = new MySql.Data.MySqlClient.MySqlParameter("@tipo", det.sistTipoDocRefRet);
                                    p05 = new MySql.Data.MySqlClient.MySqlParameter("@exento", det.montoExento);
                                    p06 = new MySql.Data.MySqlClient.MySqlParameter("@base", det.montoBase);
                                    p07 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto", det.montoImpuesto);
                                    p08 = new MySql.Data.MySqlClient.MySqlParameter("@total", det.montoTotal);
                                    p09 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion", det.tasaRetencion);
                                    //
                                    p10 = new MySql.Data.MySqlClient.MySqlParameter("@retencion", det.totalRetencion);
                                    p11 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoCompraRet);
                                    p12 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_retencion", fechaSistema.Date);
                                    p13 = new MySql.Data.MySqlClient.MySqlParameter("@comprobante", numDocCompraRet);
                                    p14 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_retencion", det.sistTipoDocRet);
                                    p15 = new MySql.Data.MySqlClient.MySqlParameter("@aplica", det.numAplicaDocRefRet);
                                    p16 = new MySql.Data.MySqlClient.MySqlParameter("@control", det.numControlDocRefRet);
                                    p17 = new MySql.Data.MySqlClient.MySqlParameter("@tasa", det.tasa1);
                                    p18 = new MySql.Data.MySqlClient.MySqlParameter("@signo", det.sistSignoDocRet);
                                    p19 = new MySql.Data.MySqlClient.MySqlParameter("@tasa2", det.tasa2);
                                    //
                                    p20 = new MySql.Data.MySqlClient.MySqlParameter("@base1", det.base1);
                                    p21 = new MySql.Data.MySqlClient.MySqlParameter("@base2", det.base2);
                                    p22 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto1", det.impuesto1);
                                    p23 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto2", det.impuesto2);
                                    p24 = new MySql.Data.MySqlClient.MySqlParameter("@retencion1", det.retIva1);
                                    p25 = new MySql.Data.MySqlClient.MySqlParameter("@retencion2", det.retIva2);
                                    p26 = new MySql.Data.MySqlClient.MySqlParameter("@tasa3", det.tasa3);
                                    p27 = new MySql.Data.MySqlClient.MySqlParameter("@base3", det.base3);
                                    p28 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto3", det.impuesto3);
                                    p29 = new MySql.Data.MySqlClient.MySqlParameter("@retencion3", det.retIva3);
                                    //
                                    p30 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_monto", det.montoRetencion);
                                    p31 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_sustraendo", det.sustraendoRetencion);
                                    //
                                    var rf2 = cnn.Database.ExecuteSqlCommand(sql,
                                        p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                        p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                        p20, p21, p22, p23, p24, p25, p26, p27, p28, p29,
                                        p30, p31);
                                    if (rf2 == 0)
                                    {
                                        throw new Exception("ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION DETALLE ]");
                                    }
                                    cnn.SaveChanges();
                                }
                            }
                        }
                        //
                        sql = @"INSERT INTO compras_rel_transp_aliado_pagoserv (
                                    id, 
                                    auto_compra, 
                                    id_transp_alido_pago_serv, 
                                    estatus_anulado)
                                VALUES (
                                    NULL,
                                    @auto_compra, 
                                    @id_transp_alido_pago_serv, 
                                    '0')";
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto_compra", autoEntCompra);
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@id_transp_alido_pago_serv", ficha.documento.idPagoServAliado);
                        var rf3 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                        if (rf3 == 0)
                        {
                            throw new Exception("ERROR AL INSERTAR DOCUMENTO [ COMPRAS REL TRANSP_ALIADO_PAGOSERV ]");
                        }
                        cnn.SaveChanges();
                        //
                        sql = @"UPDATE transp_aliado_pagoserv set 
                                    estatus_procesado ='1'
                                where id=@idPagoServAliado and estatus_procesado='0'";
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@idPagoServAliado", ficha.documento.idPagoServAliado);
                        var rf4 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (rf4 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR TABLA [ TRANSP_ALIADO_PAGOSERV ]");
                        }
                        cnn.SaveChanges();
                        //
                        ts.Commit();
                        result.Entidad = new DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Resultado()
                        {
                            autoDocCompra = autoEntCompra,
                            autoDocCxp = "",
                        };
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
        public DtoLib.ResultadoEntidad<bool>
            Transporte_Documento_ChequearSiEs_CompraGrasto_DePagoAliadoServ(string autoDoc)
        {
            var rt = new DtoLib.ResultadoEntidad<bool>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select 
                                    1
                                from compras as c 
                                join compras_rel_transp_aliado_pagoserv as relPagServ on c.auto=relPagServ.auto_compra
                                where auto=@autoDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", autoDoc);
                    var _ent = cnn.Database.SqlQuery<verificarAnular>(_sql, p1).FirstOrDefault();
                    var _resul = true;
                    if (_ent == null)
                    {
                        _resul = false;
                    }
                    rt.Entidad = _resul; 
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return rt;
        }
        public DtoLib.Resultado
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(string autoDoc)
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
                                c.fecha_registro as fechaRegistro,
                                c.estatus_anulado as estatusAnulado,
                                c.estatus_cierre_contable as estatusCierreContable
                            from compras as c 
                            join compras_rel_transp_aliado_pagoserv as relPagServ on c.auto=relPagServ.auto_compra
                            where auto=@autoDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", autoDoc);
                    var _ent = cnn.Database.SqlQuery<verificarAnular>(_sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("DOCUMENTO NO ENCONTRADO");
                    }
                    if (_ent.estatusAnulado == "1")
                    {
                        throw new Exception("DOCUMENTO YA ANULADO");
                    }
                    if (_ent.fechaRegistro.Year != fechaSistema.Year || _ent.fechaRegistro.Month != fechaSistema.Month)
                    {
                        throw new Exception("DOCUMENTO SE ENCUENTRA EN OTRO PERIODO");
                    }
                    if (_ent.estatusCierreContable == "1")
                    {
                        throw new Exception("DOCUMENTO SE ENCUENTRA BLOQUEADO CONTABLEMENTE");
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGastoAliado.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(string autoDoc)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGastoAliado.GetData.Ficha>();
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
                                    doc.monto_divisa as totalDivisa,
                                    relPagServ.id as idRelPagServ,
                                    relPagServ.id_transp_alido_pago_serv as idTranspAliadoPagServ
                                from compras as doc
                                join compras_rel_transp_aliado_pagoserv as relPagServ on doc.auto=relPagServ.auto_compra
                                where doc.auto=@autoDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", autoDoc);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Anular.CompraGastoAliado.GetData.Documento>(sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("DOCUMENTO NO ENCONTRADO");
                    }
                    //
                    //OBTENER DATA DE LAS RESPECTIVAS RETENCIONES REALIZADAS AL PROCESAR DOCUMENTO 
                    sql = @"SELECT 
                                compRetDet.auto as autoDocCompraRet
                            FROM compras_retenciones_detalle as compRetDet
                            join compras as compra on compra.auto=compRetDet.auto_documento
                            where compRetDet.auto_documento=@autoDocCompra and
                                (compra.retencion_iva>0 or compra.retencion_islr>0)";
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDocCompra", autoDoc);
                    var _lstRetComp = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Anular.CompraGastoAliado.GetData.RetDoc>(sql, p1).ToList();
                    //
                    result.Entidad = new DtoLibTransporte.Documento.Anular.CompraGastoAliado.GetData.Ficha()
                    {
                        documento = _ent,
                        retencionDoc = _lstRetComp,
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
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ(DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular.Ficha ficha)
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
                            throw new Exception("PROBLEMA AL ACTUALIZAR TABLA CONTADORES");
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
                                throw new Exception("PROBLEMA AL REGISTRAR MOVIMIENTO AUDITORIA");
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
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS ANULADO DOCUMENTO COMPRA");
                        }
                        cnn.SaveChanges();
                        //
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoProv", ficha.proveedor.autoProv);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoDebito", ficha.proveedor.montoDebito);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@montoCredito", ficha.proveedor.montoCredito);
                        sql = @"update proveedores set
                                    debitos=debitos-@montoDebito,
                                    creditos=creditos-@montoCredito
                                where auto=@autoProv";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p01, p02, p03);
                        if (r3 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR DATA PROVEEDOR");
                        }
                        cnn.SaveChanges();
                        //
                        if (ficha.docRetCompra != null)
                        {
                            foreach (var rg in ficha.docRetCompra)
                            {
                                sql = @"update compras_retenciones set 
                                            estatus_anulado='1'
                                        where auto=@autoDocCompraRet";
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoDocCompraRet", rg.autoDocRetCompra);
                                var r7 = cnn.Database.ExecuteSqlCommand(sql, p00);
                                if (r7 == 0)
                                {
                                    throw new Exception("ERROR AL ACTUALIZAR ESTATUS DOCUMENTO COMPRA RETENCION");
                                }
                                cnn.SaveChanges();
                                //
                                sql = @"update compras_retenciones_detalle set 
                                            estatus_anulado='1'
                                        where auto=@autoDocCompraRet";
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoDocCompraRet", rg.autoDocRetCompra);
                                var r8 = cnn.Database.ExecuteSqlCommand(sql, p00);
                                if (r8 == 0)
                                {
                                    throw new Exception("ERROR AL ACTUALIZAR ESTATUS DOCUMENTO COMPRA RETENCION DETALLE");
                                }
                                cnn.SaveChanges();
                            }
                        }
                        //
                        sql = @"update transp_aliado_pagoserv set 
                                    estatus_procesado='1'
                                where id=@idPagoServ";
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@idPagoServ", ficha.idPagoServicio);
                        var r9 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r9 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS TABLA [ TRANSP_ALIADO_PAGOSERV ] ");
                        }
                        cnn.SaveChanges();
                        //
                        sql = @"update compras_rel_transp_aliado_pagoserv set 
                                    estatus_anulado='1'
                                where id=@idRelacion";
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@idRelacion", ficha.idRelCompraPago);
                        var r10 = cnn.Database.ExecuteSqlCommand(sql, p00);
                        if (r10 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR ESTATUS TABLA [ COMPRAS_REL_TRANSP_ALIADO_PAGOSERV ] ");
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
    }
}
