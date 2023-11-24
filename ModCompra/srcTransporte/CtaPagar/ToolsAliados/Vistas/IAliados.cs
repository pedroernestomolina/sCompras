using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Vistas
{
    public interface IAliados: Utils.Tools.ITools
    {
        void AdmDocAnticipos();
        void AdmDocPagos();
    }
}