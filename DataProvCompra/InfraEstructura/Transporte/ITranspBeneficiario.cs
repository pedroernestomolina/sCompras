using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspBeneficiario
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha>
            Transporte_Beneficiario_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Beneficiario.Crud.Entidad.Ficha>
            Transporte_Beneficiario_GetById(int idBeneficiario);
        OOB.ResultadoId
            Transporte_Beneficiario_Agregar(OOB.LibCompra.Transporte.Beneficiario.Crud.Agregar.Ficha ficha);
        OOB.Resultado
            Transporte_Beneficiario_Editar(OOB.LibCompra.Transporte.Beneficiario.Crud.Editar.Ficha ficha);
    }
}