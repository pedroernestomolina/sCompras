using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv : IData
    {
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha> 
            Transporte_DocumentoRet_Crud_Anular_ObtenerData(string idRet)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha>();
            //
            var r01 = MyData.Transporte_DocumentoRet_Crud_Anular_ObtenerData(idRet);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad == null)
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha()
            {
                idCxp_IR = s.idCxp_IR,
                idCxp_IR_Recibo = s.idCxp_IR_Recibo,
                idCxP_Origen = s.idCxP_Origen,
                idProveedor = s.idProveedor,
                montoRetMonAct = s.montoRetMonAct,
                montoRetMonDiv = s.montoRetMonDiv,
                tipoRetencion = s.tipoRetencion,
                idSistemaDoc_CompraRet = s.idSistemaDoc_CompraRet,
            };
            //
            return result;
        }
    }
}
