using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspCaja
    {
        DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha>
            Transporte_Caja_GetLista();

        //MOVIMIENTOS
        DtoLib.Resultado
            Transporte_Caja_Movimientos_Agregar(DtoLibTransporte.Caja.Movimiento.Crud.Agregar.Ficha ficha);
        DtoLib.ResultadoLista<DtoLibTransporte.Caja.Movimiento.Lista.Ficha>
            Transporte_Caja_Movimientos_GetLista(DtoLibTransporte.Caja.Movimiento.Lista.Filtro filtro);
    }
}