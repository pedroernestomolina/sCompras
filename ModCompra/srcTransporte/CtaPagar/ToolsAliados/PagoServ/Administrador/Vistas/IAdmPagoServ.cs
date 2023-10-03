using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Administrador.Vistas
{
    public interface IAdmPagoServ: Utils.Componente.Administrador.Vistas.IAdmin
    {
        IBusqDocPagoServ BusqDoc { get; }
        void LimpiarFiltros();
    }
}