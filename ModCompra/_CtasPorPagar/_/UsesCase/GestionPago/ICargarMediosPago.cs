using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.UsesCase.GestionPago
{
    public interface ICargarMediosPago
    {
        IEnumerable<Modelos.GestionPago.IMedioPago> Execute();
    }
}