using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.handlers
{
    public class dataItemDocPend: _CtaxPagar.Interfaces.IdataItemDocPend
    {
        public string IdEntidad { get; set; }
        public string CiRifEntidad { get; set; }
        public string NombreEntidad { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoAcumulado { get; set; }
        public int CntDocDeuda { get; set; }
        public decimal MontoPendiente { get { return MontoDeuda - MontoAcumulado; } }
    }
}