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

        public DtoLib.ResultadoEntidad<DtoLibCompra.Auditoria.Entidad.Ficha> 
            AuditoriaDocumento_Get(DtoLibCompra.Auditoria.Entidad.Busqueda ficha)
        {
            return ServiceProv.AuditoriaDocumento_Get(ficha);
        }

    }

}