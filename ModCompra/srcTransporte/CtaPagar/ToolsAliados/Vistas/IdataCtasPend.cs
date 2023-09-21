using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Vistas
{
    public interface IdataCtasPend: Utils.Tools.IdataCtasPendientes
    {
        void ActualizarSaldo(Vistas.IdataAliado aliadoCta);
    }
}
