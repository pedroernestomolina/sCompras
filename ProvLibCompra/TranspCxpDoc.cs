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
        public DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha> 
            Transporte_CxpDoc_GetLista_DocPend()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"SELECT 
                                    auto as id,
                                    fecha as fechaEmision,
                                    dias as diasCredito,
                                    tipo_documento as tipoDoc,
                                    documento as docNro,
                                    signo as signoDoc,
                                    fecha_vencimiento as fechaVence,
                                    ci_rif as ciRif,
                                    proveedor as nombreRazonSocial,
                                    importeDivisa as importeDiv,
                                    acumulado_divisa as acumuladoDiv,
                                    resta_divisa as restaDiv,
                                    tasa_divisa as tasaFactor
                                FROM cxp
                                where estatus_anulado='0' and 
                                        tipo_documento in ('FAC','NDB','NCR') and
                                        resta_divisa>0";
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.CxpDoc.DocPend.Ficha>(_sql).ToList();
                    result.Lista = _lst;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.DocEntidad.Ficha> 
            Transporte_CxpDoc_GetDocPend_ById(string idCxP)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.DocEntidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"SELECT 
                                    cxp.auto as id,
                                    cxp.fecha as fechaEmision,
                                    cxp.dias as diasCredito,
                                    cxp.tipo_documento as tipoDoc,
                                    cxp.documento as docNro,
                                    cxp.signo as signoDoc,
                                    cxp.fecha_vencimiento as fechaVence,
                                    cxp.ci_rif as ciRif,
                                    cxp.proveedor as nombreRazonSocial,
                                    cxp.importeDivisa as importeDiv,
                                    cxp.acumulado_divisa as acumuladoDiv,
                                    cxp.resta_divisa as restaDiv,
                                    cxp.tasa_divisa as tasaFactor,
                                    cxp.auto_proveedor as autoProv,
                                    cxp.codigo_proveedor as codProv,
                                    cxp.fecha_registro as fechaReg,
                                    c.tipo as codTipoDoc,
                                    c.nota as descripcionDoc,
                                    c.mes_relacion as mesRelacion,
                                    c.ano_relacion as anoRelacion,
                                    c.control as docNroControl,
                                    c.desc_compras_concepto as conceptoDesc,
                                    c.codigo_compras_concepto as conceptoCod,
                                    c.condicion_pago as condicion,
                                    c.dir_fiscal as dirFiscalPrv,
                                    c.telefono as telefonoPrv
                                FROM cxp as cxp
                                join compras as c on c.auto=cxp.auto_documento
                                where cxp.auto=@idCxp";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idCxp", idCxP);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.CxpDoc.DocEntidad.Ficha>(_sql, p1).FirstOrDefault();
                    if (_ent == null) 
                    {
                        throw new Exception("DOCUMENTO POR PAGAR NO ENCONTRADO");
                    }
                    result.Entidad = _ent;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
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
            Transporte_CxpDoc_GestionPago_Agregar(DtoLibTransporte.CxpDoc.Pago.Agregar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
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
                        //
                        var sql = @"update sistema_contadores set 
                                        a_cxp=a_cxp+1, 
                                        a_cxp_recibo=a_cxp_recibo+1,
                                        a_cxp_recibo_numero=a_cxp_recibo_numero+1";
                        var xr1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (xr1 == 0)
                        {
                            throw new Exception("PROBLEMA AL ACTUALIZAR TABLA [ CONTADORES ]");
                        }
                        //
                        //RESCATO CONTADORES
                        var aPag = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
                        var _autoPago = aPag.ToString().Trim().PadLeft(10, '0');
                        var aRec = cnn.Database.SqlQuery<int>("select a_cxp_recibo from sistema_contadores").FirstOrDefault();
                        var _autoRecibo = aRec.ToString().Trim().PadLeft(10, '0');
                        var _nRec = cnn.Database.SqlQuery<int>("select a_cxp_recibo_numero from sistema_contadores").FirstOrDefault();
                        var _numRecibo = _nRec.ToString().Trim().PadLeft(10, '0');
                        //
                        // INSERTAR PAGO EN TABLA CXP
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
                                    0,
                                    @auto_proveedor,
                                    @proveedor,
                                    @ci_rif,
                                    @codigo_proveedor,
                                    '0',
                                    0,
                                    '0',
                                    @auto_documento,
                                    '',
                                    '',
                                    '',
                                    -1,
                                    0,
                                    '',
                                    '',
                                    '0',
                                    @importeDivisa,
                                    0,
                                    0,
                                    @tasa_divisa,
                                    @fecha_registro,
                                    '')";
                        var p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", _autoPago);
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", ficha.Recibo.codSistemaDoc);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", _numRecibo);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento", fechaSistema.Date);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@nota", ficha.Recibo.nota);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@importe", ficha.Recibo.importeDivisa);
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", ficha.Recibo.prvAuto);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor", ficha.Recibo.prvNombre);
                        var p09 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", ficha.Recibo.prvCiRif);
                        //
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", ficha.Recibo.prvCodigo);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", _autoRecibo);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@importeDivisa", ficha.Recibo.importeDivisa);
                        var p13 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_divisa", ficha.Recibo.tasaCambio);
                        var p14 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                        //
                        var xr2 = cnn.Database.ExecuteSqlCommand(sqlCxP,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14);
                        if (xr2 == 0)
                        {
                            throw new Exception("PROBLEMA AL INSERTAR EN TABLA CXP [ PAGO ]");
                        }
                        cnn.SaveChanges();
                        //
                        // INSERTAR RECIBO
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
                        var recibo = ficha.Recibo;
                        p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", _autoRecibo);
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", _numRecibo);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                        p03 = new MySql.Data.MySqlClient.MySqlParameter("@auto_usuario", recibo.usuarioAuto);
                        p04 = new MySql.Data.MySqlClient.MySqlParameter("@importe", recibo.importeMonAct);
                        p05 = new MySql.Data.MySqlClient.MySqlParameter("@usuario", recibo.usuarioNombre);
                        p06 = new MySql.Data.MySqlClient.MySqlParameter("@monto_recibido", recibo.montoRecibidoMonAct);
                        p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", recibo.prvAuto);
                        p08 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor", recibo.prvNombre);
                        p09 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", recibo.prvCiRif);
                        //
                        p10 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", recibo.prvCodigo);
                        p11 = new MySql.Data.MySqlClient.MySqlParameter("@direccion", recibo.prvDirFiscal);
                        p12 = new MySql.Data.MySqlClient.MySqlParameter("@telefono", recibo.prvTlf);
                        p13 = new MySql.Data.MySqlClient.MySqlParameter("@nota", recibo.nota);
                        p14 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", _autoPago);
                        var p15 = new MySql.Data.MySqlClient.MySqlParameter("@importe_divisa", recibo.importeDivisa);
                        var p16 = new MySql.Data.MySqlClient.MySqlParameter("@monto_recibido_divisa", recibo.montoRecibidoDivisa);
                        var p17 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_cambio", recibo.tasaCambio);
                        var p18 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", recibo.autoSistemaDoc);
                        var xr3 = cnn.Database.ExecuteSqlCommand(sql,
                            p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                            p10, p11, p12, p13, p14, p15, p16, p17, p18);
                        if (xr3 == 0)
                        {
                            result.Mensaje = "ERROR AL INSERTAR TABLA [ RECIBO ]";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        //
                        // ACTUALIZAR SALDO PROVEEDOR 
                        sql = @"update proveedores set
                                    creditos=creditos+@montoRecibo
                                where auto=@autoProv";
                        p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoProv", ficha.Recibo.prvAuto);
                        p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoRecibo", ficha.Recibo.importeDivisa);
                        var xr4 = cnn.Database.ExecuteSqlCommand(sql, p01, p02);
                        if (xr4 == 0)
                        {
                            throw new Exception("ERROR AL ACTUALIZAR SALDO PROVEEDOR");
                        }
                        cnn.SaveChanges();
                        //
                        //
                        var _id = 1;
                        foreach (var doc in ficha.Recibo.reciboDoc)
                        {
                            //
                            // ACTUALIZAR SALDO CXP
                            sql = @"update cxp set
                                    acumulado_divisa=acumulado_divisa+@montoRecibo,
                                    resta_divisa=resta_divisa-@montoRecibo
                                where auto=@autoCxp";
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@autoCxp", doc.autoCxpDoc);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@montoRecibo", doc.importeDivisa);
                            var xr5 = cnn.Database.ExecuteSqlCommand(sql, p01, p02);
                            if (xr5 == 0)
                            {
                                throw new Exception("ERROR AL ACTUALIZAR SALDO CXP");
                            }
                            cnn.SaveChanges();
                            //
                            //
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
                                        numero_recibo) 
                                    VALUES (
                                        @id, 
                                        @fecha, 
                                        @tipo_documento, 
                                        @documento, 
                                        @importe, 
                                        'ABONO', 
                                        @auto_cxp, 
                                        @auto_cxp_pago, 
                                        @auto_cxp_recibo, 
                                        @numero_recibo)";
                            p00 = new MySql.Data.MySqlClient.MySqlParameter("@id", _id);
                            p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                            p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", doc.codTipoDc);
                            p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", doc.numDoc);
                            p04 = new MySql.Data.MySqlClient.MySqlParameter("@importe", doc.importeDivisa);
                            p05 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", doc.autoCxpDoc);
                            p06 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_pago", _autoPago);
                            p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_recibo", _autoRecibo);
                            p08 = new MySql.Data.MySqlClient.MySqlParameter("@numero_recibo", _numRecibo);
                            var xr6 = cnn.Database.ExecuteSqlCommand(sql,
                                p00, p01, p02, p03, p04, p05, p06, p07, p08);
                            if (xr6== 0)
                            {
                                throw new Exception("ERROR AL INSERTAR REGISTRO EN TABLA [ CXP_DOCUMENTO ]");
                            }
                            _id += 1;
                            cnn.SaveChanges();
                        }

//                        var sql = "update sistema_contadores set a_compras=a_compras+1, a_cxp=a_cxp+1";
//                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
//                        if (r1 == 0)
//                        {
//                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
//                            result.Result = DtoLib.Enumerados.EnumResult.isError;
//                            return result;
//                        }
//                        var aMovCompra = cnn.Database.SqlQuery<int>("select a_compras from sistema_contadores").FirstOrDefault();
//                        var aMovCxP = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
//                        var autoEntCompra = aMovCompra.ToString().Trim().PadLeft(10, '0');
//                        var autoEntCxP = aMovCxP.ToString().Trim().PadLeft(10, '0');
//                        var _tipoDocumentoCompra = "";
//                        switch (ficha.documento.tipoDocumentoCompra)
//                        {
//                            case DtoLibTransporte.Documento.Agregar.CompraGasto.enumerados.tipoDocumentoCompra.MERCANCIA:
//                                _tipoDocumentoCompra = "1";
//                                break;
//                            case DtoLibTransporte.Documento.Agregar.CompraGasto.enumerados.tipoDocumentoCompra.GASTO:
//                                _tipoDocumentoCompra = "2";
//                                break;
//                        }
//                        //
//                        // HAY DOCUMENTO COMPRA RETENCION 
//                        if (ficha.documento.docRet != null)
//                        {
//                            foreach (var rgDocRet in ficha.documento.docRet)
//                            {
//                                if (rgDocRet.EsIva)
//                                {
//                                    sql = @"update sistema_contadores set 
//                                            a_compras_retenciones=a_compras_retenciones+1, 
//                                            a_compras_retencion_iva=a_compras_retencion_iva+1";
//                                }
//                                else
//                                {
//                                    sql = @"update sistema_contadores set 
//                                            a_compras_retenciones=a_compras_retenciones+1, 
//                                            a_compras_retencion_islr=a_compras_retencion_islr+1";
//                                }
//                                var xr1 = cnn.Database.ExecuteSqlCommand(sql);
//                                var aCompraRet = cnn.Database.SqlQuery<int>("select a_compras_retenciones from sistema_contadores").FirstOrDefault();
//                                var autoCompraRet = aCompraRet.ToString().Trim().PadLeft(10, '0');
//                                //
//                                var numDocCompraRet = "";
//                                if (rgDocRet.EsIva)
//                                {
//                                    var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_iva from sistema_contadores").FirstOrDefault();
//                                    var numCompraRet = n.ToString().Trim().PadLeft(8, '0');
//                                    numDocCompraRet = anoRelacion + mesRelacion + numCompraRet;
//                                }
//                                else
//                                {
//                                    var n = cnn.Database.SqlQuery<int>("select a_compras_retencion_islr from sistema_contadores").FirstOrDefault();
//                                    numDocCompraRet = n.ToString().Trim().PadLeft(10, '0');
//                                }
//                                sql = @"INSERT INTO compras_retenciones (
//                                        auto, 
//                                        documento, 
//                                        fecha, 
//                                        razon_social, 
//                                        dir_fiscal, 
//                                        ci_rif, 
//                                        tipo, 
//                                        exento, 
//                                        base, 
//                                        impuesto, 
//                                        total, 
//                                        tasa_retencion, 
//                                        retencion, 
//                                        auto_proveedor, 
//                                        fecha_relacion, 
//                                        codigo_proveedor, 
//                                        ano_relacion, 
//                                        mes_relacion, 
//                                        renglones, 
//                                        documento_nombre, 
//                                        base2, 
//                                        impuesto2, 
//                                        estatus_anulado, 
//                                        base3, 
//                                        impuesto3, 
//                                        estatus_cierre_contable,
//                                        auto_sistema_documento,
//                                        retencion_monto,
//                                        retencion_sustraendo)
//                                    VALUES (
//                                        @auto, 
//                                        @documento, 
//                                        @fecha, 
//                                        @razon_social, 
//                                        @dir_fiscal, 
//                                        @ci_rif, 
//                                        @tipo, 
//                                        @exento, 
//                                        @base, 
//                                        @impuesto, 
//                                        @total, 
//                                        @tasa_retencion, 
//                                        @retencion, 
//                                        @auto_proveedor, 
//                                        @fecha_relacion, 
//                                        @codigo_proveedor, 
//                                        @ano_relacion, 
//                                        @mes_relacion, 
//                                        1,
//                                        @documento_nombre, 
//                                        @base2, 
//                                        @impuesto2, 
//                                        '0',
//                                        @base3, 
//                                        @impuesto3, 
//                                        '0',
//                                        @auto_sistema_documento,
//                                        @retencion_monto,
//                                        @retencion_sustraendo)";
//                                var _docRet = rgDocRet;
//                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoCompraRet);
//                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", numDocCompraRet);
//                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
//                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@razon_social", _docRet.PrvNombre);
//                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal", _docRet.PrvDirFiscal);
//                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", _docRet.PrvCiRif);
//                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@tipo", _docRet.SistDocCodigo);
//                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@exento", _docRet.MontoExento);
//                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@base", _docRet.MontoBase1);
//                                p09 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto", _docRet.MontoImpuesto1);
//                                //
//                                p10 = new MySql.Data.MySqlClient.MySqlParameter("@total", _docRet.MontoTotal);
//                                p11 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion", _docRet.TasaRetencion);
//                                p12 = new MySql.Data.MySqlClient.MySqlParameter("@retencion", _docRet.MontoRetencion);
//                                p13 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", _docRet.PrvAuto);
//                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_relacion", fechaSistema.Date);
//                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", _docRet.PrvCodigo);
//                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@ano_relacion", anoRelacion);
//                                p17 = new MySql.Data.MySqlClient.MySqlParameter("@mes_relacion", mesRelacion);
//                                p18 = new MySql.Data.MySqlClient.MySqlParameter("@documento_nombre", _docRet.SistDocNombre);
//                                p19 = new MySql.Data.MySqlClient.MySqlParameter("@base2", _docRet.MontoBase2);
//                                //
//                                p20 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto2", _docRet.MontoImpuesto2);
//                                p21 = new MySql.Data.MySqlClient.MySqlParameter("@base3", _docRet.MontoBase3);
//                                p22 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto3", _docRet.MontoImpuesto3);
//                                p23 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", _docRet.SistDocAuto);
//                                p24 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_monto", _docRet.retMonto);
//                                p25 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_sustraendo", _docRet.retSustraendo);
//                                var rf1 = cnn.Database.ExecuteSqlCommand(sql,
//                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
//                                    p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
//                                    p20, p21, p22, p23, p24, p25);
//                                if (rf1 == 0)
//                                {
//                                    result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION IVA ]";
//                                    result.Result = DtoLib.Enumerados.EnumResult.isError;
//                                    return result;
//                                }
//                                cnn.SaveChanges();
//                                //
//                                //ACTUALIZAR DOCUMENTO DE COMPRA - COMPROBANTE DE RETENCION
//                                if (rgDocRet.EsIva)
//                                {
//                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@autoCompra", autoEntCompra);
//                                    p01 = new MySql.Data.MySqlClient.MySqlParameter("@numComprobRetencion", numDocCompraRet);
//                                    sql = @"update compras set comprobante_retencion=@numComprobRetencion
//                                            where auto=@autoCompra";
//                                    var rt1 = cnn.Database.ExecuteSqlCommand(sql,
//                                        p00, p01);
//                                    if (rt1 == 0)
//                                    {
//                                        result.Mensaje = "ERROR AL ACTUALIZAR DOCUMENTO [ COMPRAS - COMPROBANTE RETENCION ]";
//                                        result.Result = DtoLib.Enumerados.EnumResult.isError;
//                                        return result;
//                                    }
//                                    cnn.SaveChanges();
//                                }
//                                //
//                                // INSERTAR COMPRA RETENCION DETALLE 
//                                sql = @"INSERT INTO compras_retenciones_detalle (
//                                        auto_documento, 
//                                        documento, 
//                                        fecha, 
//                                        ci_rif, 
//                                        tipo, 
//                                        exento, 
//                                        base, 
//                                        impuesto, 
//                                        total, 
//                                        tasa_retencion, 
//                                        retencion, 
//                                        auto, 
//                                        fecha_retencion, 
//                                        comprobante, 
//                                        tipo_retencion, 
//                                        aplica, 
//                                        control, 
//                                        tasa, 
//                                        signo, 
//                                        tasa2, 
//                                        base1, 
//                                        base2, 
//                                        impuesto1, 
//                                        impuesto2, 
//                                        retencion1, 
//                                        retencion2, 
//                                        estatus_anulado, 
//                                        tasa3, 
//                                        base3, 
//                                        impuesto3, 
//                                        retencion3, 
//                                        retencion_monto,
//                                        retencion_sustraendo) 
//                                VALUES (
//                                        @auto_documento, 
//                                        @documento, 
//                                        @fecha, 
//                                        @ci_rif, 
//                                        @tipo, 
//                                        @exento, 
//                                        @base, 
//                                        @impuesto, 
//                                        @total, 
//                                        @tasa_retencion, 
//                                        @retencion, 
//                                        @auto, 
//                                        @fecha_retencion, 
//                                        @comprobante, 
//                                        @tipo_retencion, 
//                                        @aplica, 
//                                        @control, 
//                                        @tasa, 
//                                        @signo, 
//                                        @tasa2, 
//                                        @base1, 
//                                        @base2, 
//                                        @impuesto1, 
//                                        @impuesto2, 
//                                        @retencion1, 
//                                        @retencion2, 
//                                        '0',
//                                        @tasa3, 
//                                        @base3, 
//                                        @impuesto3, 
//                                        @retencion3,
//                                        @retencion_monto,
//                                        @retencion_sustraendo)";
//                                foreach (var det in _docRet.docRetDetalle)
//                                {
//                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", autoEntCompra);
//                                    p01 = new MySql.Data.MySqlClient.MySqlParameter("@documento", det.numDocRefRet);
//                                    p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", det.fechaDocRefRet);
//                                    p03 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", det.ciRifDocRefRet);
//                                    p04 = new MySql.Data.MySqlClient.MySqlParameter("@tipo", det.sistTipoDocRefRet);
//                                    p05 = new MySql.Data.MySqlClient.MySqlParameter("@exento", det.montoExento);
//                                    p06 = new MySql.Data.MySqlClient.MySqlParameter("@base", det.montoBase);
//                                    p07 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto", det.montoImpuesto);
//                                    p08 = new MySql.Data.MySqlClient.MySqlParameter("@total", det.montoTotal);
//                                    p09 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_retencion", det.tasaRetencion);
//                                    //
//                                    p10 = new MySql.Data.MySqlClient.MySqlParameter("@retencion", det.totalRetencion);
//                                    p11 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoCompraRet);
//                                    p12 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_retencion", fechaSistema.Date);
//                                    p13 = new MySql.Data.MySqlClient.MySqlParameter("@comprobante", numDocCompraRet);
//                                    p14 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_retencion", det.sistTipoDocRet);
//                                    p15 = new MySql.Data.MySqlClient.MySqlParameter("@aplica", det.numAplicaDocRefRet);
//                                    p16 = new MySql.Data.MySqlClient.MySqlParameter("@control", det.numControlDocRefRet);
//                                    p17 = new MySql.Data.MySqlClient.MySqlParameter("@tasa", det.tasa1);
//                                    p18 = new MySql.Data.MySqlClient.MySqlParameter("@signo", det.sistSignoDocRet);
//                                    p19 = new MySql.Data.MySqlClient.MySqlParameter("@tasa2", det.tasa2);
//                                    //
//                                    p20 = new MySql.Data.MySqlClient.MySqlParameter("@base1", det.base1);
//                                    p21 = new MySql.Data.MySqlClient.MySqlParameter("@base2", det.base2);
//                                    p22 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto1", det.impuesto1);
//                                    p23 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto2", det.impuesto2);
//                                    p24 = new MySql.Data.MySqlClient.MySqlParameter("@retencion1", det.retIva1);
//                                    p25 = new MySql.Data.MySqlClient.MySqlParameter("@retencion2", det.retIva2);
//                                    p26 = new MySql.Data.MySqlClient.MySqlParameter("@tasa3", det.tasa3);
//                                    p27 = new MySql.Data.MySqlClient.MySqlParameter("@base3", det.base3);
//                                    p28 = new MySql.Data.MySqlClient.MySqlParameter("@impuesto3", det.impuesto3);
//                                    p29 = new MySql.Data.MySqlClient.MySqlParameter("@retencion3", det.retIva3);
//                                    //
//                                    p30 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_monto", det.montoRetencion);
//                                    p31 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_sustraendo", det.sustraendoRetencion);
//                                    //
//                                    var rf2 = cnn.Database.ExecuteSqlCommand(sql,
//                                        p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
//                                        p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
//                                        p20, p21, p22, p23, p24, p25, p26, p27, p28, p29,
//                                        p30, p31);
//                                    if (rf2 == 0)
//                                    {
//                                        result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ COMPRAS RETENCION IVA DETALLE ]";
//                                        result.Result = DtoLib.Enumerados.EnumResult.isError;
//                                        return result;
//                                    }
//                                    cnn.SaveChanges();
//                                }
//                                //
//                                // INSERTAR CXP POR RETENCION 
//                                sql = "update sistema_contadores set a_cxp=a_cxp+1";
//                                var xr2 = cnn.Database.ExecuteSqlCommand(sql);
//                                var aRet = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
//                                var _autoRetencion = aRet.ToString().Trim().PadLeft(10, '0');
//                                //
//                                var cxpRet = _docRet.cxpRetencion;
//                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto", _autoRetencion);
//                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", cxpRet.fechaEmision);
//                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", cxpRet.siglasTipoDocumento);
//                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", cxpRet.documentoNro);
//                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_vencimiento", cxpRet.fechaVencimiento);
//                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@nota", cxpRet.notas);
//                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@importe", cxpRet.importe);
//                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado", cxpRet.acumulado);
//                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", cxpRet.autoProveedor);
//                                p09 = new MySql.Data.MySqlClient.MySqlParameter("@proveedor", cxpRet.nombreRazonSocialProveedor);
//                                //
//                                p10 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", cxpRet.ciRifProveedor);
//                                p11 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_proveedor", cxpRet.codigoProveedor);
//                                p12 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cancelado", "0");
//                                p13 = new MySql.Data.MySqlClient.MySqlParameter("@resta", cxpRet.resta);
//                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_anulado", "0");
//                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@auto_documento", autoEntCompra);
//                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@numero", "");
//                                p17 = new MySql.Data.MySqlClient.MySqlParameter("@auto_agencia", "");
//                                p18 = new MySql.Data.MySqlClient.MySqlParameter("@agencia", "");
//                                p19 = new MySql.Data.MySqlClient.MySqlParameter("@signo", cxpRet.signoTipoDocumento);
//                                //
//                                p20 = new MySql.Data.MySqlClient.MySqlParameter("@dias", cxpRet.diasCredito);
//                                p21 = new MySql.Data.MySqlClient.MySqlParameter("@auto_asiento", "");
//                                p22 = new MySql.Data.MySqlClient.MySqlParameter("@anexo", "");
//                                p23 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cierre_contable", "0");
//                                p24 = new MySql.Data.MySqlClient.MySqlParameter("@importeDivisa", cxpRet.importeDivisa);
//                                p25 = new MySql.Data.MySqlClient.MySqlParameter("@acumulado_divisa", cxpRet.acumuladoDivisa);
//                                p26 = new MySql.Data.MySqlClient.MySqlParameter("@resta_divisa", cxpRet.restaDivisa);
//                                p27 = new MySql.Data.MySqlClient.MySqlParameter("@tasa_divisa", cxpRet.tasaDivisa);
//                                p28 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema);
//                                p29 = new MySql.Data.MySqlClient.MySqlParameter("@auto_sistema_documento", cxpRet.autoSistemaDoc);
//                                //
//                                var rf4 = cnn.Database.ExecuteSqlCommand(sqlCxP,
//                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
//                                    p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
//                                    p20, p21, p22, p23, p24, p25, p26, p27, p28, p29);
//                                if (rf4 == 0)
//                                {
//                                    result.Mensaje = "ERROR AL INSERTAR DOCUMENTO CXP RETENCION";
//                                    result.Result = DtoLib.Enumerados.EnumResult.isError;
//                                    return result;
//                                }
//                                cnn.SaveChanges();
//                                //
//                                // DOCUMENTOS QUE INVOLUCRAN EL RECIBO
//                                sql = @"INSERT INTO cxp_documentos (
//                                id, 
//                                fecha, 
//                                tipo_documento, 
//                                documento, 
//                                importe, 
//                                operacion, 
//                                auto_cxp, 
//                                auto_cxp_pago, 
//                                auto_cxp_recibo, 
//                                numero_recibo
//                                ) 
//                            VALUES (
//                                @id, 
//                                @fecha, 
//                                @tipo_documento, 
//                                @documento, 
//                                @importe, 
//                                @operacion, 
//                                @auto_cxp, 
//                                @auto_cxp_pago, 
//                                @auto_cxp_recibo, 
//                                @numero_recibo
//                                )";
//                                var _id = 0;
//                                foreach (var rg in recibo.docRecibo)
//                                {
//                                    _id += 1;
//                                    p00 = new MySql.Data.MySqlClient.MySqlParameter("@id", _id);
//                                    p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
//                                    p02 = new MySql.Data.MySqlClient.MySqlParameter("@tipo_documento", rg.siglasDocumentoAfecta);
//                                    p03 = new MySql.Data.MySqlClient.MySqlParameter("@documento", rg.numDocumentoAfecta);
//                                    p04 = new MySql.Data.MySqlClient.MySqlParameter("@importe", rg.importe);
//                                    p05 = new MySql.Data.MySqlClient.MySqlParameter("@operacion", rg.tipoOperacionRealizar);
//                                    p06 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp", autoEntCxP);
//                                    p07 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_pago", _autoRetencion);
//                                    p08 = new MySql.Data.MySqlClient.MySqlParameter("@auto_cxp_recibo", _autoRecibo);
//                                    p09 = new MySql.Data.MySqlClient.MySqlParameter("@numero_recibo", _numeroRecibo);
//                                    var r9 = cnn.Database.ExecuteSqlCommand(sql,
//                                        p00, p01, p02, p03, p04, p05, p06, p07, p08, p09);
//                                    if (r9 == 0)
//                                    {
//                                        result.Mensaje = "ERROR AL INSERTAR DOCUMENTO [ RECIBO DOCUMENTO POR RETENCION ]";
//                                        result.Result = DtoLib.Enumerados.EnumResult.isError;
//                                        return result;
//                                    }
//                                    cnn.SaveChanges();
//                                }
//                            }
//                        }
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