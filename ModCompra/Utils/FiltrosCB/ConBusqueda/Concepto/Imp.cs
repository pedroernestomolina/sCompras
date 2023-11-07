using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.ConBusqueda.Concepto
{
    public class Imp: LibUtilitis.CtrlCB.ImpCB ,  ICtrlConBusqueda
    {
        public string Get_TextoBuscar { get { return ""; } }


        public Imp()
            :base()
        {
        }
        public void ObtenerData()
        {
            var _lst = new List<Idata>();
            var r01 = Sistema.MyData.Transporte_Documento_Concepto_GetLista();
            foreach (var rg in r01.Lista.OrderBy(o => o.descripcion).ToList())
            {
                _lst.Add(new data(rg));
            }
            this.CargarData(_lst);
        }
        public void setTextoBuscar(string desc)
        {
            try
            {
                var _lst = new List<Idata>();
                var r01 = Sistema.MyData.Transporte_Documento_Concepto_GetLista ();
                foreach (var rg in r01.Lista.Where(w => w.descripcion.Trim().ToUpper().Contains(desc.Trim().ToUpper())).OrderBy(o => o.descripcion).ToList())
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