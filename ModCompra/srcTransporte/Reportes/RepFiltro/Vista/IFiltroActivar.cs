using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Vista
{
    public interface IFiltroActivar
    {
        bool TipoMovCaja { get; }
        bool Estatus { get; }
        bool Aliado { get; }
        bool Proveedor { get; }
        bool Caja { get; }
        bool Concepto { get; }
        bool Beneficiario { get; }
    }
}