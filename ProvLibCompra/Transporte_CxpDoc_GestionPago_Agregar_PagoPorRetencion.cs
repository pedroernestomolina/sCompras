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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado>
            Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Ficha ficha)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado>();
            //
            try
            {
                if (ficha.Documentos != null)
                {
                    var _sql = "";
                    var _msg = "";
                    using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                    {
                        using (var ts = cnn.Database.BeginTransaction())
                        {
                            var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                            var mesRelacion = fechaSistema.Month.ToString().Trim().PadLeft(2, '0');
                            var anoRelacion = fechaSistema.Year.ToString().Trim().PadLeft(4, '0');
                            var idRetIva = "";
                            var idRetIslr = "";
                            //
                            foreach (var rgDocRet in ficha.Documentos)
                            {
                                if (rgDocRet.EsIva)
                                {
                                    _sql = @"update sistema_contadores set 
                                                a_compras_retenciones=a_compras_retenciones+1, 
                                                a_compras_retencion_iva=a_compras_retencion_iva+1";
                                }
                                else
                                {
                                    _sql = @"update sistema_contadores set 
                                                a_compras_retenciones=a_compras_retenciones+1, 
                                                a_compras_retencion_islr=a_compras_retencion_islr+1";
                                }
                                var xr1 = cnn.Database.ExecuteSqlCommand(_sql);
                                var aCompraRet = cnn.Database.SqlQuery<int>("select a_compras_retenciones from sistema_contadores").FirstOrDefault();
                                var autoCompraRet = aCompraRet.ToString().Trim().PadLeft(10, '0');
                                //
                                var numDocCompraRet = "";
                                var _tasaRetencionIva = 0m;
                                var _montoRetencionIva = 0m;
                                if (rgDocRet.EsIva)
                                {
                                    var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_iva from sistema_contadores").FirstOrDefault();
                                    var numCompraRet = n.ToString().Trim().PadLeft(8, '0');
                                    numDocCompraRet = anoRelacion + mesRelacion + numCompraRet;
                                    idRetIva = autoCompraRet;
                                    _tasaRetencionIva= rgDocRet.TasaRetencion;
                                    _montoRetencionIva = rgDocRet.MontoRetencion;
                                }
                                else
                                {
                                    var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_islr from sistema_contadores").FirstOrDefault();
                                    numDocCompraRet = n.ToString().Trim().PadLeft(10, '0');
                                    idRetIslr = autoCompraRet;
                                }
                                _sql = @"INSERT INTO compras_retenciones (
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
                                            retencion_sustraendo
                                        )
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
                                            @retencion_sustraendo
                                        )";
                                var _docRet = rgDocRet;
                                var p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoCompraRet);
                                var p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", numDocCompraRet);
                                var p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                var p03 = new MySql.Data.MySqlClient.MySqlParameter("@razon_social", _docRet.PrvNombre);
                                var p04 = new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal", _docRet.PrvDirFiscal);
                                var p05 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", _docRet.PrvCiRif);
                                var p06 = new MySql.Data.MySqlClient.MySqlParameter("@tipo", _docRet.SistDocCodigo);
                                var p07 = new MySql.Data.MySqlClient.MySqlParameter("@exento", _docRet.MontoExento);
                                var p08 = new MySql.Data.MySqlClient.MySqlParameter("@base", _docRet.MontoBase1);
                                var p09 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto", _docRet.MontoImpuesto1);
                                //
                                var p10 = new MySql.Data.MySqlClient.MySqlParameter("@total", _docRet.MontoTotal);
                                var p11 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion", _docRet.TasaRetencion);
                                var p12 = new MySql.Data.MySqlClient.MySqlParameter("@retencion", _docRet.MontoRetencion);
                                var p13 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", _docRet.PrvAuto);
                                var p14 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_relacion", fechaSistema.Date);
                                var p15 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", _docRet.PrvCodigo);
                                var p16 = new MySql.Data.MySqlClient.MySqlParameter("@ano_relacion", anoRelacion);
                                var p17 = new MySql.Data.MySqlClient.MySqlParameter("@mes_relacion", mesRelacion);
                                var p18 = new MySql.Data.MySqlClient.MySqlParameter("@documento_nombre", _docRet.SistDocNombre);
                                var p19 = new MySql.Data.MySqlClient.MySqlParameter("@base2", _docRet.MontoBase2);
                                //
                                var p20 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto2", _docRet.MontoImpuesto2);
                                var p21 = new MySql.Data.MySqlClient.MySqlParameter("@base3", _docRet.MontoBase3);
                                var p22 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto3", _docRet.MontoImpuesto3);
                                var p23 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", _docRet.SistDocAuto);
                                var p24 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_monto", _docRet.retMonto);
                                var p25 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_sustraendo", _docRet.retSustraendo);
                                var p26 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p27 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p28 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p29 = new MySql.Data.MySqlClient.MySqlParameter();
                                //
                                var p30 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p31 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p32 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p33 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p34 = new MySql.Data.MySqlClient.MySqlParameter();
                                var p35 = new MySql.Data.MySqlClient.MySqlParameter();
                                //
                                var rf1 = cnn.Database.ExecuteSqlCommand(_sql,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                    p20, p21, p22, p23, p24, p25);
                                if (rf1 == 0)
                                {
                                    _msg = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION IVA ]";
                                    throw new Exception(_msg);
                                }
                                cnn.SaveChanges();
                                //
                                //ACTUALIZAR DOCUMENTO DE COMPRA - COMPROBANTE DE RETENCION
                                if (rgDocRet.EsIva)
                                {
                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoCompra", ficha.autoEntCompra);
                                    p01 = new MySql.Data.MySqlClient.MySqlParameter("@numComprobRetencion", numDocCompraRet);
                                    p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                    p03 = new MySql.Data.MySqlClient.MySqlParameter("@tasaRetencionIva", _tasaRetencionIva);
                                    p04 = new MySql.Data.MySqlClient.MySqlParameter("@montoRetencionIva", _montoRetencionIva);
                                    _sql = @"update compras set 
                                                tasa_retencion_iva=@tasaRetencionIva,
                                                retencion_iva=@montoRetencionIva,
                                                comprobante_retencion=@numComprobRetencion,
                                                fecha_retencion=@fecha
                                            where auto=@autoCompra";
                                    var rt1 = cnn.Database.ExecuteSqlCommand(_sql,
                                        p00, p01, p02);
                                    if (rt1 == 0)
                                    {
                                        _msg = "ERROR AL ACTUALIZAR DOCUMENTO [ COMPRAS - COMPROBANTE RETENCION ]";
                                        throw new Exception(_msg);
                                    }
                                    cnn.SaveChanges();
                                }
                                //
                                // INSERTAR COMPRA RETENCION DETALLE 
                                _sql = @"INSERT INTO compras_retenciones_detalle (
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
                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", ficha.autoEntCompra);
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
                                    var rf2 = cnn.Database.ExecuteSqlCommand(_sql,
                                        p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                        p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                        p20, p21, p22, p23, p24, p25, p26, p27, p28, p29,
                                        p30, p31);
                                    if (rf2 == 0)
                                    {
                                        _msg = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION IVA DETALLE ]";
                                        throw new Exception(_msg);
                                    }
                                    cnn.SaveChanges();
                                }
                                //
                                // ACTUALIZAR SALDO DOCUMENTO CXP 
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado", _docRet.cxpRetencion.acumulado);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@resta", _docRet.cxpRetencion.acumulado);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@acumuladoDivisa", _docRet.cxpRetencion.acumuladoDivisa);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@restaDivisa", _docRet.cxpRetencion.acumuladoDivisa);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@idCxP", ficha.autoEntCxP);
                                _sql = @"update cxp set 
                                            acumulado=acumulado+@acumulado,
                                            resta=resta-@resta,
                                            acumulado_divisa=acumulado_divisa+@acumuladoDivisa,
                                            resta_divisa=resta_divisa-@resta_divisa
                                        where auto=@idCxP";
                                var rtAct = cnn.Database.ExecuteSqlCommand(_sql, p01, p02, p03, p04, p05);
                                if (rtAct == 0) 
                                {
                                    _msg = "ERROR AL ACTUALIZAR SALDO CXP";
                                    throw new Exception(_msg);
                                }
                                cnn.SaveChanges();
                                //
                                // INSERTAR CXP POR RETENCION 
                                _sql = "update sistema_contadores set a_cxp=a_cxp+1";
                                var xr2 = cnn.Database.ExecuteSqlCommand(_sql);
                                var aRet = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
                                var _autoRetencion = aRet.ToString().Trim().PadLeft(10, '0');
                                //
                                var _sqlCxP = @"INSERT INTO cxp (
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
                                    auto_sistema_documento
                                )
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
                                    @auto_sistema_documento
                                )";
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
                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", ficha.autoEntCompra);
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
                                var rf4 = cnn.Database.ExecuteSqlCommand(_sqlCxP,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                    p20, p21, p22, p23, p24, p25, p26, p27, p28, p29);
                                if (rf4 == 0)
                                {
                                    _msg = "ERROR AL INSERTAR DOCUMENTO CXP RETENCION";
                                    throw new Exception(_msg);
                                }
                                cnn.SaveChanges();
                                //
                                // INSERTAR RECIBO POR RETENCION
                                _sql = "update sistema_contadores set a_cxp_recibo=a_cxp_recibo+1";
                                var xr3 = cnn.Database.ExecuteSqlCommand(_sql);
                                var aRec = cnn.Database.SqlQuery<int>("select a_cxp_recibo from sistema_contadores").FirstOrDefault();
                                var _autoRecibo = aRec.ToString().Trim().PadLeft(10, '0');
                                //
                                _sql = @"INSERT INTO cxp_recibos (
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
                                    auto_sistema_documento
                                ) 
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
                                    @auto_sistema_documento
                                )";
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
                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", ficha.autoEntCxP);
                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@importe_divisa", recibo.importeDivisa);
                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@monto_recibido_divisa", recibo.montoRecibidoDivisa);
                                p17 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_cambio", recibo.tasaCambio);
                                p18 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", recibo.autoSistemaDoc);
                                var r7 = cnn.Database.ExecuteSqlCommand(_sql,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16, p17, p18);
                                if (r7 == 0)
                                {
                                    _msg = "ERROR AL INSERTAR DOCUMENTO [ RECIBO POR RETENCION ]";
                                    throw new Exception(_msg);
                                }
                                cnn.SaveChanges();
                                //
                                // DOCUMENTOS QUE INVOLUCRAN EL RECIBO
                                _sql = @"INSERT INTO cxp_documentos (
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
                                    p06 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", ficha.autoEntCxP);
                                    p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_pago", _autoRetencion);
                                    p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_recibo", _autoRecibo);
                                    p09 = new MySql.Data.MySqlClient.MySqlParameter("@numero_recibo", _numeroRecibo);
                                    var r9 = cnn.Database.ExecuteSqlCommand(_sql,
                                        p00, p01, p02, p03, p04, p05, p06, p07, p08, p09);
                                    if (r9 == 0)
                                    {
                                        _msg = "ERROR AL INSERTAR DOCUMENTO [ RECIBO DOCUMENTO POR RETENCION ]";
                                        throw new Exception(_msg);
                                    }
                                    cnn.SaveChanges();
                                }
                            }
                            ts.Commit();
                            rt.Entidad = new DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado()
                            {
                                autoRetIva = idRetIva,
                                autoRetISLR = idRetIslr,
                            };
                        }
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