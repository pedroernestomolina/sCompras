using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Vistas
{
    public interface IAgregar: IAgregarEditar
    {
        int IdConceptoAgregado { get; }
    }
}