﻿using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider : ILibCompras.IProvider
    {
        //DOCUMENTOS
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
                                        desc_compras_concepto as desConcepto,
                                        documento as numeroDoc,
                                        base as montoBase,
                                        impuesto as montoImpuesto,
                                        exento as montoExento,
                                        igtf_monto as montoIgtf
                                    FROM compras ";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.Desde.HasValue)
                    {
                        _sql_2 += " and fecha>=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_2 += " and fecha<=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                    }
                    if (filtro.IdProveedor != "")
                    {
                        _sql_2 += " and auto_proveedor=@idProveedor ";
                        p3.ParameterName = "@idProveedor";
                        p3.Value = filtro.IdProveedor;
                    }
                    if (filtro.IdConcepto != -1)
                    {
                        _sql_2 += " and id_compras_concepto=@idConcepto ";
                        p4.ParameterName = "@idConcepto";
                        p4.Value = filtro.IdConcepto;
                    }
                    if (filtro.EstatusDoc != "")
                    {
                        _sql_2 += " and estatus_anulado=@estatus ";
                        p5.ParameterName = "@estatus";
                        p5.Value = filtro.EstatusDoc;
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.GeneralDoc.Ficha>(_sql, p1, p2, p3, p4, p5).ToList();
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
                                        retencion_sustraendo as retSustraendo,
                                        estatus_anulado as estatusAnulado
                                 FROM compras_retenciones ";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.Desde.HasValue)
                    {
                        _sql_2 += " and fecha>=@desde ";
                        p2.ParameterName = "@desde";
                        p2.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_2 += " and fecha<=@hasta ";
                        p3.ParameterName = "@hasta";
                        p3.Value = filtro.Hasta;
                    }
                    if (filtro.IdProveedor != "")
                    {
                        _sql_2 += " and auto_proveedor=@idProveedor ";
                        p4.ParameterName = "@idProveedor";
                        p4.Value = filtro.IdProveedor;
                    }
                    if (filtro.EstatusDoc != "")
                    {
                        _sql_2 += " and estatus_anulado=@estatus ";
                        p5.ParameterName = "@estatus";
                        p5.Value = filtro.EstatusDoc;
                    }
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
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.Retencion.Ficha>(_sql, p1, p2, p3, p4, p5).ToList();
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
                                        ret.dir_fiscal as prvDirFiscal,
                                        retDet.comprobante as comprobanteRet,
                                        retDet.documento as numDoc,
                                        retDet.fecha as fechaEmiDoc,
                                        retDet.control as numControlDoc,
                                        retDet.tipo as tipoDoc,
                                        compra.aplica,
                                        compra.maquina_fiscal as maquinaFiscal,
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
                                where retDet.auto_documento =@idDoc and retDet.estatus_anulado='0' and 
                                    retDet.tipo_retencion='07'";
                    var _sql_2 = @"";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", idDocCompra);
                    var _sql = _sql_1 + _sql_2;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>(_sql, p1).FirstOrDefault();
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
                                        retDet.retencion_sustraendo as sustraendoRet,
                                        prov.codigo_xml_islr as codXmlIslr,
                                        prov.desc_xml_islr as descXmlIslr
                                FROM compras_retenciones_detalle as retDet 
                                join compras_retenciones as ret on ret.auto=retDet.auto
                                join compras as compra on compra.auto=retDet.auto_documento
                                join proveedores as prov on prov.auto=compra.auto_proveedor
                                where retDet.auto_documento =@idDoc and retDet.estatus_anulado='0' and 
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

        //ALIADO-PLANILLAS
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
                    //
                    sql = @"SELECT 
                                cj.descripcion as cjDesc,
                                cjMov.mov_fue_divisa as esDivisa,
                                case 
                                    when cjMov.mov_fue_divisa='1' then monto_mov_mon_div 
                                    else monto_mov_mon_act
                                end as monto
                            FROM transp_aliado_anticipo_caja as antCj
                            join transp_caja_mov as cjMov on cjMov.id=antCj.id_caja_mov
                            join transp_caja as cj on cj.id=cjMov.id_caja
                            where antCj.id_anticipo=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _cjs = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Caja>(sql, p0).ToList();
                    //
                    ent.caja = _cjs;
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
                                    total_pag_mon_div as totalPago,
                                    (monto_anticipo_usado+monto_anticipo_ret_usado) as anticipo,
                                    monto_mon_act as montoAPagarMonAct, 
                                    tasa_promedio_factor_anticipo as tasaPromFactorAnticipo
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
                    sql = @"SELECT 
                                desc_caja as cjDesc,
                                monto as monto,
                                es_divisa as esDivisa
                            FROM transp_aliado_pagoserv_caj
                            where id_pagoserv=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _cjs = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Caja>(sql, p0).ToList();
                    //
                    ent.serv = _lst;
                    ent.caja = _cjs;
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

        //ALIADOS
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
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.Desde.HasValue)
                    {
                        _sql_2 += " and fecha_registro >=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_2 += " and fecha_registro <=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                    }
                    if (filtro.IdAliado != -1)
                    {
                        _sql_2 += " and id_aliado=@idAliado ";
                        p4.ParameterName = "@idAliado";
                        p4.Value = filtro.IdAliado;
                    }
                    if (filtro.EstatusDoc != DtoLibTransporte.Reportes.Aliado.enumerados.EstatusDoc.SinDefinir)
                    {
                        var _estatusDoc = "0";
                        if (filtro.EstatusDoc == DtoLibTransporte.Reportes.Aliado.enumerados.EstatusDoc.Anulado)
                        {
                            _estatusDoc = "1";
                        }
                        _sql_2 += " and estatus_anulado=@estatus ";
                        p5.ParameterName = "@estatus";
                        p5.Value = _estatusDoc;
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha>(_sql, p1, p2, p3, p4, p5).ToList();
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
                                        estatus_procesado as estatusProcesado,
                                        cnt_serv_pag as cntServPag
                                    FROM transp_aliado_pagoserv";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.Desde.HasValue)
                    {
                        _sql_2 += " and fecha_registro >=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_2 += " and fecha_registro <=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                    }
                    if (filtro.IdAliado != -1)
                    {
                        _sql_2 += " and id_aliado=@idAliado ";
                        p4.ParameterName = "@idAliado";
                        p4.Value = filtro.IdAliado;
                    }
                    if (filtro.EstatusDoc != DtoLibTransporte.Reportes.Aliado.enumerados.EstatusDoc.SinDefinir)
                    {
                        var _estatusDoc = "0";
                        if (filtro.EstatusDoc == DtoLibTransporte.Reportes.Aliado.enumerados.EstatusDoc.Anulado)
                        {
                            _estatusDoc = "1";
                        }
                        _sql_2 += " and estatus_anulado=@estatus ";
                        p5.ParameterName = "@estatus";
                        p5.Value = _estatusDoc;
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha>(_sql, p1, p2, p3, p4, p5).ToList();
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
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.MovCaja.Ficha>
            Transporte_Reportes_Aliado_MovCaja_GetLista(DtoLibTransporte.Reportes.Aliado.MovCaja.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.MovCaja.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        rel.id_aliado as idAliado, 
                                        rel.id_caja as idCaja, 
                                        rel.id_caja_mov as idCajaMov,
                                        rel.desc_caja as cajaDescripcion,
                                        rel.fecha_registro as fechaMov,
                                        cajaMov.concepto_mov as conceptoMov,
                                        cajaMov.monto_mov_mon_act as montoMonAct,
                                        cajaMov.monto_mov_mon_div as montoMonDiv,
                                        cajaMov.signo as signo,
                                        pgServ.recibo_numero as reciboNro,
                                        pgServ.tasa_factor as tasaFactor,
                                        pgServ.aliado_nombre as nombreAliado,
                                        pgServ.aliado_cirif as ciRifAliado,
                                        'PAGO/SERVICIO' as tipoMov
                                    FROM transp_aliado_pagoserv_caj as rel
                                    join transp_aliado_pagoserv as pgServ on rel.id_pagoserv=pgServ.id
                                    join transp_caja_mov as cajaMov on rel.id_caja_mov=cajaMov.id
                                    where rel.estatus_anulado='0' ";

                    var _sql_2 = @"SELECT 
                                        rel.id_aliado as idAliado, 
                                        rel.id_caja as idCaja, 
                                        rel.id_caja_mov as idCajaMov,
                                        caja.descripcion as cajaDescripcion,
                                        rel.fecha_reg as fechaMov,
                                        cajaMov.concepto_mov as conceptoMov,
                                        cajaMov.monto_mov_mon_act as montoMonAct,
                                        cajaMov.monto_mov_mon_div as montoMonDiv,
                                        cajaMov.signo as signo,
                                        aliadoAnt.recibo_numero as reciboNro,
                                        aliadoAnt.tasa_factor as tasaFactor,
                                        aliadoAnt.nombre_aliado as nombreAliado,
                                        aliadoAnt.cirif_aliado as ciRifAliado,
                                        'ANTICIPOS' as tipoMov
                                    FROM transp_aliado_anticipo_caja as rel
                                    join transp_aliado_anticipo as aliadoAnt on rel.id_anticipo=aliadoAnt.id
                                    join transp_caja_mov as cajaMov on rel.id_caja_mov=cajaMov.id
                                    join transp_caja as caja on rel.id_caja=caja.id
                                    where rel.estatus_anulado='0' ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.Desde.HasValue)
                    {
                        _sql_1 += " and rel.fecha_registro >=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;

                        _sql_2 += " and rel.fecha_reg >=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_1 += " and rel.fecha_registro <=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;

                        _sql_2 += " and rel.fecha_reg <=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                    }
                    if (filtro.IdAliado != -1)
                    {
                        _sql_1 += " and rel.id_aliado=@idAliado ";
                        p3.ParameterName = "@idAliado";
                        p3.Value = filtro.IdAliado;

                        _sql_2 += " and rel.id_aliado=@idAliado ";
                        p3.ParameterName = "@idAliado";
                        p3.Value = filtro.IdAliado;
                    }
                    var _sql = _sql_1 + " union ( " + _sql_2 + " )";
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Aliado.MovCaja.Ficha>(_sql, p1, p2, p3).ToList();
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

        //CAJA
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Caja.Movimiento.Ficha>
            Transporte_Reportes_Caja_Movimientos_GetLista(DtoLibTransporte.Reportes.Caja.Movimiento.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Caja.Movimiento.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        cj.id as idCaja,
                                        cjMov.id as idMov,
                                        cj.descripcion as cjDesc,
                                        cj.es_divisa as cjEsDivisa,
                                        cjMov.fecha_emision as fechaMov,
                                        cjMov.concepto_mov as motivoMov,
                                        cjMov.tipo_mov as tipoMov,
                                        cjMov.signo as signoMov,
                                        cjMov.monto_mov_mon_act as montoMonAct,
                                        cjMov.monto_mov_mon_div as montoMonDiv,
                                        cjMov.factor_cambio_mov as factorCambio,
                                        cjMov.estatus_anulado_mov as estatusAnulado,
                                        cjMov.mov_fue_divisa as movFueDivisa
                                    FROM transp_caja_mov as cjMov
                                    join transp_caja as cj on cj.id=cjMov.id_caja ";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro.Desde.HasValue)
                    {
                        _sql_2 += " and cjMov.fecha_emision >=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_2 += " and cjMov.fecha_emision <=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                    }
                    if (filtro.TipoMov != DtoLibTransporte.Reportes.Caja.enumerados.TipoMovCaja.SinDefinir)
                    {
                        var _tipoMov = "I";
                        if (filtro.TipoMov == DtoLibTransporte.Reportes.Caja.enumerados.TipoMovCaja.Egreso)
                        {
                            _tipoMov = "E";
                        }
                        _sql_2 += " and cjMov.tipo_mov=@tipoMov ";
                        p3.ParameterName = "@tipoMov";
                        p3.Value = _tipoMov;
                    }
                    if (filtro.IdCaja != -1)
                    {
                        _sql_2 += " and cj.id=@idCaja ";
                        p4.ParameterName = "@idCaja";
                        p4.Value = filtro.IdCaja;
                    }
                    if (filtro.EstatusDoc != DtoLibTransporte.Reportes.Caja.enumerados.EstatusDoc.SinDefinir)
                    {
                        var _estatusDoc = "0";
                        if (filtro.EstatusDoc == DtoLibTransporte.Reportes.Caja.enumerados.EstatusDoc.Anulado)
                        {
                            _estatusDoc = "1";
                        }
                        _sql_2 += " and cjMov.estatus_anulado_mov=@estatus ";
                        p5.ParameterName = "@estatus";
                        p5.Value = _estatusDoc;
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Caja.Movimiento.Ficha>(_sql, p1, p2, p3, p4, p5).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Caja.Saldo.Ficha>
            Transporte_Reportes_Caja_Saldo_Al(DtoLibTransporte.Reportes.Caja.Saldo.Filtro filtro)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Caja.Saldo.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        sum(cjMov.monto_mov_mon_act*signo) as montoMonAct,
                                        sum(cjMov.monto_mov_mon_div*signo) as montoMonDiv,
                                        cj.es_divisa as esDivisa,
                                        cj.saldo_inicial as saldoIni
                                   FROM transp_caja_mov as cjMov
                                        join transp_caja as cj on cj.id=cjMov.id_caja 
                                   WHERE id_caja=@idCaja and
                                         estatus_anulado_mov='0' and
                                         fecha_emision<=@fecha";
                    var _sql_2 = @"";
                    var _sql = _sql_1 + _sql_2;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("idCaja", filtro.idCaja);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("fecha", filtro.fecha);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Caja.Saldo.Ficha>(_sql, p1, p2).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("PROBLEMA AL CONSULTAR SALDO CAJA");
                    }
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

        //BENEFICIAIRO
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Beneficiario.Movimiento.Ficha>
            Transporte_Reportes_Beneficiario_Movimiento_GetLista(DtoLibTransporte.Reportes.Beneficiario.Movimiento.Fitro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Beneficiario.Movimiento.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        nombre_bene as nombreBene,
                                        cirif_bene as cirifBene,
                                        fecha_registro as fechaReg,
                                        monto_div as montoDiv,
                                        estatus_anulado as estatusAnulado,
                                        desc_concepto as descConcepto,
                                        cod_concepto as codConcepto
                                    FROM transp_beneficiario_mov ";
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
                        if (filtro.Estatus != "")
                        {
                            _sql_2 += " and estatus_anulado=@estatus ";
                            p4.ParameterName = "@estatus";
                            p4.Value = filtro.Estatus.Trim().ToUpper() == "I" ? "1" : "0";
                        }
                        if (filtro.IdBeneficiario != -1)
                        {
                            _sql_2 += " and id_beneficiario=@idBeneficiario ";
                            p3.ParameterName = "@idBeneficiario";
                            p3.Value = filtro.IdBeneficiario;
                        }
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Beneficiario.Movimiento.Ficha>(_sql, p1, p2, p3, p4).ToList();
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
        //BENEFICIAIRO-PLANILLA
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Beneficiario.Planilla.Ficha> 
            Transporte_Reportes_Beneficiario_Planilla(int idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Beneficiario.Planilla.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    fecha_mov as fechaEmision,
                                    fecha_registro as fechaRegistro,
                                    cirif_bene as ciRifBene,
                                    nombre_bene as nombreBene,
                                    monto_div as montoSolicitado,
                                    factor_tasa as tasaFactor,
                                    notas as motivo,
                                    recibo_nro as numRecibo,
                                    desc_concepto as descConcepto,
                                    cod_concepto as codConcepto
                                FROM transp_beneficiario_mov
                                WHERE id=@idMov";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Beneficiario.Planilla.Ficha>(sql, p0).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("MOVIMIENTO NO ENCONTRADO");
                    }
                    //
                    sql = @"SELECT 
                                cj.descripcion as cjDesc,
                                cjMov.mov_fue_divisa as esDivisa,
                                case 
                                    when cjMov.mov_fue_divisa='1' then monto_mov_mon_div 
                                    else monto_mov_mon_act
                                end as monto
                            FROM transp_beneficiario_caj as beneCj
                            join transp_caja_mov as cjMov on cjMov.id=beneCj.id_caja_mov
                            join transp_caja as cj on cj.id=cjMov.id_caja
                            where beneCj.id_mov=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _cjs = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Beneficiario.Planilla.Caja>(sql, p0).ToList();
                    //
                    ent.caja = _cjs;
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


        //CXP
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Ficha> 
            Transporte_Reportes_Cxp_Documentos_PagosEmitidos(DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        rec.documento as reciboNro,
                                        rec.importe_divisa as importe,
                                        rec.proveedor as provNombre,
                                        rec.ci_rif as provCiRif,
                                        rec.fecha as fecha,
                                        rec.tasa_cambio as tasaFactor,
                                        rec.nota as nota,
                                        rec.estatus_anulado as estatus
                                    FROM cxp_recibos as rec";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro != null)
                    {
                        if (filtro.Desde.HasValue)
                        {
                            _sql_2 += " and rec.fecha>=@desde ";
                            p1.ParameterName = "@desde";
                            p1.Value = filtro.Desde.Value;
                        }
                        if (filtro.Hasta.HasValue)
                        {
                            _sql_2 += " and rec.fecha<=@hasta ";
                            p2.ParameterName = "@hasta";
                            p2.Value = filtro.Hasta.Value;
                        }
                        if (filtro.EstatusDoc != DtoLibTransporte.Reportes.Cxp.enumerados.EstatusDoc.SinDefinir)
                        {
                            _sql_2 += " and rec.estatus_anulado=@estatus ";
                            p4.ParameterName = "@estatus";
                            p4.Value = filtro.EstatusDoc== DtoLibTransporte.Reportes.Cxp.enumerados.EstatusDoc.Anulado ? "1" : "0";
                        }
                        if (filtro.IdProveedor != "")
                        {
                            _sql_2 += " and rec.auto_proveedor=@idProveedor";
                            p3.ParameterName = "@idProveedor";
                            p3.Value = filtro.IdProveedor;
                        }
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Ficha>(_sql, p1, p2, p3, p4).ToList();
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
        //CXP-PLANILLA
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.Ficha>
            Transporte_Reportes_Cxp_PagoEmitido_Planilla(string idMov)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    rec.documento as reciboNro,
                                    rec.fecha as fechaMov,
                                    rec.importe_divisa as importeDiv,
                                    rec.monto_recibido_divisa as montoRecDiv,
                                    rec.tasa_cambio as tasaCambio,
                                    rec.nota as notasMov,
                                    rec.proveedor as nombreProv,
                                    rec.ci_rif as ciRifProv,
                                    rec.direccion as dirProv,
                                    rec.estatus_anulado as estatusMov,
                                    rec.anticipo_usado as anticipoComoMedioPago,
                                    rec.guardar_anticipo_prov as guardarComoAnticipo
                                FROM cxp_recibos as rec
                                where auto=@idMov";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var ent = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.Ficha>(sql, p0).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("MOVIMIENTO NO ENCONTRADO");
                    }
                    //
                    sql = @"SELECT 
                                doc.tipo_documento as siglasDoc,
                                doc.fecha as fechaEmisionDoc,
                                doc.documento as numeroDoc,
                                doc.importe as montoDiv
                            FROM cxp_documentos as doc
                            WHERE auto_cxp_recibo=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _doc = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.Documento>(sql, p0).ToList();
                    //
                    sql = @"SELECT 
                                met.medio as descMet,
                                met.codigo as codMet,
                                met.opLote,
                                met.opRef,
                                met.opBanco,
                                met.opNroCta,
                                met.opNroTransf,
                                met.opFecha,
                                met.opDetalle,
                                met.opMonto,
                                met.opTasa,
                                met.opAplicaConversion
                            FROM cxp_medio_pago as met
                            where auto_recibo=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _met = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.MetodoPago>(sql, p0).ToList();
                    //
                    sql = @"SELECT 
                                cj.desc_caja as cjDesc,
                                cj.monto as monto,
                                cj.es_divisa as esDivisa,
                                cj.cod_caja as cjCod
                            FROM cxp_recibos_caj as cj
                            where auto_recibo=@idMov";
                    p0 = new MySql.Data.MySqlClient.MySqlParameter("@idMov", idMov);
                    var _cjs = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.Caja>(sql, p0).ToList();
                    //
                    ent.doc = _doc;
                    ent.metPago = _met;
                    ent.caja = _cjs;
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
        //
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Cxp.PagoPorConceptos.Ficha> 
            Transporte_Reportes_Cxp_PagosPorConcepto(DtoLibTransporte.Reportes.Cxp.PagoPorConceptos.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Cxp.PagoPorConceptos.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"SELECT 
                                    rec.documento as recNro,
                                    rec.fecha as recFecha,
                                    rec.proveedor as entidadNombre,
                                    rec.ci_rif as entidadCiRif,
                                    rec.importe_divisa as importeDiv,
                                    rec.tasa_cambio as tasaFactor,
                                    doc.tipo_documento as siglasDoc,
                                    doc.documento as numeroDoc,
                                    c.desc_compras_concepto as conceptoDesc,
                                    c.codigo_compras_concepto as conceptoCod
                                from cxp_recibos as rec
                                join cxp_documentos as doc on doc.auto_cxp_recibo=rec.auto
                                join compras as c on c.auto_cxp=doc.auto_cxp
                                where rec.estatus_anulado='0'
                                    and (rec.auto_sistema_documento<>'0000000028' and rec.auto_sistema_documento<>'0000000029') ";
                    var sql_2=@"SELECT 
                                    recibo_nro as recNro,
                                    fecha_registro as recFecha,
                                    nombre_bene as entidadNombre,
                                    cirif_bene as entidadCiRif,
                                    monto_div as importeDiv,
                                    factor_tasa as tasaFactor,
                                    '' as siglasDoc,
                                    '' as numeroDoc,
                                    desc_concepto as conceptoDesc,
                                    cod_concepto as conceptoCod
                                FROM transp_beneficiario_mov 
                                WHERE estatus_anulado='0'";
                    var sql_3 = @"SELECT 
                                        movEx.recibo_nro  as recNro,
                                        mov.fecha_reg as recFecha,
                                        mov.concepto_mov as entidadNombre,
                                        '' as entidadCiRif,
                                        mov.monto_mov_mon_div as importeDiv,
                                        mov.factor_cambio_mov as tasaFactor,
                                        '' as siglasDoc,
                                        '' as numeroDoc,
                                        desc_concepto as conceptoDesc,
                                        cod_concepto as conceptoCod
                                    FROM transp_caja_mov_extra as movEx
                                    join transp_caja_mov as mov on mov.id=movEx.id_mov
                                    where mov.estatus_anulado_mov='0'
                                        and mov.es_mov_caja='1'
                                        and mov.tipo_mov='E' ";
                    if (filtro.Desde.HasValue) 
                    {
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                        //
                        sql_1 += " and rec.fecha>=@desde ";
                        sql_2 += " and fecha_registro>=@desde ";
                        sql_3 += " and mov.fecha_reg>=@desde";
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                        //
                        sql_1 += " and rec.fecha<=@hasta ";
                        sql_2 += " and fecha_registro<=@hasta ";
                        sql_3 += " and mov.fecha_reg<=@hasta";
                    }
                    if (filtro.IdConcepto!=-1)
                    {
                        p3.ParameterName = "idConcepto";
                        p3.Value = filtro.IdConcepto;
                        //
                        sql_1 += " and c.id_compras_concepto=@idConcepto ";
                        sql_2 += " and id_concepto=@idConcepto ";
                        sql_3+=" and movEx.id_concepto=@idConcepto ";
                    }
                    var sql = sql_1 + " union ( " + sql_2 + " ) union ( "+sql_3+" )";
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Cxp.PagoPorConceptos.Ficha>(sql, p1, p2, p3).ToList();
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