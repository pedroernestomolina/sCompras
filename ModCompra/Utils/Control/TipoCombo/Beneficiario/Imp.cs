using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Control.TipoCombo.Beneficiario
{
    public class Imp: LibUtilitis.CtrlCB.ImpCB, ICtrl 
    {
        public Imp()
            :base()
        {
        }
        public void ObtenerData()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Beneficiario_GetLista();
                var _lst = new List<Idata>();
                foreach(var rg in r01.Lista.OrderBy(o=>o.nombreRazonSocial).ToList())
                {
                    var nr = new data(rg);
                    _lst.Add(nr);
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