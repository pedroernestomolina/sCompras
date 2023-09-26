using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider: ILibCompras.IProvider
    {
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.GeneralDoc.Ficha>
            Transporte_Reportes_Compras_GeneralDoc_GetLista(DtoLibTransporte.Reportes.Compras.GeneralDoc.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.GeneralDoc.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        auto as idDoc,
                                        fecha as fechaDoc,
                                        razon_social as prvNombre,
                                        ci_rif as prvCiRif,
                                        neto as netoDoc,
                                        total as totalDoc,
                                        serie as siglasDoc,
                                        monto_divisa as montoDiv,
                                        estatus_anulado as estatusDoc,
                                        signo as signoDoc,
                                        fecha_registro as fechaReg,
                                        mes_relacion as mesRel,
                                        ano_relacion as anoRel,
                                        desc_compras_concepto as desConcepto
                                    FROM compras ";
                    var _sql_2 = @" WHERE 1=1 ";
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.GeneralDoc.Ficha>(_sql).ToList();
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
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.Retencion.Ficha> 
            Transporte_Reportes_Compras_Retenciones_GetLista(DtoLibTransporte.Reportes.Compras.Retencion.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.Retencion.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        auto as idDoc,
                                        documento as numDoc,
                                        fecha as fechaDoc,
                                        razon_social as prvNombre,
                                        ci_rif as prvCiRif,
                                        total as totalDoc,
                                        exento as montoExento,
                                        base as montoBase1,
                                        impuesto as montoImp1,
                                        base2 as montoBase2,
                                        impuesto2 as montoImp2,
                                        base3 as montoBase3,
                                        impuesto3 as montoImp3,
                                        tasa_retencion as tasaRet,
                                        retencion as totalRet,
                                        retencion_monto as retencionMonto,
                                        retencion_sustraendo as retencionSustraendo
                                 FROM compras_retenciones ";
                    var _sql_2= @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.tipoRet != DtoLibTransporte.Reportes.Compras.enumerados.tipoRetencion.SinDefinir) 
                    {
                        p1.ParameterName = "@tipoRet";
                        if (filtro.tipoRet == DtoLibTransporte.Reportes.Compras.enumerados.tipoRetencion.IVA)
                        {
                            p1.Value = "07";
                        }
                        else
                        {
                            p1.Value = "08";
                        }
                        _sql_2 += " and tipo=@tipoRet ";
                    }
                    var _sql = _sql_1+_sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.Retencion.Ficha>(_sql, p1).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha> 
            Transporte_Reportes_Compras_Planilla_RetIva(string idDocCompra)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        ret.ano_relacion as anoRelRet,
                                        ret.mes_relacion as mesRelRet,
                                        ret.fecha as fechaRet,
                                        ret.razon_social as prvNombre, 
                                        ret.ci_rif as prvCiRif,
                                        retDet.comprobante as comprobanteRet,
                                        retDet.documento as numDoc,
                                        retDet.fecha as fechaEmiDoc,
                                        retDet.control as numControlDoc,
                                        retDet.tipo as tipoDoc,
                                        compra.aplica,
                                        retDet.total,
                                        retDet.exento,
                                        retDet.base1,
                                        retDet.base2,
                                        retDet.base3,
                                        retDet.impuesto1,
                                        retDet.impuesto2,
                                        retDet.impuesto3,
                                        retDet.tasa as tasa1,
                                        retDet.tasa2,
                                        retDet.tasa3,
                                        retDet.retencion1,
                                        retDet.retencion2,
                                        retDet.retencion3,
                                        retDet.tasa_retencion as tasaRet,
                                        retDet.retencion as totalRet
                                FROM compras_retenciones_detalle as retDet 
                                join compras_retenciones as ret on ret.auto=retDet.auto
                                join compras as compra on compra.auto=retDet.auto_documento
                                where retDet.auto_documento =@idDoc and
                                    retDet.tipo_retencion='07'";
                    var _sql_2 = @"";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", idDocCompra);
                    var _sql = _sql_1 + _sql_2;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>(_sql, p1).FirstOrDefault();
                    result.Entidad= _ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha> 
            Transporte_Reportes_Compras_Planilla_RetIslr(string idDocCompra)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        ret.ano_relacion as anoRelRet,
                                        ret.mes_relacion as mesRelRet,
                                        ret.fecha as fechaRet,
                                        ret.razon_social as prvNombre, 
                                        ret.ci_rif as prvCiRif,
                                        compra.dir_fiscal as dirFiscal,
                                        compra.desc_compras_concepto as conceptoDoc,
                                        compra.codigo_compras_concepto as conceptoCod,
                                        retDet.comprobante as comprobanteRet,
                                        retDet.documento as numDoc,
                                        retDet.fecha as fechaEmiDoc,
                                        retDet.control as numControlDoc,
                                        retDet.tipo as tipoDoc,
                                        compra.aplica,
                                        retDet.total,
                                        retDet.exento,
                                        retDet.base1,
                                        retDet.base2,
                                        retDet.base3,
                                        retDet.impuesto1,
                                        retDet.impuesto2,
                                        retDet.impuesto3,
                                        retDet.tasa as tasa1,
                                        retDet.tasa2,
                                        retDet.tasa3,
                                        retDet.retencion1,
                                        retDet.retencion2,
                                        retDet.retencion3,
                                        retDet.tasa_retencion as tasaRet,
                                        retDet.retencion as totalRet,
                                        retDet.retencion_monto subtRet,
                                        retDet.retencion_sustraendo as sustraendoRet
                                FROM compras_retenciones_detalle as retDet 
                                join compras_retenciones as ret on ret.auto=retDet.auto
                                join compras as compra on compra.auto=retDet.auto_documento
                                where retDet.auto_documento =@idDoc and
                                    retDet.tipo_retencion='08'";
                    var _sql_2 = @"";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", idDocCompra);
                    var _sql = _sql_1 + _sql_2;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>(_sql, p1).FirstOrDefault();
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

        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha> 
            Transporte_Reportes_Aliado_Anticipos_GetLista(DtoLibTransporte.Reportes.Aliado.Anticipo.General.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as idMov,
                                        id_aliado as idAliado,
                                        nombre_aliado as nombreAliado,
                                        cirif_aliado as cirifAliado,
                                        fecha_registro as fecha,
                                        recibo_numero as numRecibo,
                                        motivo as motivo,
                                        monto_neto_mon_div as montoAntSolicitadoDiv,
                                        aplica_ret as aplicaRet,
                                        tasa_ret as tasaRet,
                                        sustraendo_ret as sustraendoMonAct,
                                        monto_retencion as montoRetMonAct,
                                        monto_pag_mon_div as montoPagoDiv,
                                        estatus_anulado as estatusAnulado,
                                        tasa_factor as factorCambio
                                    FROM transp_aliado_anticipo";
                    var _sql_2 = @" WHERE 1=1 ";
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha>(_sql).ToList();
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
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha>
            Transporte_Reportes_Aliado_PagoServ_GetLista(DtoLibTransporte.Reportes.Aliado.PagoServ.General.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as idMov,
                                        id_aliado as idAliado,
                                        aliado_nombre as nombreAliado,
                                        aliado_codigo as codigoAliado,
                                        aliado_cirif as cirifAliado,
                                        recibo_numero as numRecibo,
                                        fecha_registro as fecha,
                                        motivo as motivo,
                                        tasa_factor as tasaFactor,
                                        monto_mon_div as montoPagoSelMonDiv,
                                        aplica_ret as aplicaRet,
                                        tasa_ret as tasaRet,
                                        retencion as retencion,
                                        sustraendo as sustraendo,
                                        monto_ret_mon_act as montoRetMonAct,
                                        total_pag_mon_div as totalPagoMonDiv,
                                        estatus_anulado as estatusAnulado,
                                        cnt_serv_pag as cntServPag
                                    FROM transp_aliado_pagoserv";
                    var _sql_2 = @" WHERE 1=1 ";
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha>(_sql).ToList();
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

        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Ficha> 
            Transporte_Reportes_Aliado_Anticipos_Planilla(int idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    fecha_emision as fechaEmision,
                                    fecha_registro as fechaRegistro,
                                    cirif_aliado as ciRifAliado,
                                    nombre_aliado as nombreAliado,
                                    monto_neto_mon_div as montoSolicitado,
                                    tasa_factor as tasaFactor,
                                    motivo as motivo,
                                    aplica_ret as aplicaRet,
                                    tasa_ret as tasaRet,
                                    sustraendo_ret as sustraendo,
                                    monto_retencion as montoRet,
                                    monto_pag_mon_div as montoPagado,
                                    recibo_numero as numRecibo
                                FROM transp_aliado_anticipo
                                WHERE id=@idMov";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Ficha>(sql, p0).FirstOrDefault();
                    if (ent == null) 
                    {
                        throw new Exception("MOVIMIENTO NO ENCONTRADO");
                    }
                    result.Entidad= ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Ficha> 
            Transporte_Reportes_Aliado_PagoServ_Planilla(int idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    fecha_emision as fechaEmision,
                                    fecha_registro as fechaRegistro,
                                    aliado_nombre as nombreAliado, 
                                    aliado_codigo as codigoAliado, 
                                    aliado_cirif as ciRifAliado,
                                    recibo_numero as numRecibo, 
                                    cnt_serv_pag as cntServ, 
                                    motivo as motivo,
                                    monto_mon_div as montoAPagar, 
                                    tasa_factor as tasaFactor, 
                                    aplica_ret as aplicaRet, 
                                    tasa_ret as tasaRet, 
                                    retencion as retencion, 
                                    sustraendo as sustraendo, 
                                    monto_ret_mon_act as montoRetMonAct,
                                    monto_ret_mon_div as montoRetMonDiv, 
                                    total_pag_mon_div as totalPago
                                FROM transp_aliado_pagoserv
                                where id=@idMov";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Ficha>(sql, p0).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("MOVIMIENTO NO ENCONTRADO");
                    }
                    //
                    sql = @"SELECT 
                                aliadoDoc.doc_numero as docNumero,
                                aliadoDoc.doc_fecha as docFecha,
                                aliadoDoc.doc_codigo as docCodigo,
                                aliadoDoc.doc_nombre as docNombre,
                                pagoDet.monto_pago_mon_div as montoPago,
                                vta.razon_social as cliNombre,
                                vta.ci_rif as cliCiRif,
                                aliadoDocServ.codigo_serv as codServ,
                                aliadoDocServ.desc_serv as descServ,
                                aliadoDocServ.detalle_serv as detServ
                            FROM transp_aliado_pagoserv_det as pagoDet  
                            join transp_aliado_doc as aliadoDoc on aliadoDoc.id=pagoDet.id_aliado_doc
                            join ventas as vta on vta.auto=aliadoDoc.id_doc_ref
                            join transp_aliado_doc_servicio as aliadoDocServ on aliadoDocServ.id=pagoDet.id_aliado_serv
                            WHERE id_pagoserv=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Serv>(sql, p0).ToList();
                    //
                    ent.serv = _lst;
                    result.Entidad = ent;
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