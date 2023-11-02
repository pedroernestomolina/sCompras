using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.SinBusqueda.MedioPago
{
    public class Imp: LibUtilitis.CtrlCB.ImpCB, IMedioPago
    {
        public Imp()
            :base()
        {
        }
        public void ObtenerData()
        {
            var _lst = new List<Idata>();
            var r01 = Sistema.MyData.Transporte_MedioPago_GetLista();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new data(rg));
            }
            this.CargarData(_lst);
        }
    }
}