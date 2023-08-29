using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{

    public interface IAuditoria
    {

        DtoLib.ResultadoEntidad<DtoLibCompra.Auditoria.Entidad.Ficha>
            AuditoriaDocumento_Get(DtoLibCompra.Auditoria.Entidad.Busqueda ficha);

    }

}