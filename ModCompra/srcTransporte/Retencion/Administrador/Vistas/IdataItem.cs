using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Administrador.Vistas
{
    public interface IdataItem
    {
        DateTime Fecha { get; set; }
        string TipoRet  { get; set; }
        string Documento { get; set; }
        string ProvNombre { get; set; }
        string ProvCiRif{ get; set; }
        string Estatus { get; set; }
        decimal RetTasa { get; set; }
        decimal RetMonto { get; set; }
    }
}