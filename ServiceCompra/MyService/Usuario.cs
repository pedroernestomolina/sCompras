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
        public DtoLib.ResultadoEntidad<DtoLibCompra.Usuario.Data.Ficha> Usuario_Principal()
        {
            return ServiceProv.Usuario_Principal();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Usuario.Data.Ficha> Usuario_Buscar(DtoLibCompra.Usuario.Buscar.Ficha ficha)
        {
            return ServiceProv.Usuario_Buscar(ficha);
        }

        public DtoLib.Resultado Usuario_ActualizarSesion(DtoLibCompra.Usuario.ActualizarSesion.Ficha ficha)
        {
            return ServiceProv.Usuario_ActualizarSesion(ficha);
        }

    }

}