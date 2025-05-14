using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.UsesCase.GestionPago
{
    public interface ICargarInfoEntidad
    {
        __.Modelos.GestionPago.IFichaGestion Execute(string id);
    }
}