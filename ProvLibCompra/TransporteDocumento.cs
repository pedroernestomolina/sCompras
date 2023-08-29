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
                                codigo_compras_concepto
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
                                @descuento1, 
                                @descuento2, 
                                @cargos, 
                                @descuento1p, 
                                @descuento2p, 
                                @cargosp, 
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
                                @renglones, 
                                @saldo_pendiente, 
                                @ano_relacion, 
                                @comprobante_retencion_islr, 
                                @dias_validez,
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
                                @anticipo_iva, 
                                @terceros_iva, 
                                @neto, 
                                @costo, 
                                @utilidad, 
                                @utilidadp, 
                                @documento_tipo, 
                                @denominacion_fiscal, 
                                @auto_concepto, 
                                @fecha_retencion, 
                                @estatus_cierre_contable, 
                                @cierre_ftp, 
                                @estatus_fiscal,    
                                @id_compras_concepto,
                                @desc_compras_concepto,
                                @codigo_compras_concepto
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
                        var p25= new MySql.Data.MySqlClient.MySqlParameter("@retencion_islr",doc.montoRetencionISLR);
                        var p26= new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor",doc.autoProv);
                        var p27= new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor",doc.codigoProv);
                        var p28= new MySql.Data.MySqlClient.MySqlParameter("@mes_relacion", mesRelacion);
                        var p29= new MySql.Data.MySqlClient.MySqlParameter("@control",doc.numeroControlDoc);
                        //
                        var p30= new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro",fechaSistema.Date);
                        var p31= new MySql.Data.MySqlClient.MySqlParameter("@orden_compra","");
                        var p32= new MySql.Data.MySqlClient.MySqlParameter("@dias",doc.diasCreditoDoc);
                        var p33= new MySql.Data.MySqlClient.MySqlParameter("@descuento1",0m);
                        var p34= new MySql.Data.MySqlClient.MySqlParameter("@descuento2",0m);
                        var p35= new MySql.Data.MySqlClient.MySqlParameter("@cargos",0m);
                        var p36= new MySql.Data.MySqlClient.MySqlParameter("@descuento1p",0m);
                        var p37= new MySql.Data.MySqlClient.MySqlParameter("@descuento2p",0m);
                        var p38= new MySql.Data.MySqlClient.MySqlParameter("@cargosp",0m);
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
                        var p53= new MySql.Data.MySqlClient.MySqlParameter("@renglones",0);
                        var p54= new MySql.Data.MySqlClient.MySqlParameter("@saldo_pendiente",doc.saldoPendiente);
                        var p55= new MySql.Data.MySqlClient.MySqlParameter("@ano_relacion",anoRelacion);
                        var p56= new MySql.Data.MySqlClient.MySqlParameter("@comprobante_retencion_islr",doc.comprobanteRetencionISLR);
                        var p57= new MySql.Data.MySqlClient.MySqlParameter("@dias_validez",0);
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
                        var p73= new MySql.Data.MySqlClient.MySqlParameter("@anticipo_iva",0m);
                        var p74= new MySql.Data.MySqlClient.MySqlParameter("@terceros_iva",0m);
                        var p75= new MySql.Data.MySqlClient.MySqlParameter("@neto",doc.montoNeto);
                        var p76= new MySql.Data.MySqlClient.MySqlParameter("@costo",0m);
                        var p77= new MySql.Data.MySqlClient.MySqlParameter("@utilidad",0m);
                        var p78= new MySql.Data.MySqlClient.MySqlParameter("@utilidadp",0m);
                        var p79= new MySql.Data.MySqlClient.MySqlParameter("@documento_tipo",doc.moduloDoc);
                        //
                        var p80= new MySql.Data.MySqlClient.MySqlParameter("@denominacion_fiscal","");
                        var p81= new MySql.Data.MySqlClient.MySqlParameter("@auto_concepto","");
                        var p82 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_retencion", doc.fechaRetencion);
                        var p83= new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable","0");
                        var p84= new MySql.Data.MySqlClient.MySqlParameter("@cierre_ftp","");
                        var p85= new MySql.Data.MySqlClient.MySqlParameter("@estatus_fiscal",doc.estatusFiscal);
                        var p86= new MySql.Data.MySqlClient.MySqlParameter("@id_compras_concepto",doc.idComprasConcepto);
                        var p87= new MySql.Data.MySqlClient.MySqlParameter("@desc_compras_concepto",doc.descComprasConcepto);
                        var p88= new MySql.Data.MySqlClient.MySqlParameter("@codigo_compras_concepto",doc.codigoComprasConcepto);
                        //
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, 
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                            p20, p21, p22, p23, p24, p25, p26, p27, p28, p29,
                            p30, p31, p32, p33, p34, p35, p36, p37, p38, p39,
                            p40, p41, p42, p43, p44, p45, p46, p47, p48, p49,
                            p50, p51, p52, p53, p54, p55, p56, p57, p58, p59,
                            p60, p61, p62, p63, p64, p65, p66, p67, p68, p69,
                            p70, p71, p72, p73, p74, p75, p76, p77, p78, p79,
                            p80, p81, p82, p83, p84, p85);
                        if (r2==0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR DOCUMENTO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        p01= new MySql.Data.MySqlClient.MySqlParameter("@autoProv",ficha.proveedor.autoProv);
                        p02= new MySql.Data.MySqlClient.MySqlParameter("@montoDebito",ficha.proveedor.montoDebito);
                        p03= new MySql.Data.MySqlClient.MySqlParameter("@fechaEmision", ficha.proveedor.fechaEmiDoc);
                        sql = @"update proveedor set
                                    debitos=debitos+@montoDebito,
                                    fecha_ult_compra=@fechaEmision
                                where auto=@autoProv";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r3==0)
                        {
                            result.Mensaje = "ERROR AL ACTUALIZAR DATA PROVEEDOR";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        sql =@"INSERT INTO cxp (
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
                                    fecha_registro)
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
                                    @fecha_registro)";
                        //
                        var cxp = ficha.cxp;
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto",autoEntCxP);
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha",cxp.fechaEmision );
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento",cxp.tipoDocumento);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", cxp.documentoNro);
                        p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento", cxp.fechaVencimiento);
                        p05 = new MySql.Data.MySqlClient.MySqlParameter("@nota", cxp.nota);
                        p06 = new MySql.Data.MySqlClient.MySqlParameter("@importe",cxp.importe);
                        p07 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado",cxp.acumulado );
                        p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor",cxp.autoProveedor);
                        p09 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor",cxp.nombreRazonSocialProveedor);
                        //
                        p10 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif",cxp.ciRifProveedor);
                        p11 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor",cxp.codigoProveedor);
                        p12 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cancelado","0");
                        p13 = new MySql.Data.MySqlClient.MySqlParameter("@resta",cxp.resta);
                        p14 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_anulado","0");
                        p15 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento",autoEntCompra);
                        p16 = new MySql.Data.MySqlClient.MySqlParameter("@numero","");
                        p17 = new MySql.Data.MySqlClient.MySqlParameter("@auto_agencia","0000000001");
                        p18 = new MySql.Data.MySqlClient.MySqlParameter("@agencia","");
                        p19 = new MySql.Data.MySqlClient.MySqlParameter("@signo",cxp.signoDocumento);
                        //
                        p20 = new MySql.Data.MySqlClient.MySqlParameter("@dias",cxp.diasCredito);
                        p21 = new MySql.Data.MySqlClient.MySqlParameter("@auto_asiento","");
                        p22 = new MySql.Data.MySqlClient.MySqlParameter("@anexo","");
                        p23 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable","0");
                        p24 = new MySql.Data.MySqlClient.MySqlParameter("@importeDivisa",cxp.importeDivisa);
                        p25 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado_divisa",cxp.acumuladoDivisa);
                        p26 = new MySql.Data.MySqlClient.MySqlParameter("@resta_divisa",cxp.restaDivisa);
                        p27 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_divisa",cxp.tasaDivisa);
                        p28 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro",fechaSistema);
                        //
                        var r4 = cnn.Database.ExecuteSqlCommand(sql, 
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                            p20, p21, p22, p23, p24, p25, p26, p27, p28, p28);
                        if (r4==0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR CXP";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
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
    }
}