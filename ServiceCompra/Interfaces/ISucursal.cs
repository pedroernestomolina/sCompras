using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{
    
    public interface ISucursal
    {

        DtoLib.ResultadoLista<DtoLibCompra.Sucursal.Lista.Resumen> Sucursal_GetLista();
        DtoLib.ResultadoEntidad<DtoLibCompra.Sucursal.Data.Ficha> Sucursal_GetFicha(string autoSucursal);

    }

}