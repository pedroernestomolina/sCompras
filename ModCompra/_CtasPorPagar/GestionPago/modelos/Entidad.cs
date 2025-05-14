using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.modelos
{
    public class Entidad: __.Modelos.GestionPago.IEntidad
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string nombreRazonSocial { get; set; }
        public string ciRif { get; set; }
        public string dirFiscal { get; set; }
        public string telefonos { get; set; }
        public decimal anticipos { get; set; }
    }
}
