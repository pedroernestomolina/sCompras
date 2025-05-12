using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.usesCase
{
    public class uc_ReporteDoc: __.UsesCase.PanelDocumentos.IReporteDoc
    {
        private string _infoEntidad;
        private IEnumerable<__.Modelos.PanelDocumentos.IItemDesplegar> _lista;
        //
        public void setInfoEntidad(string info)
        {
            _infoEntidad = info;
        }
        public void setData(IEnumerable<__.Modelos.PanelDocumentos.IItemDesplegar> lista)
        {
            _lista = lista;
        }
        public void Execute()
        {
            if (_lista.Count()> 0)
            {
                reportes.IRepListaDoc  _rep = new reportes.ImpRepListaDoc();
                _rep.setFiltrosBusq("");
                _rep.setDataCargar(_lista);
                _rep.setInfoEntidad(_infoEntidad);
                _rep.Generar();
            }
        }
    }
}