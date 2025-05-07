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
        public DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha>
            Transporte_CxpDoc_GetLista_DocPend(DtoLibTransporte.CxpDoc.DocPend.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha>();
            //
            try
            {
                if (filtro == null) 
                {
                    throw new Exception("OPCIONES DE FILTRADO NO DEFINIDO");
                }
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
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
                    if (filtro.CadenaBusq.Trim() != "") 
                    {
                        var _filtroCadena = "%" + filtro.CadenaBusq.Trim() + "%";
                        p1.ParameterName= "@filtroCadena";
                        p1.Value = _filtroCadena;
                        _sql_3 += @" and prv.razon_social like @filtroCadena ";
                    }
                    if (filtro.IdEntidad.Trim() != "")
                    {
                        p2.ParameterName = "@idEntidad";
                        p2.Value = filtro.IdEntidad;
                        _sql_3 += @" and prv.auto=@idEntidad ";
                    }
                    var _sql = _sql_1 + _sql_2 + _sql_3;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.CxpDoc.DocPend.Ficha>(_sql, p1, p2).ToList();
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
            //
            return result;
        }
    }
}
