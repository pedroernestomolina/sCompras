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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado> 
            Transporte_Documento_Agregar_CompraGrasto(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var mesRelacion = fechaSistema.Month.ToString().Trim().PadLeft(2,'0');
                        var anoRelacion = fechaSistema.Year.ToString().Trim().PadLeft(4,'0');
                        //
                        var sql = "update sistema_contadores set a_compras=a_compras+1, a_cxp=a_cxp+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var aMovCompra = cnn.Database.SqlQuery<int>("select a_compras from sistema_contadores").FirstOrDefault();
                        var aMovCxP = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
                        var autoEntCompra = aMovCompra.ToString().Trim().PadLeft(10, '0');
                        var autoEntCxP = aMovCxP.ToString().Trim().PadLeft(10, '0');
                        var _tipoDocumentoCompra = "";
                        switch (ficha.documento.tipoDocumentoCompra)
                        { 
                            case  DtoLibTransporte.Documento.Agregar.CompraGasto.enumerados.tipoDocumentoCompra.MERCANCIA:
                                _tipoDocumentoCompra = "1";
                                break;
                            case DtoLibTransporte.Documento.Agregar.CompraGasto.enumerados.tipoDocumentoCompra.GASTO:
                                _tipoDocumentoCompra = "2";
                                break;
                        }
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
                                auto_sistema_documento
                            ) VALUES (
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
                                @auto_sistema_documento
                            )";
                        var doc= ficha.documento;
                        var p00= new MySql.Data.MySqlClient.MySqlParameter("@auto",autoEntCompra);
                        var p01= new MySql.Data.MySqlClient.MySqlParameter("@documento",doc.numeroDoc);
                        var p02= new MySql.Data.MySqlClient.MySqlParameter("@fecha",doc.fechaEmisDoc);
                        var p03= new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento",doc.fechaVencDoc);
                        var p04= new MySql.Data.MySqlClient.MySqlParameter("@razon_social",doc.nombreProv);
                        var p05= new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal",doc.dirFiscalProv);
                        var p06= new MySql.Data.MySqlClient.MySqlParameter("@ci_rif",doc.ciRifProv);
                        var p07= new MySql.Data.MySqlClient.MySqlParameter("@tipo",doc.codTipoDoc);
                        var p08= new MySql.Data.MySqlClient.MySqlParameter("@exento",doc.montoExento);
                        var p09= new MySql.Data.MySqlClient.MySqlParameter("@base1",doc.montoBase1);
                        //
                        var p10= new MySql.Data.MySqlClient.MySqlParameter("@base2",doc.montoBase2);
                        var p11= new MySql.Data.MySqlClient.MySqlParameter("@base3",doc.montoBase3);
                        var p12= new MySql.Data.MySqlClient.MySqlParameter("@impuesto1",doc.montoImpuesto1);
                        var p13= new MySql.Data.MySqlClient.MySqlParameter("@impuesto2",doc.montoImpuesto2);
                        var p14= new MySql.Data.MySqlClient.MySqlParameter("@impuesto3",doc.montoImpuesto3);
                        var p15= new MySql.Data.MySqlClient.MySqlParameter("@base",doc.montoBase);
                        var p16= new MySql.Data.MySqlClient.MySqlParameter("@impuesto",doc.montoImpuesto);
                        var p17= new MySql.Data.MySqlClient.MySqlParameter("@total",doc.montoTotal);
                        var p18= new MySql.Data.MySqlClient.MySqlParameter("@tasa1",doc.tasaIva1);
                        var p19= new MySql.Data.MySqlClient.MySqlParameter("@tasa2",doc.tasaIva2);
                        //
                        var p20= new MySql.Data.MySqlClient.MySqlParameter("@tasa3",doc.tasaIva3);
                        var p21= new MySql.Data.MySqlClient.MySqlParameter("@nota",doc.notasDoc);
                        var p22= new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion_iva",doc.tasaRetencionIva);
                        var p23= new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion_islr",doc.tasaRetencionISLR);
                        var p24= new MySql.Data.MySqlClient.MySqlParameter("@retencion_iva",doc.montoRetencionIva);
                        var p25= new MySql.Data.MySqlClient.MySqlParameter("@retencion_islr",doc.totalRetISLR);
                        var p26= new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor",doc.autoProv);
                        var p27= new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor",doc.codigoProv);
                        var p28= new MySql.Data.MySqlClient.MySqlParameter("@mes_relacion", mesRelacion);
                        var p29= new MySql.Data.MySqlClient.MySqlParameter("@control",doc.numeroControlDoc);
                        //
                        var p30= new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro",fechaSistema.Date);
                        var p31= new MySql.Data.MySqlClient.MySqlParameter("@orden_compra","");
                        var p32= new MySql.Data.MySqlClient.MySqlParameter("@dias",doc.diasCreditoDoc);
                        var p39= new MySql.Data.MySqlClient.MySqlParameter("@columna","");
                        //
                        var p40= new MySql.Data.MySqlClient.MySqlParameter("@estatus_anulado","0");
                        var p41= new MySql.Data.MySqlClient.MySqlParameter("@aplica",doc.aplicaNumeroDoc);
                        var p42= new MySql.Data.MySqlClient.MySqlParameter("@comprobante_retencion",doc.comprobanteRetencionNro);
                        var p43= new MySql.Data.MySqlClient.MySqlParameter("@subtotal_neto",doc.subTotalNeto);
                        var p44= new MySql.Data.MySqlClient.MySqlParameter("@telefono",doc.telefonoProv);
                        var p45= new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio",doc.factorCambio);
                        var p46= new MySql.Data.MySqlClient.MySqlParameter("@condicion_pago",doc.codicionPagoDoc);
                        var p47= new MySql.Data.MySqlClient.MySqlParameter("@usuario",doc.nombreUsuario);
                        var p48= new MySql.Data.MySqlClient.MySqlParameter("@codigo_usuario",doc.codigoUsuario);
                        var p49= new MySql.Data.MySqlClient.MySqlParameter("@codigo_sucursal",doc.codigoSucursal);
                        //
                        var p50= new MySql.Data.MySqlClient.MySqlParameter("@hora",fechaSistema.ToShortTimeString());
                        var p51= new MySql.Data.MySqlClient.MySqlParameter("@monto_divisa",doc.montoDivisa);
                        var p52= new MySql.Data.MySqlClient.MySqlParameter("@estacion",doc.estacionEquipo);
                        var p54= new MySql.Data.MySqlClient.MySqlParameter("@saldo_pendiente",doc.saldoPendiente);
                        var p55= new MySql.Data.MySqlClient.MySqlParameter("@ano_relacion",anoRelacion);
                        var p56= new MySql.Data.MySqlClient.MySqlParameter("@comprobante_retencion_islr",doc.comprobanteRetencionISLR);
                        var p58= new MySql.Data.MySqlClient.MySqlParameter("@auto_usuario",doc.autoUsuario);
                        var p59= new MySql.Data.MySqlClient.MySqlParameter("@situacion","Procesado");
                        //
                        var p60= new MySql.Data.MySqlClient.MySqlParameter("@signo",doc.signoDoc);
                        var p61= new MySql.Data.MySqlClient.MySqlParameter("@serie",doc.siglasDoc);
                        var p62= new MySql.Data.MySqlClient.MySqlParameter("@tarifa","");
                        var p63= new MySql.Data.MySqlClient.MySqlParameter("@tipo_remision",doc.aplicaCodTipoDoc);
                        var p64= new MySql.Data.MySqlClient.MySqlParameter("@documento_remision",doc.aplicaNumeroDoc);
                        var p65= new MySql.Data.MySqlClient.MySqlParameter("@auto_remision","");
                        var p66= new MySql.Data.MySqlClient.MySqlParameter("@documento_nombre",doc.nombreDoc);
                        var p67= new MySql.Data.MySqlClient.MySqlParameter("@subtotal_impuesto",doc.subTotalImpuesto);
                        var p68= new MySql.Data.MySqlClient.MySqlParameter("@subtotal",doc.subTotal);
                        var p69= new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp",autoEntCxP);
                        //
                        var p70= new MySql.Data.MySqlClient.MySqlParameter("@tipo_proveedor","");
                        var p71= new MySql.Data.MySqlClient.MySqlParameter("@planilla","");
                        var p72= new MySql.Data.MySqlClient.MySqlParameter("@expediente","");
                        var p75= new MySql.Data.MySqlClient.MySqlParameter("@neto",doc.montoNeto);
                        var p79= new MySql.Data.MySqlClient.MySqlParameter("@documento_tipo",doc.moduloDoc);
                        //
                        var p80= new MySql.Data.MySqlClient.MySqlParameter("@denominacion_fiscal","");
                        var p81= new MySql.Data.MySqlClient.MySqlParameter("@auto_concepto","");
                        var p82= new MySql.Data.MySqlClient.MySqlParameter("@fecha_retencion", doc.fechaRetencion);
                        var p83= new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable","0");
                        var p84= new MySql.Data.MySqlClient.MySqlParameter("@cierre_ftp","");
                        var p85= new MySql.Data.MySqlClient.MySqlParameter("@estatus_fiscal",doc.estatusFiscal);
                        var p86= new MySql.Data.MySqlClient.MySqlParameter("@id_compras_concepto",doc.idComprasConcepto);
                        var p87= new MySql.Data.MySqlClient.MySqlParameter("@desc_compras_concepto",doc.descComprasConcepto);
                        var p88= new MySql.Data.MySqlClient.MySqlParameter("@codigo_compras_concepto",doc.codigoComprasConcepto);
                        var p89= new MySql.Data.MySqlClient.MySqlParameter("@auto_sucursal", doc.autoSucursal);
                        //
                        var p90= new MySql.Data.MySqlClient.MySqlParameter("@desc_sucursal", doc.descSucursal);
                        var p91 = new MySql.Data.MySqlClient.MySqlParameter("@igtf_monto", doc.igtfMonto);
                        var p92 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento_compra", _tipoDocumentoCompra);
                        var p93 = new MySql.Data.MySqlClient.MySqlParameter("@sustraendo_ret_islr", doc.sustraendoRetISLR);
                        var p94 = new MySql.Data.MySqlClient.MySqlParameter("@monto_ret_islr", doc.montoRetISLR);
                        var p95 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", doc.autoSistemaDocumento);
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
                            p90, p91, p92, p93, p94, p95);
                        if (r2==0)
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
                                    fecha_ult_compra=@fechaEmision
                                where auto=@autoProv";
                        var _prv = ficha.documento.proveedor;
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoProv", _prv.autoProv);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoDebito", _prv.montoDebito);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@fechaEmision", _prv.fechaEmiDoc);
                        var r3 = cnn.Database.ExecuteSqlCommand(sql, p01, p02, p03);
                        if (r3 == 0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR DATA PROVEEDOR";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // INSERTAR CXP 
                        var sqlCxP = @"INSERT INTO cxp (
                                    auto,
                                    fecha,
                                    tipo_documento,
                                    documento,
                                    fecha_vencimiento,
                                    nota,
                                    importe,
                                    acumulado,
                                    auto_proveedor,
                                    proveedor,
                                    ci_rif,
                                    codigo_proveedor,
                                    estatus_cancelado,
                                    resta,
                                    estatus_anulado,
                                    auto_documento,
                                    numero,
                                    auto_agencia,
                                    agencia,
                                    signo,
                                    dias,
                                    auto_asiento,
                                    anexo,
                                    estatus_cierre_contable,
                                    importeDivisa,
                                    acumulado_divisa,
                                    resta_divisa,
                                    tasa_divisa,
                                    fecha_registro,
                                    auto_sistema_documento)
                            VALUES (
                                    @auto,
                                    @fecha,
                                    @tipo_documento,
                                    @documento,
                                    @fecha_vencimiento,
                                    @nota,
                                    @importe,
                                    @acumulado,
                                    @auto_proveedor,
                                    @proveedor,
                                    @ci_rif,
                                    @codigo_proveedor,
                                    @estatus_cancelado,
                                    @resta,
                                    @estatus_anulado,
                                    @auto_documento,
                                    @numero,
                                    @auto_agencia,
                                    @agencia,
                                    @signo,
                                    @dias,
                                    @auto_asiento,
                                    @anexo,
                                    @estatus_cierre_contable,
                                    @importeDivisa,
                                    @acumulado_divisa,
                                    @resta_divisa,
                                    @tasa_divisa,
                                    @fecha_registro,
                                    @auto_sistema_documento)";
                        //
                        var cxp = ficha.documento.cxp;
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoEntCxP);
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", cxp.fechaEmision);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", cxp.siglasTipoDocumento);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", cxp.documentoNro);
                        p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento", cxp.fechaVencimiento);
                        p05 = new MySql.Data.MySqlClient.MySqlParameter("@nota", cxp.notas);
                        p06 = new MySql.Data.MySqlClient.MySqlParameter("@importe", cxp.importe);
                        p07 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado", cxp.acumulado);
                        p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", cxp.autoProveedor);
                        p09 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor", cxp.nombreRazonSocialProveedor);
                        //
                        p10 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", cxp.ciRifProveedor);
                        p11 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", cxp.codigoProveedor);
                        p12 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cancelado", "0");
                        p13 = new MySql.Data.MySqlClient.MySqlParameter("@resta", cxp.resta);
                        p14 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_anulado", "0");
                        p15 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", autoEntCompra);
                        p16 = new MySql.Data.MySqlClient.MySqlParameter("@numero", "");
                        p17 = new MySql.Data.MySqlClient.MySqlParameter("@auto_agencia", "");
                        p18 = new MySql.Data.MySqlClient.MySqlParameter("@agencia", "");
                        p19 = new MySql.Data.MySqlClient.MySqlParameter("@signo", cxp.signoTipoDocumento);
                        //
                        p20 = new MySql.Data.MySqlClient.MySqlParameter("@dias", cxp.diasCredito);
                        p21 = new MySql.Data.MySqlClient.MySqlParameter("@auto_asiento", "");
                        p22 = new MySql.Data.MySqlClient.MySqlParameter("@anexo", "");
                        p23 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable", "0");
                        p24 = new MySql.Data.MySqlClient.MySqlParameter("@importeDivisa", cxp.importeDivisa);
                        p25 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado_divisa", cxp.acumuladoDivisa);
                        p26 = new MySql.Data.MySqlClient.MySqlParameter("@resta_divisa", cxp.restaDivisa);
                        p27 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_divisa", cxp.tasaDivisa);
                        p28 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema);
                        p29 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", cxp.autoSistemaDoc);
                        //
                        var r4 = cnn.Database.ExecuteSqlCommand(sqlCxP,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                            p20, p21, p22, p23, p24, p25, p26, p27, p28, p29);
                        if (r4 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR CXP";
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
                                if (rgDocRet.EsIva)
                                {
                                    sql = @"update sistema_contadores set 
                                            a_compras_retenciones=a_compras_retenciones+1, 
                                            a_compras_retencion_iva=a_compras_retencion_iva+1";
                                }
                                else 
                                {
                                    sql = @"update sistema_contadores set 
                                            a_compras_retenciones=a_compras_retenciones+1, 
                                            a_compras_retencion_islr=a_compras_retencion_islr+1";
                                }
                                var xr1 = cnn.Database.ExecuteSqlCommand(sql);
                                var aCompraRet = cnn.Database.SqlQuery<int>("select a_compras_retenciones from sistema_contadores").FirstOrDefault();
                                var autoCompraRet = aCompraRet.ToString().Trim().PadLeft(10, '0');
                                //
                                var numDocCompraRet = "";
                                if (rgDocRet.EsIva)
                                {
                                    var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_iva from sistema_contadores").FirstOrDefault();
                                    var numCompraRet = n.ToString().Trim().PadLeft(8, '0');
                                    numDocCompraRet = anoRelacion + mesRelacion + numCompraRet;
                                }
                                else 
                                {
                                    var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_islr from sistema_contadores").FirstOrDefault();
                                    numDocCompraRet = n.ToString().Trim().PadLeft(10, '0');
                                }
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
                                var _docRet= rgDocRet;
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
                                    result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION IVA ]";
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
                                        result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION IVA DETALLE ]";
                                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return result;
                                    }
                                    cnn.SaveChanges();
                                }
                                //
                                // INSERTAR CXP POR RETENCION 
                                sql = "update sistema_contadores set a_cxp=a_cxp+1";
                                var xr2 = cnn.Database.ExecuteSqlCommand(sql);
                                var aRet = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
                                var _autoRetencion = aRet.ToString().Trim().PadLeft(10, '0');
                                //
                                var cxpRet = _docRet.cxpRetencion;
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", _autoRetencion);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", cxpRet.fechaEmision);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", cxpRet.siglasTipoDocumento);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", cxpRet.documentoNro);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento", cxpRet.fechaVencimiento);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@nota", cxpRet.notas);
                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@importe", cxpRet.importe);
                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado", cxpRet.acumulado);
                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", cxpRet.autoProveedor);
                                p09 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor", cxpRet.nombreRazonSocialProveedor);
                                //
                                p10 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", cxpRet.ciRifProveedor);
                                p11 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", cxpRet.codigoProveedor);
                                p12 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cancelado", "0");
                                p13 = new MySql.Data.MySqlClient.MySqlParameter("@resta", cxpRet.resta);
                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_anulado", "0");
                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", autoEntCompra);
                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@numero", "");
                                p17 = new MySql.Data.MySqlClient.MySqlParameter("@auto_agencia", "");
                                p18 = new MySql.Data.MySqlClient.MySqlParameter("@agencia", "");
                                p19 = new MySql.Data.MySqlClient.MySqlParameter("@signo", cxpRet.signoTipoDocumento);
                                //
                                p20 = new MySql.Data.MySqlClient.MySqlParameter("@dias", cxpRet.diasCredito);
                                p21 = new MySql.Data.MySqlClient.MySqlParameter("@auto_asiento", "");
                                p22 = new MySql.Data.MySqlClient.MySqlParameter("@anexo", "");
                                p23 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable", "0");
                                p24 = new MySql.Data.MySqlClient.MySqlParameter("@importeDivisa", cxpRet.importeDivisa);
                                p25 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado_divisa", cxpRet.acumuladoDivisa);
                                p26 = new MySql.Data.MySqlClient.MySqlParameter("@resta_divisa", cxpRet.restaDivisa);
                                p27 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_divisa", cxpRet.tasaDivisa);
                                p28 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema);
                                p29 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", cxpRet.autoSistemaDoc);
                                //
                                var rf4 = cnn.Database.ExecuteSqlCommand(sqlCxP,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                    p20, p21, p22, p23, p24, p25, p26, p27, p28, p29);
                                if (rf4 == 0)
                                {
                                    result.Mensaje = "ERROR AL INSERTAR DOCUMENTO CXP RETENCION";
                                    result.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return result;
                                }
                                cnn.SaveChanges();
                                //
                                // INSERTAR RECIBO POR RETENCION
                                sql = "update sistema_contadores set a_cxp_recibo=a_cxp_recibo+1";
                                var xr3 = cnn.Database.ExecuteSqlCommand(sql);
                                var aRec = cnn.Database.SqlQuery<int>("select a_cxp_recibo from sistema_contadores").FirstOrDefault();
                                var _autoRecibo = aRec.ToString().Trim().PadLeft(10, '0');
                                //
                                sql = @"INSERT INTO cxp_recibos (
                                    auto, 
                                    documento, 
                                    fecha,  
                                    auto_usuario, 
                                    importe,    
                                    usuario, 
                                    monto_recibido, 
                                    auto_proveedor, 
                                    proveedor, 
                                    ci_rif, 
                                    codigo, 
                                    estatus_anulado,
                                    direccion,  
                                    telefono, 
                                    anticipos, 
                                    cambio, 
                                    nota, 
                                    auto_cxp, 
                                    importe_divisa, 
                                    monto_recibido_divisa, 
                                    cambio_divisa, 
                                    tasa_cambio,
                                    auto_sistema_documento) 
                                VALUES (
                                    @auto, 
                                    @documento, 
                                    @fecha,  
                                    @auto_usuario, 
                                    @importe,    
                                    @usuario, 
                                    @monto_recibido, 
                                    @auto_proveedor, 
                                    @proveedor, 
                                    @ci_rif, 
                                    @codigo, 
                                    '0',
                                    @direccion,  
                                    @telefono, 
                                    0, 
                                    0, 
                                    @nota, 
                                    @auto_cxp, 
                                    @importe_divisa, 
                                    @monto_recibido_divisa, 
                                    0, 
                                    @tasa_cambio,
                                    @auto_sistema_documento)";
                                var recibo = _docRet.cxpReciboRetencion;
                                var _numeroRecibo = recibo.documento;
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", _autoRecibo);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", _numeroRecibo);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@auto_usuario", recibo.usuarioAuto);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@importe", recibo.importe);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@usuario", recibo.usuarioNombre);
                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@monto_recibido", recibo.montoRecibido);
                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", recibo.prvAuto);
                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor", recibo.prvNombre);
                                p09 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", recibo.prvCiRif);
                                //
                                p10 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", recibo.prvCodigo);
                                p11 = new MySql.Data.MySqlClient.MySqlParameter("@direccion", recibo.prvDirFiscal);
                                p12 = new MySql.Data.MySqlClient.MySqlParameter("@telefono", recibo.prvTlf);
                                p13 = new MySql.Data.MySqlClient.MySqlParameter("@nota", recibo.nota);
                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", autoEntCxP);
                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@importe_divisa", recibo.importeDivisa);
                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@monto_recibido_divisa", recibo.montoRecibidoDivisa);
                                p17 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_cambio", recibo.tasaCambio);
                                p18 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", recibo.autoSistemaDoc);
                                var r7 = cnn.Database.ExecuteSqlCommand(sql,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16, p17, p18);
                                if (r7 == 0)
                                {
                                    result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ RECIBO POR RETENCION ]";
                                    result.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return result;
                                }
                                cnn.SaveChanges();
                                //
                                // DOCUMENTOS QUE INVOLUCRAN EL RECIBO
                                sql = @"INSERT INTO cxp_documentos (
                                id, 
                                fecha, 
                                tipo_documento, 
                                documento, 
                                importe, 
                                operacion, 
                                auto_cxp, 
                                auto_cxp_pago, 
                                auto_cxp_recibo, 
                                numero_recibo
                                ) 
                            VALUES (
                                @id, 
                                @fecha, 
                                @tipo_documento, 
                                @documento, 
                                @importe, 
                                @operacion, 
                                @auto_cxp, 
                                @auto_cxp_pago, 
                                @auto_cxp_recibo, 
                                @numero_recibo
                                )";
                                var _id = 0;
                                foreach (var rg in recibo.docRecibo)
                                {
                                    _id += 1;
                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@id", _id);
                                    p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                    p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", rg.siglasDocumentoAfecta);
                                    p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", rg.numDocumentoAfecta);
                                    p04 = new MySql.Data.MySqlClient.MySqlParameter("@importe", rg.importe);
                                    p05 = new MySql.Data.MySqlClient.MySqlParameter("@operacion", rg.tipoOperacionRealizar);
                                    p06 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", autoEntCxP);
                                    p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_pago", _autoRetencion);
                                    p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_recibo", _autoRecibo);
                                    p09 = new MySql.Data.MySqlClient.MySqlParameter("@numero_recibo", _numeroRecibo);
                                    var r9 = cnn.Database.ExecuteSqlCommand(sql,
                                        p00, p01, p02, p03, p04, p05, p06, p07, p08, p09);
                                    if (r9 == 0)
                                    {
                                        result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ RECIBO DOCUMENTO POR RETENCION ]";
                                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return result;
                                    }
                                    cnn.SaveChanges();
                                }
                            }
                        }
                        //
                        ts.Commit();
                        result.Entidad  = new DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado()
                        {
                             autoDocCompra= autoEntCompra,
                             autoDocCxp=autoEntCxP,
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
        public DtoLib.Resultado 
            Transporte_Documento_Agregar_CompraGrasto_Verificar(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    if (ficha.documento == null) 
                    {
                        throw new Exception("DATOS DEL DOCUMENTO NO PUEDE ESTAR VACIO");
                    }
                    if (ficha.documento.montoTotal <= 0m) 
                    {
                        throw new Exception("MONTO DOCUMENTO COMPRA A REGISTRAR NO PUEDE SER CERO (0)");
                    }
                    if (ficha.documento.cxp == null)
                    {
                        throw new Exception("DATOS DEL DOCUMENTO [ CXP ] NO PUEDE ESTAR VACIO");
                    }
                    if (ficha.documento.cxp.importe <= 0m)
                    {
                        throw new Exception("MONTO DOCUMENTO CXP A REGISTRAR NO PUEDE SER CERO (0)");
                    }
                    if (ficha.documento.proveedor == null)
                    {
                        throw new Exception("DATOS DEL DOCUMENTO [ PROVEEDOR ] NO PUEDE ESTAR VACIO");
                    }
                    if (ficha.documento.proveedor.montoDebito == 0m)
                    {
                        throw new Exception("MONTO PROVEEDOR ACTUALIZAR NO PUEDE SER CERO (0)");
                    }
                    if (ficha.documento.docRet != null)
                    {
                        foreach (var rg in ficha.documento.docRet)
                        {
                            if (rg.MontoTotal <= 0m) 
                            {
                                throw new Exception("MONTO DEL DOCUMENTO [ RETENCION ] NO PUEDE SER CERO (0)");
                            }
                            if (rg.docRetDetalle ==null)
                            {
                                throw new Exception("DETALLE DEL DOCUMENTO RETENCION NO PUEDE ESTAR VACIO");
                            }
                            if (rg.cxpRetencion ==null)
                            {
                                throw new Exception("CXP RETENCION NO PUEDE ESTAR VACIO");
                            }
                            if (rg.cxpReciboRetencion ==null)
                            {
                                throw new Exception("CXP RECIBO RETENCION NO PUEDE ESTAR VACIO");
                            }
                            if (rg.cxpReciboRetencion.docRecibo ==null)
                            {
                                throw new Exception("CXP RECIBO DOCUMENTOS INVOLUCRADO EN RETENCION NO PUEDE ESTAR VACIO");
                            }
                            if (rg.cxpReciboRetencion.docRecibo.Count()==0)
                            {
                                throw new Exception("CXP RECIBO DOCUMENTOS INVOLUCRADO EN RETENCION NO PUEDE ESTAR VACIO");
                            }
                        }
                    }
                    var sql = @"select count(*) as cnt from compras 
                                where documento=@documento and 
                                    auto_proveedor=@autoPrv and 
                                    tipo=@tipoDoc and
                                    estatus_anulado='0'";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@documento", ficha.documento.numeroDoc);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("@autoPrv", ficha.documento.autoProv);
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter("@tipoDoc", ficha.documento.codTipoDoc);
                    var r1 = cnn.Database.SqlQuery<int?>(sql, p1, p2, p3).FirstOrDefault();
                    if (r1.HasValue) 
                    {
                        if (r1.Value >= 1)
                        {
                            throw new Exception("DOCUMENTO YA FUE REGISTRADO");
                        }
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