using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspBeneficiario
    {
        DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Crud.Entidad.Ficha>
            Transporte_Beneficiario_GetById(int idBeneficiario);
        DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Lista.Ficha>
            Transporte_Beneficiario_GetLista();
        DtoLib.ResultadoId
            Transporte_Beneficiario_Agregar(DtoLibTransporte.Beneficiario.Crud.Agregar.Ficha ficha);
        DtoLib.Resultado
            Transporte_Beneficiario_Editar(DtoLibTransporte.Beneficiario.Crud.Editar.Ficha ficha);
    }
}
