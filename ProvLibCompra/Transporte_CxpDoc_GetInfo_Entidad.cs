using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider : ILibCompras.IProvider
    {
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.GetInfoEntidad.Ficha>
            Transporte_CxpDoc_GetInfo_Entidad(string idEntidad)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.GetInfoEntidad.Ficha>();
            var _lstDoc = new List<DtoLibTransporte.CxpDoc.GetInfoEntidad.DocPendiente>();
            var _entidad = new DtoLibTransporte.CxpDoc.GetInfoEntidad.Entidad(); 
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    // DOCUMENTOS
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idEntidad", idEntidad);
                    var _sql_1 = @"SELECT 
                                    cxp.auto as idCxP,
                                    cxp.fecha as fechaEmision,
                                    cxp.dias as diasCredito,
                                    cxp.tipo_documento as tipoDoc,
                                    cxp.documento as docNro,
                                    cxp.signo as signoDoc,
                                    cxp.fecha_vencimiento as fechaVence,
                                    prv.ci_rif as ciRif,
                                    prv.razon_social as nombreRazonSocial,
                                    cxp.importeDivisa as importeDiv,
                                    cxp.acumulado_divisa as acumuladoDiv,
                                    cxp.resta_divisa as restaDiv,
                                    cxp.tasa_divisa as tasaFactor,
                                    cxp.auto_documento as idDocOrigen,
                                    prv.auto as idEntidad,
                                    DATEDIFF(CURDATE(), cxp.fecha_vencimiento) as diasVencida,
                                    cxp.nota as notasDoc ";
                    var _sql_2 = @" FROM cxp 
                                join proveedores as prv on prv.auto=cxp.auto_proveedor ";
                    var _sql_3 = @" where cxp.estatus_anulado='0' and 
                                        cxp.tipo_documento in ('FAC','NDB','NCR') and
                                        cxp.resta_divisa>0 ";
                    _sql_3 += @" and prv.auto=@idEntidad ";
                    var _sql = _sql_1 + _sql_2 + _sql_3;
                    _lstDoc = cnn.Database.SqlQuery<DtoLibTransporte.CxpDoc.GetInfoEntidad.DocPendiente>(_sql, p1).ToList();

                    // ENTIDAD
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@idEntidad", idEntidad);
                    _sql_1 = @"SELECT 
                                    prv.ci_rif as ciRifEntidad,
                                    prv.razon_social as nombreRazonSocialEntidad,
                                    prv.auto as idEntidad,
                                    prv.codigo as codigoEntidad, 
                                    prv.dir_fiscal as dirFiscalEntidad,
                                    prv.telefono as telfEntidad, 
                                    prv.anticipos as anticiposEntidad ";
                    _sql_2 = @" FROM proveedores as prv  ";
                    _sql_3 = @" where prv.auto=@idEntidad ";
                    _sql = _sql_1 + _sql_2 + _sql_3;
                    _entidad = cnn.Database.SqlQuery<DtoLibTransporte.CxpDoc.GetInfoEntidad.Entidad>(_sql, p1).FirstOrDefault();
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
            result.Entidad = new DtoLibTransporte.CxpDoc.GetInfoEntidad.Ficha()
            {
                DocPendentes = _lstDoc,
                Entidad = _entidad,
            };
            //
            return result;
        }
    }
}
