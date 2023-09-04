using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspDocumento
    {
        DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado>
            Transporte_Documento_Agregar_CompraGrasto(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha);
        DtoLib.Resultado 
            Transporte_Documento_Agregar_CompraGrasto_Verificar(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha);


        DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista();
        DtoLib.ResultadoId
            Transporte_Documento_Concepto_Agregar(DtoLibTransporte.Documento.Concepto.Agregar.Ficha ficha);
        DtoLib.Resultado
            Transporte_Documento_Concepto_Editar(DtoLibTransporte.Documento.Concepto.Editar.Ficha ficha);
    }
}