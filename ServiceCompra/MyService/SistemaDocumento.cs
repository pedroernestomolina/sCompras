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

        public DtoLib.ResultadoEntidad<DtoLibCompra.SistemaDocumento.Entidad.Ficha> 
            SistemaDocumento_Get(DtoLibCompra.SistemaDocumento.Entidad.Busqueda ficha)
        {
            return ServiceProv.SistemaDocumento_Get(ficha);
        }

    }

}