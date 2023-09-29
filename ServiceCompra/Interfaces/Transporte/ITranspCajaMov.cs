using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspCajaMov
    {
        DtoLib.Resultado
            Transporte_Caja_Movimientos_Agregar(DtoLibTransporte.Caja.Movimiento.Crud.Agregar.Ficha ficha);
        DtoLib.ResultadoLista<DtoLibTransporte.Caja.Movimiento.Lista.Ficha>
            Transporte_Caja_Movimientos_GetLista(DtoLibTransporte.Caja.Movimiento.Lista.Filtro filtro);
        DtoLib.Resultado
            Transporte_Caja_Movimientos_Anular(DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha>
            Transporte_Caja_Movimientos_Anular_ObtenerData(int idMov);
    }
}