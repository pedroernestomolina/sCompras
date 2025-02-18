using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{
    public interface IDocumento_Corrector
    {
        DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Corrector.GetData.Ficha>
            Compra_DocumentoCorrector_GetData_ByIdDoc(string idDoc);
        DtoLib.Resultado
            Compra_DocumentoCorrector_Actualizar(DtoLibCompra.Documento.Corrector.ActualizarData.Ficha dataAct);
    }
}
