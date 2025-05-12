using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.UsesCase.PanelDocumentos
{
    public interface IReporteDoc
    {
        void setInfoEntidad(string info);
        void setData(IEnumerable<Modelos.PanelDocumentos.IItemDesplegar> lista);
        void Execute();
    }
}