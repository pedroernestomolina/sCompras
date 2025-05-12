using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.UsesCase.PanelPrincipal
{
    public interface IReporteGeneral
    {
        void setData(IEnumerable<IItemDesplegar> ListaItems);
        void Execute();
    }
}