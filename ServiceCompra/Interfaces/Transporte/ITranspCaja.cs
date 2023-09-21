using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspCaja
    {
        DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha>
            Transporte_Caja_GetLista();
    }
}