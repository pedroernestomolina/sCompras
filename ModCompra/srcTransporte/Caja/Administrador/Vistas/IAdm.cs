using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Administrador.Vistas
{
    public interface IAdm: Utils.Componente.Administrador.Vistas.IAdmin
    {
        IBusqDocAdm BusqDoc { get; }
    }
}