using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Administrador.Vistas
{
    public interface IdataItem
    {
        DateTime FechaMov { get; set; }
        string AliadoNombre { get; set; }
        string AliadoCiRif { get; set; }
        string ReciboNro { get; set; }
        decimal Monto { get; set; }
        string Motivo { get; set; }
        string Estatus { get; set; }
    }
}