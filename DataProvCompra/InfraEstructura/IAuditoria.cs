using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IAuditoria
    {

        OOB.ResultadoEntidad<OOB.LibCompra.Auditoria.Entidad.Ficha>
            AuditoriaDocumento_Get(OOB.LibCompra.Auditoria.Entidad.Busqueda ficha);

    }

}