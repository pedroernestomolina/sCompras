using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspDocumentoRet
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha>
            Transporte_DocumentoRet_GetLista(OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha>
            Transporte_DocumentoRet_Crud_Corrector_ObtenerData(string idDoc);
    }
}