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
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Corrector.GetData.Ficha> 
            Compra_DocumentoCorrector_GetData_ByIdDoc(string idDoc)
        {
            return ServiceProv.Compra_DocumentoCorrector_GetData_ByIdDoc(idDoc);
        }
        public DtoLib.Resultado Compra_DocumentoCorrector_Actualizar(DtoLibCompra.Documento.Corrector.ActualizarData.Ficha dataAct)
        {
            var r01 = ServiceProv.Compra_DocumentoCorrector_Validar(dataAct);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                return r01;
            return ServiceProv.Compra_DocumentoCorrector_Actualizar(dataAct);
        }
    }
}