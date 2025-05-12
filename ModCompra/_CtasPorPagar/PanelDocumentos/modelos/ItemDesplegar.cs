using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.modelos
{
    public class ItemDesplegar: __.Modelos.PanelDocumentos.IItemDesplegar 
    {
        public string docId { get; set; }
        public string docNumero { get; set; }
        public string docTipo { get; set; }
        public DateTime docFechaEmision { get; set; }
        public DateTime docFechaVence { get; set; }
        public int docDiasVencimiento { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoAcumulado { get; set; }
        public decimal MontoPendiente { get; set; }
        public string diasVencida { get; set; }
        public string docNotas { get; set; }
    }
}