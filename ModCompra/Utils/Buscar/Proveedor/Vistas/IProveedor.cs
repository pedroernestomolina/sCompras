using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar.Proveedor.Vistas
{
    public interface IProveedor: Utils.Buscar.ICtrl
    {
        bool ProveedorIsOk { get; }
    }
}