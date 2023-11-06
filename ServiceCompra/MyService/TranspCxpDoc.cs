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
            Transporte_CxpDoc_GetLista_DocPend()
        {
            return ServiceProv.Transporte_CxpDoc_GetLista_DocPend();
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.DocEntidad.Ficha> 
            Transporte_CxpDoc_GetDocPend_ById(string idCxP)
        {
            return ServiceProv.Transporte_CxpDoc_GetDocPend_ById(idCxP);
        }
        //
        public DtoLib.Resultado 
            Transporte_CxpDoc_GestionPago_Agregar(DtoLibTransporte.CxpDoc.Pago.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_CxpDoc_GestionPago_Agregar(ficha);
        }
    }
}