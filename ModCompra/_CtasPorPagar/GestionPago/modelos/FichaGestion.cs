using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.modelos
{
    public class FichaGestion: __.Modelos.GestionPago.IFichaGestion
    {
        public __.Modelos.GestionPago.IEntidad Entidad { get; set; }
        public IEnumerable<__.Modelos.GestionPago.IDoc> DocDeudas { get; set; }
        public IEnumerable<__.Modelos.GestionPago.IDoc> NotasCredito { get; set; }
    }
}
