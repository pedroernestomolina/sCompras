using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Administrador.Vistas
{
    public interface IAdmAnticipo: Utils.Componente.Administrador.Vistas.IAdmin
    {

        IBusqDocAnticipo BusqDoc { get; }
    }
}