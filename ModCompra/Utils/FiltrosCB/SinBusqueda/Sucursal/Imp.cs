using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.SinBusqueda.Sucursal
{
    public class Imp: LibUtilitis.CtrlCB.ImpCB, ISucursal
    {
        public Imp()
            :base()
        {
        }
        public void ObtenerData()
        {
            var _lst = new List<Idata>();
            var r01 = Sistema.MyData.Sucursal_GetLista();
            foreach (var rg in r01.Lista.Where(w=>w.esActivo=="1").OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new data(rg));
            }
            this.CargarData(_lst);
        }
    }
}