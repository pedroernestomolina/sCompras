using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspCxpDoc
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha>
            Transporte_CxpDoc_GetLista_DocPend();
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha>
            Transporte_CxpDoc_GetDocPend_ById(string idCxP);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Resultado>
            Transporte_CxpDoc_GestionPago_Agregar(OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Ficha ficha);
        OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha>
            Transporte_CxpDoc_GetLista_PagosEmitidos(OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Filtro filtro);
        //
        OOB.Resultado
            Transporte_CxpDoc_GestionPago_Anular(OOB.LibCompra.Transporte.CxpDoc.Pago.Anular.Ficha ficha);
        //
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Resultado>
            Transporte_CxpDoc_GestionPago_Agregar_PagoPorRetencion(OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion.Ficha ficha);
    }
}