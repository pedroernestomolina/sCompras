using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    public interface IDocumento_Corrector
    {
        OOB.ResultadoEntidad<OOB.LibCompra.Documento.Corrector.GetData.Ficha> 
            Compra_DocumentoCorrector_GetData(string idDoc);
        OOB.Resultado
            Compra_DocumentoCorrector_ActualizarData(OOB.LibCompra.Documento.Corrector.ActualizarData.Ficha ficha);
        //
        OOB.Resultado 
            Compra_DocumentoCorrector(OOB.LibCompra.Documento.Corrector.Ficha ficha);
    }
}