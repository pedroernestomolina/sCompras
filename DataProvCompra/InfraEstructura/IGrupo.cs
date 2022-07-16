using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IGrupo
    {

        OOB.ResultadoLista<OOB.LibCompra.Maestros.Grupo.Ficha> Grupo_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Maestros.Grupo.Ficha> Grupo_GetFicha(string auto);
        OOB.ResultadoAuto Grupo_Agregar(OOB.LibCompra.Maestros.Grupo.Agregar ficha);
        OOB.Resultado Grupo_Editar(OOB.LibCompra.Maestros.Grupo.Editar ficha);

    }

}