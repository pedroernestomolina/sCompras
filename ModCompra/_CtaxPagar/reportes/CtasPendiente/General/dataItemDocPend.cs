using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.reportes.CtasPendiente.General
{
    public class dataItemDocPend: _CtaxPagar.Interfaces.IdataItemDocPend
    {
        public string CiRifEntidad { get; set; }
        public string NombreEntidad { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoAcumulado { get; set; }
        public decimal MontoPendiente { get; set; }
        public int CntDocDeuda { get; set; }
        //
        public dataItemDocPend(object nr)
        {
            var rg = (_CtaxPagar.Interfaces.IdataItemDocPend) nr;
            CiRifEntidad = rg.CiRifEntidad;
            CntDocDeuda = rg.CntDocDeuda;
            MontoAcumulado = rg.MontoAcumulado;
            MontoCredito = rg.MontoCredito;
            MontoDeuda = rg.MontoDeuda;
            MontoPendiente = rg.MontoPendiente;
            NombreEntidad = rg.NombreEntidad;
        }
    }
}
