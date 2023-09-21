using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Vistas
{
    public interface IdataServ
    {
        DateTime fechaDoc { get; set; }
        string numeroDoc { get; set; }
        string nombreDoc { get; set; }
        string cliente { get; set; }
        string servicio { get; set; }
        decimal pendiente { get; set; }
        bool isSelected { get; set; }
    }
}