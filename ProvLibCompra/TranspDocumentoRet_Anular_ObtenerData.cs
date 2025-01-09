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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha> 
            Transporte_DocumentoRet_Crud_Anular_ObtenerData(string idRet)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select
                                        c.auto_proveedor as idProveedor, 
                                        retDet.tipo_retencion as tipoRetencion,
                                        c.auto_cxp idCxP_Origen,
                                        retDet.auto_cxp_pago as idCxp_IR,
                                        retDet.auto_cxp_Recibo as idCxp_IR_Recibo,
                                        retDet.retencion as montoRetMonAct,
                                        ir.importeDivisa as montoRetMonDiv
                                    FROM compras_retenciones_detalle as retDet
                                    join compras as c on c.auto=retDet.auto_documento
                                    join cxp as ir on ir.auto=retDet.auto_cxp_pago
                                    where retDet.auto=@idRet";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idRet", idRet);
                    var ent = cnn.Database.SqlQuery<DtoLibTransporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha>(_sql, p1).FirstOrDefault();
                    rt.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}
