using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class UC_Reporte_CtasPendiente_General: IReporte_CtasPendiente_General
    {
        private Interfaces.IZufuLista _data;
        //
        public void setData(Interfaces.IZufuLista data)
        {
            _data = data;
        }
        public void Execute()
        {
            if (_data.GetCntItems> 0)
            {
                reportes.IRepLista _rep = new reportes.CtasPendiente.General.Imp();
                _rep.setFiltrosBusq("");
                _rep.setDataCargar(_data.GetItems);
                _rep.Generar();
            }
        }
    }
}