using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IEstado
    {

        OOB.ResultadoLista<OOB.LibCompra.Maestros.Estado.Ficha> Estado_GetLista();

    }

}