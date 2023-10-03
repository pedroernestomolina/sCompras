using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.SinBusqueda.TipoRetencion
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
            _lst.Add(new data() { id = "1", codigo = "", desc = "RETENCION IVA" });
            _lst.Add(new data() { id = "2", codigo = "", desc = "RETENCION ISLR" });
            this.CargarData(_lst);
        }
    }
}