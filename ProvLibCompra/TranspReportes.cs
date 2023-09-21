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
    }
}