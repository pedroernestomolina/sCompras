using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.Administrador.Vistas
{
    public interface IdataItem
    {
        DateTime EFechaMov { get; set; }
        string EProvNombre { get; set; }
        string EProvCiRif { get; set; }
        string EReciboNro { get; set; }
        decimal EMonto { get; set; }
        string EMotivo { get; set; }
        string EEstatus { get; set; }
    }
}