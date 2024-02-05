using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    public interface ISucursal
    {
        OOB.ResultadoLista<OOB.LibCompra.Sucursal.Data.Ficha> 
            Sucursal_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Sucursal.Data.Ficha> 
            Sucursal_GetFicha(string auto);
    }
}