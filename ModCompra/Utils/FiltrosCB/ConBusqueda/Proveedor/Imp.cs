using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.ConBusqueda.Proveedor
{
    public class Imp: LibUtilitis.CtrlCB.ImpCB ,  ICtrlConBusqueda
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
                var filtro = new OOB.LibCompra.Proveedor.Lista.Filtro();
                var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
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
        public void setTextoBuscar(string desc)
        {
            try
            {
                var _lst = new List<Idata>();
                var filtro = new OOB.LibCompra.Proveedor.Lista.Filtro();
                var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
                foreach (var rg in r01.Lista.Where(w => w.nombreRazonSocial.Trim().ToUpper().Contains(desc.Trim().ToUpper())).OrderBy(o => o.nombreRazonSocial).ToList())
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