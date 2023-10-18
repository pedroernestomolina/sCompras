using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspBeneficiarioMov
    {
        OOB.ResultadoId
            Transporte_Beneficiario_Mov_Agregar(OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.Ficha ficha);
        //
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha>
            Transporte_Beneficiario_Mov_GetLista(OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Filtro filtro);
        //
        OOB.Resultado
            Transporte_Beneficiario_Mov_Anular(int idMov);
    }
}