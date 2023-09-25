using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Aliado.PagoServ
{
    public class Imp : IRepFiltro
    {
        public Imp()
        {
        }
        public void setFiltros(Idata data)
        {
        }
        public void Generar()
        {
            try
            {
                var filtroOOB = new OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Filtro();
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_PagoServ_GetLista(filtroOOB);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha> list)
        {
        }
    }
}
