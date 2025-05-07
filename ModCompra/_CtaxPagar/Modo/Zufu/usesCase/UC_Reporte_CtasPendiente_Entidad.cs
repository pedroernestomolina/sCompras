using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class UC_Reporte_CtasPendiente_Entidad: IReporte_CtasPendiente_Entidad
    {
        private Interfaces.IZufuLista _data;
        private string _infoEntidad;
        //
        public void setInfoEntidad(string info)
        {
            _infoEntidad = info;
        }
        public void setData(Interfaces.IZufuLista data)
        {
            _data = data;
        }
        public void Execute()
        {
            if (_data.GetCntItems> 0)
            {
                reportes.CtasPendiente.Entidad.IRepListaEntidad _rep = new reportes.CtasPendiente.Entidad.Imp();
                _rep.setFiltrosBusq("");
                _rep.setDataCargar(_data.GetItems);
                _rep.setInfoEntidad(_infoEntidad);
                _rep.Generar();
            }
        }
    }
}