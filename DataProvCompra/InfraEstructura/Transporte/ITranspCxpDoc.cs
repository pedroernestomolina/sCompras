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
        //
        OOB.Resultado
            Transporte_CxpDoc_GestionPago_Agregar(OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Ficha ficha);
    }
}