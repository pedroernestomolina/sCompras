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
                                        ret.documento_nombre as tipoRetDesc
                                    FROM compras_retenciones_detalle as retDet
                                    join compras_retenciones as ret on ret.auto=retDet.auto";
                    var _sql_2 = @" WHERE 1=1 ";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    if (filtro != null)
                    {
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha>(_sql, p1, p2).ToList();
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