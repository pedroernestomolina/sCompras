using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Interfaces
{
    public interface IdataItemCtaPendEntidad
    {
        string docNumero { get; set; }
        string docTipo { get; set; }
        DateTime docFechaEmision { get; set; }
        DateTime docFechaVence { get; set; }
        string diasVencida { get; set; }
        decimal MontoDeuda { get; set; }
        decimal MontoAcumulado { get; set; }
        decimal MontoPendiente { get; }
    }
}
