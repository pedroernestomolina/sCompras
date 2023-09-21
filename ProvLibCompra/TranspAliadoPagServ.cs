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
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha> 
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"SELECT 
                                    aliado.id as aliadoId,
                                    aliado.ciRif as aliadoCiRif,
                                    aliado.nombreRazonSocial as aliadoNombre,
                                    aliado.codigo as aliadoCodigo,
                                    vta.ci_rif as clienteCiRif,
                                    vta.razon_social as clienteNombre,
                                    aliadoDoc.doc_fecha as fechaDoc,
                                    aliadoDoc.doc_numero as numDoc,
                                    aliadoDoc.doc_nombre as nombreDoc,
                                    aliadoServ.importe_serv_div as importeServDiv,
                                    aliadoServ.id_serv as servId,
                                    aliadoServ.codigo_serv as servCodigo,
                                    aliadoServ.desc_serv as servDesc,
                                    aliadoServ.detalle_serv as servDetalle,
                                    aliadoServ.monto_acumulado_div as servMontoAcumuladoDiv,
                                    aliadoDoc.id as idAliadoDoc,
                                    aliadoServ.id as idAliadoServ
                                from transp_aliado_doc as aliadoDoc 
                                join transp_aliado_doc_servicio as aliadoServ on aliadoServ.id_aliado_doc=aliadoDoc.id
                                join transp_aliado as aliado on aliado.id=aliadoDoc.id_aliado
                                join ventas as vta on vta.auto=aliadoDoc.id_doc_ref
                                where aliado.id=@idAliado and 
                                        aliadoDoc.estatus_anulado='0' and
                                        aliadoServ.estatus_anulado='0' and 
                                        aliadoServ.importe_serv_div>aliadoServ.monto_acumulado_div";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", idAliado);
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha>(sql, p1).ToList();
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