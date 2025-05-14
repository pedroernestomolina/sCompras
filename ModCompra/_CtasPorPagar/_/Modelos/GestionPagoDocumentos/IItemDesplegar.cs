using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.GestionPagoDocumentos
{
    public interface IItemDesplegar
    {
        string docId { get; set; }
        string docNumero { get; set; }
        string docTipo { get; set; }
        DateTime docFechaEmision { get; set; }
        DateTime docFechaVence { get; set; }
        string diasVencida { get; set; }
        decimal Importe { get; set; }
        decimal Resta { get; set; }
        decimal MontoAAbonar { get; set; }
        string NotasDelAbono { get; set; }
    }
}