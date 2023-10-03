using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.SinBusqueda.TipoMovCaja
{
    public class Imp: LibUtilitis.CtrlCB.ImpCB, ICtrlSinBusqueda
    {
        public Imp()
            :base()
        {
        }
        public void ObtenerData()
        {
            var _lst = new List<Idata>();
            _lst.Add(new data() { id = "1", codigo = "", desc = "INGRESO" });
            _lst.Add(new data() { id = "2", codigo = "", desc = "EGRESO" });
            this.CargarData(_lst);
        }
    }
}