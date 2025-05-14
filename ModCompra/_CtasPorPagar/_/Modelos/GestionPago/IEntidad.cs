using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.GestionPago
{
    public interface IEntidad
    {
        string id { get; set; }
        string codigo { get; set; }
        string nombreRazonSocial { get; set; }
        string ciRif { get; set; }
        string dirFiscal { get; set; }
        string telefonos { get; set; }
        decimal anticipos { get; set; }
    }
}