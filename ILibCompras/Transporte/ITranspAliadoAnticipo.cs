using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspAliadoAnticipo
    {
        DtoLib.Resultado
            Transporte_Aliado_Anticipo_Agregar(DtoLibTransporte.Aliado.Anticipo.Agregar.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Anticipo.Anular.Ficha>
            Transporte_Aliado_Anticipo_Anular_ObtenerData(int idMov);
        DtoLib.Resultado
            Transporte_Aliado_Anticipo_Anular(DtoLibTransporte.Aliado.Anticipo.Anular.Ficha ficha);
        //
        DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Anticipo.Lista.Ficha>
            Transporte_Aliado_Anticipo_GetLista(DtoLibTransporte.Aliado.Anticipo.Lista.Filtro filtro);
    }
}