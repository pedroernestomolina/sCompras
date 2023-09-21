using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos
{
    public interface Idata
    {
        enumerados.tipoRetencion tipoRetencion { get; }
        void setTipoRetencion(enumerados.tipoRetencion tipo);
    }
}