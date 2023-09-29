using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Control.TipoCombo.TipoMovCaja
{
    public class Imp : LibUtilitis.CtrlCB.ImpCB, ICtrl
    {
        public Imp()
            : base()
        {
        }
        public void ObtenerData()
        {
            var _lst = new List<Idata>();
            _lst.Add(new data() { codigo = "", desc = "INGRESO", id = "1" });
            _lst.Add(new data() { codigo = "", desc = "EGRESO", id = "2" });
            this.CargarData(_lst);
        }
    }
}