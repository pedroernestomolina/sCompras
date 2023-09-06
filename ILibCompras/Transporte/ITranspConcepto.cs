using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspConcepto
    {
        DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista();
        DtoLib.ResultadoId
            Transporte_Documento_Concepto_Agregar(DtoLibTransporte.Documento.Concepto.Agregar.Ficha ficha);
        DtoLib.Resultado
            Transporte_Documento_Concepto_Editar(DtoLibTransporte.Documento.Concepto.Editar.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetById(int id);
    }
}
