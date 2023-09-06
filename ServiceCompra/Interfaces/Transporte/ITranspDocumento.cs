using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspDocumento
    {
        DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado>
            Transporte_Documento_Agregar_CompraGrasto(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha);

        DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGasto.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_GetData(string autoDoc);
        DtoLib.Resultado
            Transporte_Documento_Anular_CompraGrasto(DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Ficha ficha);

        DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista();
        DtoLib.ResultadoId
            Transporte_Documento_Concepto_Agregar(DtoLibTransporte.Documento.Concepto.Agregar.Ficha ficha);
        DtoLib.Resultado
            Transporte_Documento_Concepto_Editar(DtoLibTransporte.Documento.Concepto.Editar.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetById(int id);

        DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Entidad.Ficha>
            Transporte_Documento_Entidad_CompraGrasto_GetById(string autoDoc);
    }
}