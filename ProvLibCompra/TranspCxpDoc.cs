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
                                    c.condicion_pago as condicion
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
    }
}