using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.modelos
{
    public class MedioPago: __.Modelos.GestionPago.IMedioPago
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
}
