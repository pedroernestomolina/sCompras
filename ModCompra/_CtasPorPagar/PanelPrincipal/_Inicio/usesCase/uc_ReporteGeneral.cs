using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.usesCase
{
    public class uc_ReporteGeneral: __.UsesCase.PanelPrincipal.IReporteGeneral 
    {
        private IEnumerable<IItemDesplegar> _data;
        //
        public void setData(IEnumerable<IItemDesplegar> data)
        {
            _data = data;
        }
        public void Execute()
        {
            if (_data.Count()> 0)
            {
                reportes.IRepListaGeneral _rep = new reportes.ImpRepListaGeneral();
                _rep.setFiltrosBusq("");
                _rep.setDataCargar(_data);
                _rep.Generar();
            }
        }
    }
}