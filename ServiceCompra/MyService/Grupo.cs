using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    
    public partial class Service: IService
    {

        public DtoLib.ResultadoLista<DtoLibCompra.Maestros.Grupo.Resumen> Grupo_GetLista()
        {
            return ServiceProv.Grupo_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Maestros.Grupo.Ficha> Grupo_GetFicha(string auto)
        {
            return ServiceProv.Grupo_GetFicha(auto);
        }

        public DtoLib.ResultadoAuto Grupo_Agregar(DtoLibCompra.Maestros.Grupo.Agregar ficha)
        {
            return ServiceProv.Grupo_Agregar(ficha);
        }

        public DtoLib.Resultado Grupo_Editar(DtoLibCompra.Maestros.Grupo.Editar ficha)
        {
            return ServiceProv.Grupo_Editar(ficha);
        }

    }

}