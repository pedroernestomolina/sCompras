using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    public partial class Service: IService
    {
        public DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha> 
            Transporte_CxpDoc_GetLista_DocPend(DtoLibTransporte.CxpDoc.DocPend.Filtro filtro)
        {
            return ServiceProv.Transporte_CxpDoc_GetLista_DocPend(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.DocEntidad.Ficha> 
            Transporte_CxpDoc_GetDocPend_ById(string idCxP)
        {
            return ServiceProv.Transporte_CxpDoc_GetDocPend_ById(idCxP);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.Pago.Agregar.Resultado>
            Transporte_CxpDoc_GestionPago_Agregar(DtoLibTransporte.CxpDoc.Pago.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_CxpDoc_GestionPago_Agregar(ficha);
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.Pago.Lista.Ficha> 
            Transporte_CxpDoc_GetLista_PagosEmitidos(DtoLibTransporte.CxpDoc.Pago.Lista.Filtro filtro)
        {
            return ServiceProv.Transporte_CxpDoc_GetLista_PagosEmitidos(filtro);
        }
        //
        public DtoLib.Resultado 
            Transporte_CxpDoc_GestionPago_Anular(DtoLibTransporte.CxpDoc.Pago.Anular.Ficha ficha)
        {
            return ServiceProv.Transporte_CxpDoc_GestionPago_Anular(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.Pago.Anular.Ficha> 
            Transporte_CxpDoc_GestionPago_Anular_ObtenerData(string idRecPago)
        {
            return ServiceProv.Transporte_CxpDoc_GestionPago_Anular_ObtenerData(idRecPago);
        }
        //
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado> 
            Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Ficha ficha)
        {
            return ServiceProv.Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(ficha);
        }
    }
}