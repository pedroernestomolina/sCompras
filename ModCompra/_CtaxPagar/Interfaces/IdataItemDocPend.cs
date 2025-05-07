using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Interfaces
{
    public interface IdataItemDocPend
    {
        string CiRifEntidad { get; set; }
        string NombreEntidad { get; set; }
        decimal MontoDeuda { get; set; }
        decimal MontoCredito { get; set; }
        decimal MontoAcumulado { get; set; }
        decimal MontoPendiente { get; }
        int CntDocDeuda { get; }
    }
}
