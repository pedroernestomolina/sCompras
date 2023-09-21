using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Vistas
{
    public interface IdataAliado
    {
        int Id { get; set; }
        string ciRif { get; set; }
        string nombreRazonSocial { get; set; }
        decimal pendiente { get; set; }
        decimal anticipos { get; set; }
        decimal montoResta { get; set; }
        int cntDocPend { get; set; }
    }
}