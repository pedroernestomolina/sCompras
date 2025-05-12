using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.reportes
{
    public interface IRepListaDoc: __.Reportes.IRepLista<__.Modelos.PanelDocumentos.IItemDesplegar>
    {
        void setInfoEntidad(string info);
    }
}
