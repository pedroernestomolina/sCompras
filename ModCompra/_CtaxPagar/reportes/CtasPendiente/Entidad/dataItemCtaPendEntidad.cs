using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.reportes.CtasPendiente.Entidad
{
    public class dataItemCtaPendEntidad: _CtaxPagar.Interfaces.IdataItemCtaPendEntidad
    {
        public string docNumero { get; set; }
        public string docTipo { get; set; }
        public DateTime docFechaEmision { get; set; }
        public DateTime docFechaVence { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoAcumulado { get; set; }
        public decimal MontoPendiente { get; set; }
        public string diasVencida { get; set; }
        public dataItemCtaPendEntidad(object rg)
        {
            var nr = (_CtaxPagar.Interfaces.IdataItemCtaPendEntidad)rg;
            diasVencida = nr.diasVencida;
            docFechaEmision = nr.docFechaEmision;
            docFechaVence = nr.docFechaVence;
            docNumero = nr.docNumero;
            docTipo = nr.docTipo;
            MontoAcumulado = nr.MontoAcumulado;
            MontoDeuda = nr.MontoDeuda;
            MontoPendiente = nr.MontoPendiente;
        }
    }
}