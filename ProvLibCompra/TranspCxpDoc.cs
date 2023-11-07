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
                        if (ficha.Recibo.reciboDoc != null)
                        {
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
                                if (xr6 == 0)
                                {
                                    throw new Exception("ERROR AL INSERTAR REGISTRO EN TABLA [ CXP_DOCUMENTO ]");
                                }
                                _id += 1;
                                cnn.SaveChanges();
                            }
                        }
                        if (ficha.Cajas != null)
                        {
                            foreach (var rg in ficha.Cajas)
                            {
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
                                        signo)
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
                                        -1)";
                                var cjMov = rg.cajaMov;
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_reg", fechaSistema.Date);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@concepto_mov", "PAGO/ABONO DOCUMENTO POR PAGAR, SEGUN RECIBO NUMERO: " + _numRecibo);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_act", cjMov.montoMovMonAct);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@monto_mov_mon_div", cjMov.montoMovMonDiv);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@factor_cambio_mov", cjMov.factorCambio);
                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@mov_fue_divisa", cjMov.movFueDivisa ? "1" : "0");
                                var rp1 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06);
                                if (rp1 == 0)
                                {
                                    throw new Exception("PROBLEMA AL INSERTAR EN TABLE [ CAJA - MOVIMIENTO ]");
                                }
                                cnn.SaveChanges();
                                //
                                sql = "SELECT LAST_INSERT_ID()";
                                var idCjMov = cnn.Database.SqlQuery<int>(sql).FirstOrDefault();
                                //
                                // INSERTAR CAJA AFECTADA POR ANITCIPO DEL ALIADO
                                sql = @"INSERT INTO cxp_recibos_caj (
                                        id, 
                                        auto_recibo,
                                        auto_proveedor,
                                        fecha_registro,
                                        estatus_anulado,
                                        id_caja, 
                                        cod_caja,
                                        desc_caja,
                                        id_mov_caja,
                                        monto,
                                        es_divisa) 
                                    VALUES (
                                        NULL,
                                        @auto_recibo,
                                        @auto_proveedor,
                                        @fecha_registro,
                                        '0',
                                        @id_caja, 
                                        @cod_caja,
                                        @desc_caja,
                                        @id_mov_caja,
                                        @monto,
                                        @es_divisa)";
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto_recibo", _autoRecibo);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@auto_proveedor", ficha.Recibo.prvAuto);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_registro", fechaSistema.Date);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@id_caja", rg.idCaja);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@cod_caja", rg.codCaja);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@desc_caja", rg.descCaja);
                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@id_mov_caja", idCjMov);
                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.monto);
                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@es_divisa", cjMov.movFueDivisa ? "1" : "0");
                                var rp2 = cnn.Database.ExecuteSqlCommand(sql, p00, p01, p02, p03, p04, p05, p06, p07, p08);
                                if (rp2 == 0)
                                {
                                    throw new Exception("PROBLEMA AL INSERTAR EN TABLA [ CXP-RECIBO-CAJA ]");
                                }
                                cnn.SaveChanges();
                                //
                                // ACTUALIZAR SALDO CAJAS 
                                sql = @"update transp_caja set 
                                        monto_egreso=monto_egreso+@monto
                                    where id=@idCaja";
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@idCaja", rg.idCaja);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@monto", rg.monto);
                                var rp3 = cnn.Database.ExecuteSqlCommand(sql, p00, p01);
                                if (rp3 == 0)
                                {
                                    throw new Exception("PROBLEMA AL ACTUALIZAR SALDO EN TABLA [ CAJA ]");
                                }
                                cnn.SaveChanges();
                            }
                        }
                        if (ficha.Recibo.metPago != null)
                        {
                            foreach (var mt in ficha.Recibo.metPago)
                            {
                                sql = @"INSERT INTO cxp_medio_pago (
                                        auto_recibo, 
                                        medio, 
                                        monto_recibido, 
                                        fecha, 
                                        estatus_anulado, 
                                        documento, 
                                        cuenta, 
                                        codigo, 
                                        numero, 
                                        agencia, 
                                        auto_usuario, 
                                        codigo_banco, 
                                        auto_medio_pago, 
                                        opLote, 
                                        opRef, 
                                        opBanco,    
                                        opNroCta, 
                                        opNroTransf, 
                                        opFecha, 
                                        opDetalle, 
                                        opMonto, 
                                        opTasa, 
                                        opAplicaConversion) 
                                    VALUES (
                                        @auto_recibo, 
                                        @descMedPag, 
                                        @monto_recibido, 
                                        @fechaReg, 
                                        '0',
                                        '', 
                                        '', 
                                        @codigoMedPag, 
                                        '', 
                                        '', 
                                        @auto_usuario, 
                                        '', 
                                        @auto_medio_pago, 
                                        @opLote, 
                                        @opRef, 
                                        @opBanco,    
                                        @opNroCta, 
                                        @opNroTransf, 
                                        @opFecha, 
                                        @opDetalle, 
                                        @opMonto, 
                                        @opTasa, 
                                        @opAplicaConversion)";
                                p00 = new MySql.Data.MySqlClient.MySqlParameter("@auto_recibo", _autoRecibo);
                                p01 = new MySql.Data.MySqlClient.MySqlParameter("@descMedPag", mt.descMedPago);
                                p02 = new MySql.Data.MySqlClient.MySqlParameter("@monto_recibido", mt.OpMonto);
                                p03 = new MySql.Data.MySqlClient.MySqlParameter("@fechaReg", fechaSistema.Date);
                                p04 = new MySql.Data.MySqlClient.MySqlParameter("@codigoMedPag", mt.codigoMedPago);
                                p05 = new MySql.Data.MySqlClient.MySqlParameter("@auto_usuario", mt.autoUsuario);
                                p06 = new MySql.Data.MySqlClient.MySqlParameter("@auto_medio_pago", mt.autoMedPago);
                                p07 = new MySql.Data.MySqlClient.MySqlParameter("@opLote", mt.OpLote);
                                p08 = new MySql.Data.MySqlClient.MySqlParameter("@opRef", mt.OpRef);
                                p09 = new MySql.Data.MySqlClient.MySqlParameter("@opBanco", mt.OpBanco);
                                //
                                p10 = new MySql.Data.MySqlClient.MySqlParameter("@opNroCta", mt.OpNroCta);
                                p11 = new MySql.Data.MySqlClient.MySqlParameter("@opNroTransf", mt.OpNroTransf);
                                p12 = new MySql.Data.MySqlClient.MySqlParameter("@opFecha", mt.OpFecha);
                                p13 = new MySql.Data.MySqlClient.MySqlParameter("@opDetalle", mt.OpDetalle);
                                p14 = new MySql.Data.MySqlClient.MySqlParameter("@opMonto", mt.OpMonto);
                                p15 = new MySql.Data.MySqlClient.MySqlParameter("@opTasa", mt.OpTasa);
                                p16 = new MySql.Data.MySqlClient.MySqlParameter("@opAplicaConversion", mt.OpAplicaConversion);
                                var xr7 = cnn.Database.ExecuteSqlCommand(sql,
                                    p00, p01, p02, p03, p04, p05, p06, p07, p08, p09,
                                    p10, p11, p12, p13, p14, p15, p16);
                                if (xr7 == 0)
                                {
                                    throw new Exception("ERROR AL INSERTAR REGISTRO EN TABLA [ CXP_MEDIO_PAGO ]");
                                }
                                cnn.SaveChanges();
                            }
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
    }
}