using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Maestro.AgregarEditar.Vistas
{
    public interface IAgregar: IAgregarEditar
    {
        int IdItemAgregado { get; }
    }
}