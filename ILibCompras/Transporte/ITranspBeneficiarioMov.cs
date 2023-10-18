using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspBeneficiarioMov
    {
        DtoLib.ResultadoId
            Transporte_Beneficiario_Mov_Agregar(DtoLibTransporte.Beneficiario.Mov.Agregar.Ficha ficha);
        //
        DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Mov.Lista.Ficha>
            Transporte_Beneficiario_Mov_GetLista(DtoLibTransporte.Beneficiario.Mov.Lista.Filtro filtro);
        //
        DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Mov.Anular.Ficha>
            Transporte_Beneficiario_Mov_Anular_ObtenerData(int idMov);
        //
        DtoLib.Resultado
            Transporte_Beneficiario_Mov_Anular(DtoLibTransporte.Beneficiario.Mov.Anular.Ficha ficha);
    }
}