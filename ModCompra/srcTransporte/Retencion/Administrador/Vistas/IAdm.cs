using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Administrador.Vistas
{
    public interface IAdm: Utils.Componente.Administrador.Vistas.IAdmin
    {
        IBusqDoc BusqDoc { get; }
    }
}