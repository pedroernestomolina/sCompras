using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.GestionPago
{
    public interface IFichaGestion
    {
        IEntidad Entidad { get; set; }
        IEnumerable<IDoc> DocDeudas { get; set; }
        IEnumerable<IDoc> NotasCredito { get; set; }
    }
}
