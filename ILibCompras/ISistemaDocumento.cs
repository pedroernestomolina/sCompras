using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras
{
    public interface ISistemaDocumento
    {
        DtoLib.ResultadoEntidad<DtoLibCompra.SistemaDocumento.Entidad.Ficha>
            SistemaDocumento_Get(DtoLibCompra.SistemaDocumento.Entidad.Busqueda ficha);
    }
}