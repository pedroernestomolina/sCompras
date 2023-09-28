using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspCaja
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha>
            Transporte_Caja_GetLista();

        //MOVIMIENTOS
        OOB.Resultado
            Transporte_Caja_Movimientos_Agregar(OOB.LibCompra.Transporte.Caja.Movimiento.Crud.Agregar.Ficha ficha);
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha>
            Transporte_Caja_Movimientos_GetLista(OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Filtro filtro);
    }
}