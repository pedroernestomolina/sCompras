using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspCxpDoc
    {
        DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.DocPend.Ficha>
            Transporte_CxpDoc_GetLista_DocPend();
        DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.DocEntidad.Ficha>
            Transporte_CxpDoc_GetDocPend_ById(string idCxP);
        DtoLib.ResultadoEntidad<DtoLibTransporte.CxpDoc.Pago.Agregar.Resultado>
            Transporte_CxpDoc_GestionPago_Agregar(DtoLibTransporte.CxpDoc.Pago.Agregar.Ficha ficha);
        DtoLib.ResultadoLista<DtoLibTransporte.CxpDoc.Pago.Lista.Ficha>
            Transporte_CxpDoc_GetLista_PagosEmitidos(DtoLibTransporte.CxpDoc.Pago.Lista.Filtro filtro);
    }
}