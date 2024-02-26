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
        public DtoLib.ResultadoLista<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha> 
            Transporte_DocumentoRet_GetLista(DtoLibTransporte.DocumentoRet.ListaAdm.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        ret.auto as auto, 
                                        retDet.auto_documento as autoDocRef,
                                        ret.fecha as fechaEmision,
                                        retDet.comprobante as documentoNro,
                                        ret.razon_social as provNombre,
                                        ret.ci_rif as provCiRif,
                                        retDet.retencion as retMonto,
                                        retDet.tasa_retencion as retTasa,
                                        retDet.estatus_anulado as estatusAnulado,
                                        retDet.tipo_retencion as tipoRetCod,
                                        ret.documento_nombre as tipoRetDesc,
                                        retDet.signo as signoRet
                                    FROM compras_retenciones_detalle as retDet
                                    join compras_retenciones as ret on ret.auto=retDet.auto";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro != null)
                    {
                        if (filtro.Desde.HasValue)
                        {
                            _sql_2 += " and ret.fecha>=@desde ";
                            p1.ParameterName = "@desde";
                            p1.Value = filtro.Desde.Value;
                        }
                        if (filtro.Hasta.HasValue)
                        {
                            _sql_2 += " and ret.fecha<=@hasta ";
                            p2.ParameterName = "@hasta";
                            p2.Value = filtro.Hasta.Value;
                        }
                        if (filtro.IdProveedor != "")
                        {
                            _sql_2 += " and ret.auto_proveedor=@idProveedor ";
                            p3.ParameterName = "@idProveedor";
                            p3.Value = filtro.IdProveedor;
                        }
                        if (filtro.Estatus != "")
                        {
                            _sql_2 += " and ret.estatus_anulado=@estatus ";
                            p4.ParameterName = "@estatus";
                            p4.Value = filtro.Estatus.Trim().ToUpper() == "I" ? "1" : "0";
                        }
                        if (filtro.TipoRetencion != "")
                        {
                            _sql_2 += " and retDet.tipo_retencion=@tipoRet ";
                            p5.ParameterName = "@tipoRet";
                            p5.Value = filtro.TipoRetencion;
                        }
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha>(_sql, p1, p2, p3, p4, p5).ToList();
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
        //
        public DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha> 
            Transporte_DocumentoRet_Crud_Corrector_ObtenerData(string idDoc)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha>();
            //
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
                                        compra.dir_fiscal as prvDirFiscal,
                                        compra.desc_compras_concepto as conceptoDoc,
                                        compra.codigo_compras_concepto as conceptoCod,
                                        compra.maquina_fiscal as maquinaFiscal,
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
                                where retDet.auto_documento =@idDoc";
                    var _sql_2 = @"";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", idDoc);
                    var _sql = _sql_1 + _sql_2;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha>(_sql, p1).FirstOrDefault();
                    result.Entidad = _ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}