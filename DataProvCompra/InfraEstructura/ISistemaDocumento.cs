using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface ISistemaDocumento
    {

        OOB.ResultadoEntidad<OOB.LibCompra.SistemaDocumento.Entidad.Ficha>
            SistemaDocumento_Get(OOB.LibCompra.SistemaDocumento.Entidad.Busqueda ficha);

    }

}