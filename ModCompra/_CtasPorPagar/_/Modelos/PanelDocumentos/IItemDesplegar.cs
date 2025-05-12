using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.PanelDocumentos
{
    public interface IItemDesplegar
    {
        string docId { get; set; }
        string docNumero { get; set; }
        string docTipo { get; set; }
        DateTime docFechaEmision { get; set; }
        DateTime docFechaVence { get; set; }
        string diasVencida { get; set; }
        decimal MontoDeuda { get; set; }
        decimal MontoAcumulado { get; set; }
        string docNotas { get; set; }
        decimal MontoPendiente { get; }
    }
}