using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Vistas
{
    public interface IAgregarEditar: ModCompra.HlpGestion.IGestion,
                                        ModCompra.HlpGestion.IAbandonar, 
                                        ModCompra.HlpGestion.IProcesar
    {
        Idata data { get; }
    }
}