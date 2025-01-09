using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspDocumentoRet
    {
        DtoLib.ResultadoLista<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha>
            Transporte_DocumentoRet_GetLista(DtoLibTransporte.DocumentoRet.ListaAdm.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha>
            Transporte_DocumentoRet_Crud_Corrector_ObtenerData(string idDoc);
        //
        DtoLib.Resultado
            Transporte_DocumentoRet_Crud_Anular_Procesar(DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha>
            Transporte_DocumentoRet_Crud_Anular_ObtenerData(string idRet);
    }
}