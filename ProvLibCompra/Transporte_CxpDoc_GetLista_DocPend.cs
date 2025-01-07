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
            Transporte_CxpDoc_GetLista_DocPend()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"SELECT 
                                    auto as idCxP,
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
                                    tasa_divisa as tasaFactor,
                                    auto_documento as idDocOrigen
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
    }
}
