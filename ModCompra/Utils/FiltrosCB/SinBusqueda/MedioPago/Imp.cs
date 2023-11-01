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
            try
            {
                var _lst = new List<Idata>();
                var r01 = Sistema.MyData.tran.Transporte_Aliado_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombreRazonSocial).ToList())
                {
                    _lst.Add(new data(rg));
                }
                this.CargarData(_lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}