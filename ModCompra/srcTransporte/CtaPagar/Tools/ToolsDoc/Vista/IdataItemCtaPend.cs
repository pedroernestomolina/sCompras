using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Vista
{
    public interface IdataItemCtaPend
    {
        string Id { get; set; }
        string dataCiRif { get; set; }
        string dataNombreRazonSocial { get; set; }
        string dataDocNro { get; set; }
        DateTime dataFechaDoc { get; set; }
        string dataDocTipo { get; set; }
        decimal dataImporte { get; set; }
        decimal dataAcumulado { get; set; }
        decimal dataResta { get; set; }
        decimal Get_Pendiente { get; }
    }
}